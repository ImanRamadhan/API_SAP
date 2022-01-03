using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using APIHost2host.PO_Service;
using static APIHost2Host.Helper.HelpMe;

namespace APIHost2host.Models.POModel
{
    public class Procparticipant
    {
        public string VendorId { get; set; }
        public int SequenceNo { get; set; }
        public string VendorName { get; set; }
        public string VendorPenaltyCode { get; set; }
        public string Source { get; set; }

        public static List<Procparticipant> getAllParticipant(string collectiveNumber)
        {
            var client = new mi_osReadTableMCClient();
            client.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["SAPUserName"];
            client.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["SAPPassword"]; ;

            var @params = new dt_ReadTableMC_Request();

            @params.CLIENT = ConfigurationManager.AppSettings["SAPClient"];
            @params.QUERY_TABLE = "ZMBIDLISTI";
            @params.DELIMITER = "|";
            @params.NO_DATA = "";
            @params.ROWSKIPS = "0";
            @params.ROWCOUNT = "-1";
            @params.OPTIONS = new dt_ReadTableMC_RequestOPTIONS[2];
            @params.OPTIONS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestOPTIONS>(2);
            @params.OPTIONS[0].TEXT = "EKORG EQ '" + ConfigurationManager.AppSettings["SAPOrgCode"] + "'";
            @params.OPTIONS[1].TEXT = "AND BIDLISTNO EQ '" + collectiveNumber + "'";
            @params.FIELDS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestFIELDS>(16);
            @params.FIELDS[0].FIELDNAME = "MANDT";
            @params.FIELDS[1].FIELDNAME = "EKORG";
            @params.FIELDS[2].FIELDNAME = "EKGRP";
            @params.FIELDS[3].FIELDNAME = "BIDLISTNO";
            @params.FIELDS[4].FIELDNAME = "SEQNO";
            @params.FIELDS[5].FIELDNAME = "ORIG_SEQNO";
            @params.FIELDS[6].FIELDNAME = "LIFNR";
            @params.FIELDS[7].FIELDNAME = "KTOKK";
            @params.FIELDS[8].FIELDNAME = "STAKEHOLDERS";
            @params.FIELDS[9].FIELDNAME = "DIRECTOR";
            @params.FIELDS[10].FIELDNAME = "TT_BL";
            @params.FIELDS[11].FIELDNAME = "POINTT";
            @params.FIELDS[12].FIELDNAME = "PERCENT_WIN";
            @params.FIELDS[13].FIELDNAME = "BL_PL";
            @params.FIELDS[14].FIELDNAME = "TT_PO";
            @params.FIELDS[15].FIELDNAME = "STATUS";

            var result = client.mi_osReadTableMC(@params);

            List<Procparticipant> participantList = new List<Procparticipant>();
            if (result.DATA != null)
            {

                foreach (var row in result.DATA)
                {
                    var resultRow = row.WA.Split('|').Select(p => p.Trim()).ToList();
                    var participant = new Procparticipant();

                    //Only Get Vendor Id From SAP
                    participant.VendorId = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "LIFNR")];
                    participant.SequenceNo = Int32.Parse(resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "SEQNO")]);
                    participant.Source = "SAP";
                    
                    participantList.Add(participant);
                }

            }
            return participantList;
        }
    }
}