using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using APIHost2host.Models.AppFrameworks;
using APIHost2host.Models.Response;

namespace APIHost2host.Models.MIROModel
{
    public class MiroSimulate
    {
        public string UserName { get; set; }
        public string InvoiceDate { get; set; }
        public string Reference { get; set; }
        public string PostingDate { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string TaxCode { get; set; }
        public string BusinessPlace { get; set; }
        public string Text { get; set; }
        public string NoPO { get; set; }
        public string BaselineDate { get; set; }
        public string PaymentTerms { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentReference { get; set; }

        public static string[] c_AllowedPOTypeForMIRO = ConfigurationManager.AppSettings["MIRO.AllowedPOType"].Split(',');

        public static GeneralActionResponse<SimulateMIROResponse> SimulateMIRO(MiroSimulate request)
        {
            try
            {
                Dictionary<string, string> PODocTypeList = new Dictionary<string, string>();
                GeneralActionResponse<SimulateMIROResponse> result = null;

                string CompanyCode = "2110";
                
                #region 'Get PO Detail'
                SAPProxy.PODetail PO = new SAPProxy.PODetail(request.NoPO, CompanyCode);
                if (PO == null)
                {
                    result.ResponseCode = "05";
                    result.ResponseMessages = "Check PO Detail, Get PO Detail Failed.";
                }
                else if (PO.mPOHeader.Delete_Ind.Equals("L"))
                {
                    result.ResponseCode = "05";
                    result.ResponseMessages = "Check PO Detail, PO has been deleted.";
                }
                else if (!POTypeCheck(PO))
                {
                    result.ResponseCode = "05";
                    result.ResponseMessages = "Check PO Detail, PO Type <strong>" + PO.mPOHeader.Doc_Type + "</strong> is not allowed to be processed from this application. " +
                        "Please use Procure To Pay Web Application instead.";
                }
                else
                {
                    PODocTypeList.Add(PO.mPOHeader.Po_Number, PO.mPOHeader.Doc_Type);
                }
                #endregion

                #region 'Get Vendor Detail'
                SAPProxy.VendorDetail Vendor = new SAPProxy.VendorDetail(PO.mPOHeader.Vendor.Trim(), PO.mPOHeader.Suppl_Plnt, CompanyCode);
                #endregion

                #region 'Mapping Miro Document'
                SAPProxy.MIRODocument MIRODoc = new SAPProxy.MIRODocument();

                MIRODoc.InvoiceDate = CommonTools.changeFormatDateMIRO(request.InvoiceDate);
                MIRODoc.PostingDate = CommonTools.changeFormatDateMIRO(request.PostingDate);
                MIRODoc.Reference = request.Reference;

                string AmountFormat = CommonTools.GetAmountFormat(request.Currency);
                MIRODoc.Amount = Convert.ToDecimal(request.Amount.Replace(".", "").Replace(',', '.'));
                MIRODoc.Text = request.Text;
                MIRODoc.Currency = request.Currency;
                MIRODoc.DocType = SAPProxy.MIRODocument.MIRODocType.Invoice;

                MIRODoc.Username = request.UserName;
                MIRODoc.PONumber = request.NoPO;
                MIRODoc.BusinessPlace = request.BusinessPlace;
                MIRODoc.Keterangan = "";

                MIRODoc.OneTimeVendorData = new SAPProxy.OneTimeVendor();
                MIRODoc.OneTimeVendorData.Name = ""; // ask how to get name account bank vendor
                MIRODoc.OneTimeVendorData.City = ""; // ask same
                MIRODoc.OneTimeVendorData.Country = "ID"; // indonesia

                MIRODoc.BaselineDate = request.InvoiceDate; // sama with invoice data, look at sample data MIRO doc XML
                MIRODoc.DueDate = null;
                MIRODoc.PaymentMethod = request.PaymentMethod;
                MIRODoc.PaymentTerm = request.PaymentTerms;
                MIRODoc.PaymentBlock = "";
                MIRODoc.PartBank = string.Empty;
                MIRODoc.HouseBankAcctID = string.Empty;
                MIRODoc.HouseBank = string.Empty;

                MIRODoc.PaymentRef = request.PaymentReference;

                //details
                MIRODoc.Assignment = string.Empty;
                MIRODoc.CompanyCode = CompanyCode;
                MIRODoc.HeaderText = null;
                MIRODoc.PlanningDate = null;
                MIRODoc.PlanningLevel = string.Empty;
                MIRODoc.UnplannedDelvCost = Convert.ToDecimal("0");
                MIRODoc.DiffInvoicingParty = null;

                //tax list
                List<SAPProxy.TaxItem> tiList = new List<SAPProxy.TaxItem>();
                SAPProxy.TaxItem taxItem = new SAPProxy.TaxItem();
                taxItem.TaxAmount = "";
                taxItem.TaxAmountDec = Convert.ToDecimal("0");
                taxItem.TaxCode = request.TaxCode;
                tiList.Add(taxItem);

                MIRODoc.TaxAdjustmentList = tiList;

                // Withholding Tax List
                List<SAPProxy.WithholdingTaxItem> wtList = new List<SAPProxy.WithholdingTaxItem>();
                SAPProxy.WithholdingTaxItem whTaxItem = new SAPProxy.WithholdingTaxItem();
                whTaxItem.WTaxBaseAmount = Convert.ToDecimal("0");
                whTaxItem.WTaxType = "GA";
                whTaxItem.WTaxCode = "";
                wtList.Add(whTaxItem);

                whTaxItem = new SAPProxy.WithholdingTaxItem();
                whTaxItem.WTaxBaseAmount = Convert.ToDecimal("0");
                whTaxItem.WTaxType = "GB";
                whTaxItem.WTaxCode = "";
                wtList.Add(whTaxItem);

                MIRODoc.WTaxList = wtList;

                //PO Item List
                List<SAPProxy.MIRODocItem> lstPOItem = new List<SAPProxy.MIRODocItem>();
                SAPProxy.MIRODocItem SinglePOItem = null;
                if (PO.mMIROItemList.Count > 0)
                {
                    foreach (SAPProxy.PODetail.MIROItem SingleMIROItem in PO.mMIROItemList)
                    {
                        SinglePOItem = new SAPProxy.MIRODocItem();
                        SinglePOItem.PONumber = PO.mPOHeader.Po_Number.Trim();
                        SinglePOItem.POItemNumber = SingleMIROItem.POItemNo.TrimStart('0');
                        SinglePOItem.POItemType = SingleMIROItem.POItemType;
                        SinglePOItem.POItemNetPrice = SingleMIROItem.POItemNetPrice;
                        SinglePOItem.POItemGRIVInd = SingleMIROItem.POItemGRIVInd;
                        SinglePOItem.POItemSRVIVInd = SingleMIROItem.POItemSRVIVInd;
                        SinglePOItem.Amount = Convert.ToDecimal(SingleMIROItem.Amount > 0 ? string.Format(AmountFormat, SingleMIROItem.Amount) : "0");
                        SinglePOItem.AmountOriginal = Convert.ToDecimal(SingleMIROItem.AmountOriginal > 0 ? string.Format(AmountFormat, SingleMIROItem.AmountOriginal) : "0");
                        SinglePOItem.RefDocItem = SingleMIROItem.RefDocItem;
                        SinglePOItem.RefDocNumber = SingleMIROItem.RefDoc;
                        SinglePOItem.RefDocYear = SingleMIROItem.RefDocYear;
                        SinglePOItem.TaxCode = SingleMIROItem.POItemTaxCode;
                        SinglePOItem.FinalInvInd = SingleMIROItem.POItemFinalInvInd.Equals("X");
                        SinglePOItem.ClearingGRIRServiceInd = SingleMIROItem.ClearingGRIRServiceInd;
                        SinglePOItem.HistType = SingleMIROItem.HistoryType;
                        SinglePOItem.AccountAssignmentCount = SingleMIROItem.AccountDist.Count;

                        // Generate Account String
                        string AccountStr = "";
                        if (SingleMIROItem.AccountDist.Count > 0)
                        {
                            foreach (SAPProxy.PODetail.AccountDistribution SingleAccount in SingleMIROItem.AccountDist)
                            {
                                AccountStr += string.Format("#{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10}", SingleAccount.SerialNo, SingleAccount.Quantity, SingleAccount.Amount, SingleAccount.GLAccount, SingleAccount.CommitmentItem, SingleAccount.FundCenter, SingleAccount.CostCenter, SingleAccount.Order, SingleAccount.WBSElement, SingleAccount.ProfitCenter, SingleAccount.Network);
                            }
                            AccountStr = AccountStr.TrimStart('#');
                        }
                        SinglePOItem.AccountStr = AccountStr;

                        if (!(SinglePOItem.HistType.Equals("D") && !SinglePOItem.POItemSRVIVInd.Equals("X")))
                        {
                            if (!string.IsNullOrEmpty(string.Format("{0:0.000}", SingleMIROItem.Quantity).Replace(',', '!').Replace('.', ',').Replace('!', '.')))
                            {
                                SinglePOItem.Quantity = Convert.ToDecimal(string.Format("{0:0.000}", SingleMIROItem.Quantity));
                                SinglePOItem.QuantityOriginal = Convert.ToDecimal(string.Format("{0:0.000}", SingleMIROItem.QuantityOriginal));
                                SinglePOItem.UoM = SingleMIROItem.UoM;
                                SinglePOItem.UoMISO = SingleMIROItem.UoMISO;
                                SinglePOItem.OrderUnit = SingleMIROItem.OrderUnit;
                                SinglePOItem.OrderUnitISO = SingleMIROItem.OrderUnitISO;
                            }
                        }

                        if (SingleMIROItem.ConditionType == null)
                        {
                            SinglePOItem.ConditionType = "";
                        }
                        else
                        {
                            SinglePOItem.ConditionType = SingleMIROItem.ConditionType;
                        }
                        MIRODoc.POItemList.Add(SinglePOItem);
                    }
                }
                #endregion
               

                return result;
            }
            catch (Exception ex)
            {
                var final = new GeneralActionResponse<SimulateMIROResponse>()
                {
                    ResponseCode = "99",
                    ResponseMessages = "Error Exception : " + ex.Message.ToString()
                };

                return final;
            }



        }

       /* public static bool POTypeCheck(SAPProxy.PODetail PO)
        {
            int i = 0;
            bool found = false;
            string DocType = PO.mPOHeader.Doc_Type.Trim().ToUpper();
            while (i < c_AllowedPOTypeForMIRO.Length && !found)
            {
                if (c_AllowedPOTypeForMIRO[i].Equals(DocType))
                    found = true;
                i++;
            }
            return found;
        } */
    }
}