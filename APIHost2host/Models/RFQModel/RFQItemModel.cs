using APIHost2host.PO_Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using static APIHost2Host.Helper.HelpMe;

namespace APIHost2host.Models.RFQModel
{
    public class RFQItem
    {
        public string PurchasingDocument { get; set; }
        public string Item { get; set; }
        public string DeletionIndicator { get; set; }
        public string RfqStatus { get; set; }
        public string LastChangedOn { get; set; }
        public string ShortText { get; set; }
        public string Material { get; set; }
        public string Plant { get; set; }
        public string StorageLocation { get; set; }
        public string ReqTrackingNumber { get; set; }
        public string MaterialGroup { get; set; }
        public string PurchasingInfoRec { get; set; }
        public string VendorMaterialNo { get; set; }
        public Decimal TargetQuantity { get; set; }
        public Decimal OrderQuantity { get; set; }
        public string OrderUnit { get; set; }
        public Decimal QuantityConversion { get; set; }
        public Decimal EqualTo { get; set; }
        public Decimal Denominator { get; set; }
        public Decimal NetOrderPrice { get; set; }
        public Decimal PriceUnit { get; set; }
        public Decimal NetOrderValue { get; set; }
        public Decimal GrossOrderValue { get; set; }
        public string QuotationDeadline { get; set; }
        public Decimal GrProcessingTime { get; set; }
        public string TaxCode { get; set; }
        public string BaseUnitOfMeasure { get; set; }
        public string ShippingInstr { get; set; }
        public Decimal OaTargetValue { get; set; }
        public string PriceDate { get; set; }
        public string PurchDocCategory { get; set; }
        public Decimal EffectiveValue { get; set; }
        public string AffectsCommitments { get; set; }
        public string MaterialType { get; set; }
        public string SubitemCategory { get; set; }
        public string SubItems { get; set; }
        public Decimal Subtotal1 { get; set; }
        public Decimal Subtotal2 { get; set; }
        public Decimal Subtotal3 { get; set; }
        public Decimal Subtotal4 { get; set; }
        public Decimal Subtotal5 { get; set; }

        public List<RFQItem> getRFQItem(string RFQNumber)
        {
            var client = new mi_osReadTableMCClient();
            client.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["SAPUserName"];
            client.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["SAPPassword"]; ;

            var @params = new dt_ReadTableMC_Request();

            @params.CLIENT = ConfigurationManager.AppSettings["SAPClient"];
            @params.QUERY_TABLE = "EKPO";
            @params.DELIMITER = "|";
            @params.NO_DATA = "";
            @params.ROWSKIPS = "0";
            @params.ROWCOUNT = "1000";
            @params.OPTIONS = new dt_ReadTableMC_RequestOPTIONS[1];
            @params.OPTIONS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestOPTIONS>(1);
            //@params.OPTIONS[0].TEXT = "EKORG EQ '" + ConfigurationManager.AppSettings["SAPOrgCode"] + "'";
            //@params.OPTIONS[1].TEXT = "AND BIDLISTNO EQ '" + rfqNo + "'";
            @params.OPTIONS[0].TEXT = "EBELN EQ '" + RFQNumber + "'";

            @params.FIELDS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestFIELDS>(42);
            ////new dt_ReadTableMC_RequestFIELDS[11];
            ////@params.FIELDS[0] = new dt_ReadTableMC_RequestFIELDS();
            @params.FIELDS[0].FIELDNAME = "EBELN";
            @params.FIELDS[1].FIELDNAME = "EBELP";
            @params.FIELDS[2].FIELDNAME = "LOEKZ";
            @params.FIELDS[3].FIELDNAME = "STATU";
            @params.FIELDS[4].FIELDNAME = "AEDAT";
            @params.FIELDS[5].FIELDNAME = "TXZ01";
            @params.FIELDS[6].FIELDNAME = "MATNR";
            @params.FIELDS[7].FIELDNAME = "WERKS";
            @params.FIELDS[8].FIELDNAME = "LGORT";
            @params.FIELDS[9].FIELDNAME = "BEDNR";
            @params.FIELDS[10].FIELDNAME = "MATKL";
            @params.FIELDS[11].FIELDNAME = "INFNR";
            @params.FIELDS[12].FIELDNAME = "IDNLF";
            @params.FIELDS[13].FIELDNAME = "KTMNG";
            @params.FIELDS[14].FIELDNAME = "MENGE";
            @params.FIELDS[15].FIELDNAME = "MEINS";
            @params.FIELDS[16].FIELDNAME = "BPRME";
            @params.FIELDS[17].FIELDNAME = "BPUMZ";
            @params.FIELDS[18].FIELDNAME = "UMREZ";
            @params.FIELDS[19].FIELDNAME = "UMREN";
            @params.FIELDS[20].FIELDNAME = "NETPR";
            @params.FIELDS[21].FIELDNAME = "PEINH";
            @params.FIELDS[22].FIELDNAME = "NETWR";
            @params.FIELDS[23].FIELDNAME = "BRTWR";
            @params.FIELDS[24].FIELDNAME = "AGDAT";
            @params.FIELDS[25].FIELDNAME = "WEBAZ";
            @params.FIELDS[26].FIELDNAME = "MWSKZ";
            @params.FIELDS[27].FIELDNAME = "LMEIN";
            @params.FIELDS[28].FIELDNAME = "EVERS";
            @params.FIELDS[29].FIELDNAME = "ZWERT";
            @params.FIELDS[30].FIELDNAME = "PRDAT";
            @params.FIELDS[31].FIELDNAME = "BSTYP";
            @params.FIELDS[32].FIELDNAME = "EFFWR";
            @params.FIELDS[33].FIELDNAME = "XOBLR";
            @params.FIELDS[34].FIELDNAME = "MTART";
            @params.FIELDS[35].FIELDNAME = "UPTYP";
            @params.FIELDS[36].FIELDNAME = "UPVOR";
            @params.FIELDS[37].FIELDNAME = "KZWI1";
            @params.FIELDS[38].FIELDNAME = "KZWI2";
            @params.FIELDS[39].FIELDNAME = "KZWI3";
            @params.FIELDS[40].FIELDNAME = "KZWI4";
            @params.FIELDS[41].FIELDNAME = "KZWI5";

            var result = client.mi_osReadTableMC(@params);

            List<RFQItem> rfqItemList = new List<RFQItem>();

            if (result.DATA != null)
            {
                foreach (var row in result.DATA)
                {
                    var resultRow = row.WA.Split('|').Select(p => p.Trim()).ToList();
                    var rfqItem = new RFQItem();

                    rfqItem.PurchasingDocument = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "EBELN")];
                    rfqItem.Item = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "EBELP")];
                    rfqItem.DeletionIndicator = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "LOEKZ")];
                    rfqItem.RfqStatus = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "STATU")];
                    rfqItem.LastChangedOn = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "AEDAT")];
                    rfqItem.ShortText = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "TXZ01")];
                    rfqItem.Material = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "MATNR")];
                    rfqItem.Plant = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "WERKS")];
                    rfqItem.StorageLocation = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "LGORT")];
                    rfqItem.ReqTrackingNumber = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "BEDNR")];
                    rfqItem.MaterialGroup = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "MATKL")];
                    rfqItem.PurchasingInfoRec = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "INFNR")];
                    rfqItem.VendorMaterialNo = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "IDNLF")];
                    rfqItem.TargetQuantity = decimal.Parse(resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "KTMNG")]);
                    /* edit by Iman Akbar Ramadhan - 05 Agustus 2019 - order quantity disamakan dengan target quantity dengan yang ada di SAP */
                    //rfqItem.OrderQuantity = decimal.Parse(resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "MENGE")]);
                    rfqItem.OrderQuantity = decimal.Parse(resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "KTMNG")]);
                    rfqItem.OrderUnit = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "MEINS")];
                    /* edit by Iman Akbar Ramadhan - 05 Agustus 2019 - order price dan Owner Estimate di kosongkan untuk keperluan tim OE */
                    //rfqItem.OrderPriceUnit = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "BPRME")];
                    //rfqItem.OrderPriceUnit = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "NETPR")];
                    //rfqItem.OwnerEstimate = decimal.Parse(rfqItem.OrderPriceUnit) * rfqItem.OrderQuantity;
                    rfqItem.QuantityConversion = decimal.Parse(resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "BPUMZ")]);
                    rfqItem.EqualTo = decimal.Parse(resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "UMREZ")]);
                    rfqItem.Denominator = decimal.Parse(resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "UMREN")]);
                    rfqItem.NetOrderPrice = decimal.Parse(resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "NETPR")]);
                    rfqItem.PriceUnit = decimal.Parse(resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "PEINH")]);
                    rfqItem.NetOrderValue = decimal.Parse(resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "NETWR")]);
                    rfqItem.GrossOrderValue = decimal.Parse(resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "BRTWR")]);
                    rfqItem.QuotationDeadline = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "AGDAT")];
                    rfqItem.GrProcessingTime = decimal.Parse(resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "WEBAZ")]);
                    rfqItem.TaxCode = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "MWSKZ")];
                    rfqItem.BaseUnitOfMeasure = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "LMEIN")];
                    rfqItem.ShippingInstr = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "EVERS")];
                    rfqItem.OaTargetValue = decimal.Parse(resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "ZWERT")]);
                    rfqItem.PriceDate = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "PRDAT")];
                    rfqItem.PurchDocCategory = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "BSTYP")];
                    rfqItem.EffectiveValue = decimal.Parse(resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "EFFWR")]);
                    rfqItem.AffectsCommitments = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "XOBLR")];
                    rfqItem.MaterialType = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "MTART")];
                    rfqItem.SubitemCategory = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "UPTYP")];
                    rfqItem.SubItems = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "UPVOR")];
                    rfqItem.Subtotal1 = decimal.Parse(resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "KZWI1")]);
                    rfqItem.Subtotal2 = decimal.Parse(resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "KZWI2")]);
                    rfqItem.Subtotal3 = decimal.Parse(resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "KZWI3")]);
                    rfqItem.Subtotal4 = decimal.Parse(resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "KZWI4")]);
                    rfqItem.Subtotal5 = decimal.Parse(resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "KZWI5")]);

                    rfqItemList.Add(rfqItem);
                }

            }


            return rfqItemList;
        }
    }
}