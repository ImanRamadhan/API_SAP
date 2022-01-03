using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using APIHost2host.Models.AppFrameworks;
using APIHost2Host.Helper;
using APIHost2host.PO_Service;
using System.Configuration;
using static APIHost2Host.Helper.HelpMe;
using System.Globalization;

namespace APIHost2host.Models.POModel
{
    public class BidderListHeader
    {
        public string Title { get; set; }
        public DateTime SapBidderListCreatedDate { get; set; }
        public string SapBidderListCreatedBy { get; set; }
        public string ProcurementTypeId { get; set; }
        public string Classification { get; set; }
        public string Qualification { get; set; }
        public string RequestedBy { get; set; }
        public string RequestorPosition { get; set; }
        public string ApprovedBy { get; set; }
        public string ApproverPosition { get; set; }
        public List<Procparticipant> ProcParticipant { get; set; }

        
        public static GeneralActionResponse<BidderListHeader> getBidderListFromSAP(GeneralActionResponse<BidderListHeader> paging, string collectiveNumber)
        {
            //inquiry from SAP
            var client = new mi_osReadTableMCClient();
            client.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["SAPUserName"];
            client.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["SAPPassword"]; ;

            var @params = new dt_ReadTableMC_Request();

            @params.CLIENT = ConfigurationManager.AppSettings["SAPClient"];
            @params.QUERY_TABLE = "ZMBIDLISTH";
            @params.DELIMITER = "|";
            @params.NO_DATA = "";
            @params.ROWSKIPS = "0";
            @params.ROWCOUNT = "1";
            @params.OPTIONS = new dt_ReadTableMC_RequestOPTIONS[2];
            @params.OPTIONS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestOPTIONS>(2);
            @params.OPTIONS[0].TEXT = "EKORG EQ '" + ConfigurationManager.AppSettings["SAPOrgCode"] + "'";
            @params.OPTIONS[1].TEXT = "AND BIDLISTNO EQ '" + collectiveNumber + "'";
            @params.FIELDS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestFIELDS>(11);
            @params.FIELDS[0].FIELDNAME = "KNDPRO";
            @params.FIELDS[1].FIELDNAME = "SUBIDUSAHA";
            @params.FIELDS[2].FIELDNAME = "KUALIFIKASI";
            @params.FIELDS[3].FIELDNAME = "PENGADAAN";
            @params.FIELDS[4].FIELDNAME = "REKANAN";
            @params.FIELDS[5].FIELDNAME = "DIUSULKAN";
            @params.FIELDS[6].FIELDNAME = "DISETUJUI";
            @params.FIELDS[7].FIELDNAME = "JAB_DIUSULKAN";
            @params.FIELDS[8].FIELDNAME = "JAB_DISETUJUI";
            @params.FIELDS[9].FIELDNAME = "CRDATE";
            @params.FIELDS[10].FIELDNAME = "CRUSER";

            var result = client.mi_osReadTableMC(@params);

            List<BidderListHeader> lstResult = new List<BidderListHeader>();
            string RespMessages = "Data Not Found with collective Number " + collectiveNumber;

            //Bidder list not found
            if (result.DATA != null)
            { 
                //Bidder list exists
                var resultRow = result.DATA[0].WA.Split('|').Select(p => p.Trim()).ToList();

                //populate data
                BidderListHeader data = new BidderListHeader();
                data.Title = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "PENGADAAN")];
                data.SapBidderListCreatedDate = DateTime.ParseExact(resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "CRDATE")], "yyyyMMdd", CultureInfo.InvariantCulture);
                data.SapBidderListCreatedBy = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "CRUSER")];
                data.ProcurementTypeId = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "KNDPRO")];
                data.Classification = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "SUBIDUSAHA")];
                data.Qualification = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "KUALIFIKASI")];
                data.RequestedBy = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "DIUSULKAN")];
                data.RequestorPosition = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "JAB_DIUSULKAN")];
                data.ApprovedBy = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "DISETUJUI")];
                data.ApproverPosition = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "JAB_DISETUJUI")];
                data.ProcParticipant = Procparticipant.getAllParticipant(collectiveNumber);
                lstResult.Add(data);

                RespMessages = "Data Successfully populated";
            }

            var final = new GeneralActionResponse<BidderListHeader>()
            {
                TotalRow = lstResult.Count(),
                ResponseCode = "00",
                ResponseMessages = RespMessages
            };

            final.SetRecords(lstResult);

            return final;
        }
    }
}