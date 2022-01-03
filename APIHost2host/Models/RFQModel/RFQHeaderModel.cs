using APIHost2host.Models.AppFrameworks;
using APIHost2host.PO_Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using static APIHost2Host.Helper.HelpMe;

namespace APIHost2host.Models.RFQModel
{
    public class RFQHeader
    {
        public string PRNumber { get; set; }
        public string OrderTypeId { get; set; }
        public DateTime RfqDate { get; set; }
        public DateTime QuotationDeadline { get; set; }
        public string PurchGroup { get; set; }
        public string AuthPersonName { get; set; }
        public string AuthPosition { get; set; }
        public List<RFQText> RfqTexts { get; set; }
        public List<RFQItem> RfqItems { get; set; }
        public string CurrencyId { get; set; }
        public string YourReference { get; set; }
        public string OurReference { get; set; }
        public string SalesPerson { get; set; }
        public string Telephone { get; set; }
        public string ValidityStart { get; set; }
        public string ValidityEnd { get; set; }
        public Decimal ItemInterval { get; set; }
        public Decimal SubItemInterval { get; set; }
        public string Warranty { get; set; }
        public string Language { get; set; }

        public static GeneralActionResponse<RFQHeader> getRFQHeader(GeneralActionResponse<RFQHeader> paging, string RFQNumber)
        {
            var client = new mi_osReadTableMCClient();
            client.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["SAPUserName"];
            client.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["SAPPassword"]; ;

            var @params = new dt_ReadTableMC_Request();

            @params.CLIENT = ConfigurationManager.AppSettings["SAPClient"];
            @params.QUERY_TABLE = "EKKO";
            @params.DELIMITER = "|";
            @params.NO_DATA = "";
            @params.ROWSKIPS = "0";
            @params.ROWCOUNT = "1";
            //@params.OPTIONS = new dt_ReadTableMC_RequestOPTIONS[2];
            @params.OPTIONS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestOPTIONS>(1);
            //@params.OPTIONS[0].TEXT = "";
            //@params.OPTIONS[0].TEXT = "EKORG EQ '" + ConfigurationManager.AppSettings["SAPOrgCode"] + "'";
            @params.OPTIONS[0].TEXT = "EBELN EQ '" + RFQNumber + "'";
            @params.FIELDS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestFIELDS>(17);
            ////new dt_ReadTableMC_RequestFIELDS[11];
            ////@params.FIELDS[0] = new dt_ReadTableMC_RequestFIELDS();
            @params.FIELDS[0].FIELDNAME = "AEDAT";
            @params.FIELDS[1].FIELDNAME = "ANGDT";
            @params.FIELDS[2].FIELDNAME = "BSART";
            @params.FIELDS[3].FIELDNAME = "EKGRP";
            @params.FIELDS[4].FIELDNAME = "GWLDT";
            @params.FIELDS[5].FIELDNAME = "IHREZ";
            @params.FIELDS[6].FIELDNAME = "PINCR";
            @params.FIELDS[7].FIELDNAME = "SPRAS";
            @params.FIELDS[8].FIELDNAME = "TELF1";
            @params.FIELDS[9].FIELDNAME = "UPINC";
            @params.FIELDS[10].FIELDNAME = "UNSEZ";
            @params.FIELDS[11].FIELDNAME = "VERKF";
            @params.FIELDS[12].FIELDNAME = "WAERS";
            @params.FIELDS[13].FIELDNAME = "ZZMMAUTHNAME";
            @params.FIELDS[14].FIELDNAME = "ZZMMAUTHPOS";
            @params.FIELDS[15].FIELDNAME = "ZZMMVLDEND";
            @params.FIELDS[16].FIELDNAME = "ZZMMVLDSTART";

            var result = client.mi_osReadTableMC(@params);

            //Bidder list not found
            List<RFQHeader> lstResult = new List<RFQHeader>();
            string RespMessages = "Data Not Found with RFQ Number " + RFQNumber;

            if (result.DATA != null)
            {
                //RFQ list exists
                var resultRow = result.DATA[0].WA.Split('|').Select(p => p.Trim()).ToList();

                //var x = ""Hello From End Point!""   
                RFQHeader RFQHeader = new RFQHeader();
                RFQText rfqText = new RFQText();
                RFQItem rfqItem = new RFQItem();

                RFQHeader.OrderTypeId = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "BSART")];
                RFQHeader.RfqDate = DateTime.ParseExact(resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "AEDAT")], "yyyyMMdd", CultureInfo.InvariantCulture);
                RFQHeader.QuotationDeadline = DateTime.ParseExact(resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "ANGDT")], "yyyyMMdd", CultureInfo.InvariantCulture);
                RFQHeader.PurchGroup = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "EKGRP")];
                RFQHeader.AuthPersonName = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "ZZMMAUTHNAME")];
                RFQHeader.AuthPosition = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "ZZMMAUTHPOS")];
                RFQHeader.RfqTexts = rfqText.getRFQText(RFQNumber);
                RFQHeader.RfqItems = rfqItem.getRFQItem(RFQNumber);
                RFQHeader.PRNumber = GetProcPRNumber(RFQNumber);
                RFQHeader.CurrencyId = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "WAERS")];
                RFQHeader.YourReference = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "IHREZ")];
                RFQHeader.OurReference = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "UNSEZ")];
                RFQHeader.SalesPerson = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "VERKF")];
                RFQHeader.Telephone = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "TELF1")];
                RFQHeader.ValidityStart = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "ZZMMVLDSTART")];
                RFQHeader.ValidityEnd = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "ZZMMVLDEND")];
                RFQHeader.ItemInterval = decimal.Parse(resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "PINCR")]);
                RFQHeader.SubItemInterval = decimal.Parse(resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "UPINC")]);
                RFQHeader.Warranty = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "GWLDT")];
                RFQHeader.Language = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "SPRAS")];
                lstResult.Add(RFQHeader);
                RespMessages = "Data Successfully populated";
            }

            //RFQHeader.SapBidderListCreatedDate = DateTime.ParseExact(resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "CRDATE")], "yyyyMMdd", CultureInfo.InvariantCulture);
            //RFQHeader.SapBidderListCreatedBy = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "CRUSER")];
            //RFQHeader.ProcurementTypeId = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "KNDPRO")];
            //RFQHeader.Classification = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "SUBIDUSAHA")];
            //RFQHeader.Qualification = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "KUALIFIKASI")];
            //RFQHeader.RequestedBy = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "DIUSULKAN")];
            //RFQHeader.RequestorPosition = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "JAB_DIUSULKAN")];
            //RFQHeader.ApprovedBy = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "JAB_DIUSULKAN")];
            //RFQHeader.ApproverPosition = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "JAB_DISETUJUI")];
            //RFQHeader.ProcParticipant = GetRFQItem(connection, request.RFQNo);
            //RFQHeader.ProcurementMethodId = request.RFQNo.Substring(3, 2);

            var final = new GeneralActionResponse<RFQHeader>()
            {
                TotalRow = lstResult.Count(),
                ResponseCode = "00",
                ResponseMessages = RespMessages
            };

            final.SetRecords(lstResult);

            return final;
        }

        public static string GetProcPRNumber(string RFQNumber)
        {
            string PRNumber = "";

            var client = new mi_osReadTableMCClient();
            client.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["SAPUserName"];
            client.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["SAPPassword"]; ;

            var @params = new dt_ReadTableMC_Request();

            @params.CLIENT = ConfigurationManager.AppSettings["SAPClient"];
            @params.QUERY_TABLE = "EKET";
            @params.DELIMITER = "|";
            @params.NO_DATA = "";
            @params.ROWSKIPS = "0";
            @params.ROWCOUNT = "1000000";
            @params.OPTIONS = new dt_ReadTableMC_RequestOPTIONS[1];
            @params.OPTIONS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestOPTIONS>(1);
            //@params.OPTIONS[0].TEXT = "EKORG EQ '" + ConfigurationManager.AppSettings["SAPOrgCode"] + "'";
            //@params.OPTIONS[1].TEXT = "AND BIDLISTNO EQ '" + rfqNo + "'";
            @params.OPTIONS[0].TEXT = "EBELN EQ '" + RFQNumber + "'";

            @params.FIELDS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestFIELDS>(1);
            ////new dt_ReadTableMC_RequestFIELDS[11];
            ////@params.FIELDS[0] = new dt_ReadTableMC_RequestFIELDS();
            @params.FIELDS[0].FIELDNAME = "BANFN";


            var result = client.mi_osReadTableMC(@params);

            ////Bidder list not found
            //if (result.DATA == null) throw new ValidationError("Rfq " + collectiveNumber + " not found!");
            
            if (result.DATA != null)
            {
                var rows = result.DATA.GroupBy(p => p.WA)
                    .Select(g => g.First())
                    .ToList();

                foreach (var row in rows)
                {
                    var resultRow = row.WA.Split('|').Select(p => p.Trim()).ToList();

                    PRNumber = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "BANFN")];
                }

            }

            return PRNumber;
        }
    }
}