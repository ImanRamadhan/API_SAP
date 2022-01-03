using APIHost2host.Models.AppFrameworks;
using APIHost2host.PO_Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using static APIHost2Host.Helper.HelpMe;

namespace APIHost2host.Models.ProcurementModel
{
    public class VendorModel
    {
        public string VendorId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PenaltyCode { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Name2 { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Name3 { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Name4 { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string District { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PoBox { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PoBoxPcode { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PostalCode { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Region { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string SearchTerm { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Street { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Address { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string TrainStation { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? LocationNo1 { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? LocationNo2 { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Authorization { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Industry { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? CheckDigit { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DataLine { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DmeIndicator { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string InstructionKey { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatedOn { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? TotalPo { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Group { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int SequenceNo { get; set; }

        public static GeneralActionResponse<VendorModel> getDataVendor(GeneralActionResponse<VendorModel> paging, string totalVendor)
        {

            List<VendorModel> lstResult = new List<VendorModel>();
            var final = new GeneralActionResponse<VendorModel>();
            string RespMessages = "Data Vendor Not Found";

            //get vendor Code PDSI
            var selectedVendorList = GetVendorCodeByCompanyCode(totalVendor);
            if (selectedVendorList.Count == 0)
            {

                final = new GeneralActionResponse<VendorModel>()
                {
                    TotalRow = selectedVendorList.Count(),
                    ResponseCode = "05",
                    ResponseMessages = RespMessages
                };

                final.SetRecords(lstResult);

                return final;
            }

            var client = new mi_osReadTableMCClient();
            client.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["SAPUserName"];
            client.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["SAPPassword"];

            var @params = new dt_ReadTableMC_Request();

            @params.CLIENT = ConfigurationManager.AppSettings["SAPClient"];
            @params.QUERY_TABLE = "LFA1";
            @params.DELIMITER = "|";
            @params.NO_DATA = "";
            @params.ROWSKIPS = "0";
            @params.ROWCOUNT = totalVendor;
            //@params.OPTIONS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestOPTIONS>(selectedVendor.Count);
            //@params.OPTIONS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestOPTIONS>(1);

            //@params.OPTIONS[0].TEXT = "LIFNR EQ '" + selectedVendor[0] + "'";


            @params.FIELDS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestFIELDS>(30);

            @params.FIELDS[0].FIELDNAME = "MANDT";
            @params.FIELDS[1].FIELDNAME = "LIFNR";
            @params.FIELDS[2].FIELDNAME = "LAND1";
            @params.FIELDS[3].FIELDNAME = "NAME1";
            @params.FIELDS[4].FIELDNAME = "NAME2";
            @params.FIELDS[5].FIELDNAME = "NAME3";
            @params.FIELDS[6].FIELDNAME = "NAME4";
            @params.FIELDS[7].FIELDNAME = "ORT01";
            @params.FIELDS[8].FIELDNAME = "ORT02";
            @params.FIELDS[9].FIELDNAME = "PFACH";
            @params.FIELDS[10].FIELDNAME = "PSTL2";
            @params.FIELDS[11].FIELDNAME = "PSTLZ";
            @params.FIELDS[12].FIELDNAME = "REGIO";
            @params.FIELDS[13].FIELDNAME = "SORTL";
            @params.FIELDS[14].FIELDNAME = "STRAS";
            @params.FIELDS[15].FIELDNAME = "ADRNR";
            @params.FIELDS[16].FIELDNAME = "MCOD1";
            @params.FIELDS[17].FIELDNAME = "MCOD2";
            @params.FIELDS[18].FIELDNAME = "MCOD3";
            @params.FIELDS[19].FIELDNAME = "ANRED";
            @params.FIELDS[20].FIELDNAME = "BAHNS";
            @params.FIELDS[21].FIELDNAME = "BBBNR";
            @params.FIELDS[22].FIELDNAME = "BBSNR";
            @params.FIELDS[23].FIELDNAME = "BEGRU";
            @params.FIELDS[24].FIELDNAME = "BRSCH";
            @params.FIELDS[25].FIELDNAME = "BUBKZ";
            @params.FIELDS[26].FIELDNAME = "DATLT";
            @params.FIELDS[27].FIELDNAME = "DTAMS";
            //@params.FIELDS[28].FIELDNAME = "DTAWS";
            @params.FIELDS[28].FIELDNAME = "KTOKK";
            @params.FIELDS[29].FIELDNAME = "ERDAT";


            // @params.OPTIONS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestOPTIONS>(1000);
            lstResult = new List<VendorModel>();

            int i = 0;
            int leftItemCount = selectedVendorList.Count;

            //First init options
            if (leftItemCount > 1000)
            {
                @params.OPTIONS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestOPTIONS>(1000);
                leftItemCount = leftItemCount - 1000;
            }
            else
            {
                @params.OPTIONS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestOPTIONS>(leftItemCount);
            }


            foreach (var selectedVendor in selectedVendorList)
            {
                if ((i) % 1000 == 0)
                {
                    @params.OPTIONS[(i) % 1000].TEXT = "LIFNR EQ '" + selectedVendor + "'";
                }
                else
                {
                    @params.OPTIONS[(i) % 1000].TEXT = " OR LIFNR EQ '" + selectedVendor + "'";
                }

                //we need to break transaction. SAP options paramater limited.
                if ((i + 1) % 1000 == 0 || i == (selectedVendorList.Count - 1))
                {
                    var result = client.mi_osReadTableMC(@params);

                    foreach (var item in result.DATA)
                    {
                        var resultRow = item.WA.Split('|').Select(p => p.Trim()).ToList();
                        var vendor = new VendorModel();
                        vendor.VendorId = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "LIFNR")];
                        vendor.Country = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "LAND1")];
                        vendor.Name = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "NAME1")];
                        vendor.Name2 = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "NAME2")];
                        vendor.Name3 = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "NAME3")];
                        vendor.Name4 = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "NAME4")];
                        vendor.City = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "ORT01")];
                        vendor.District = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "ORT02")];
                        vendor.PoBox = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "PFACH")];
                        vendor.PoBoxPcode = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "PSTL2")];
                        vendor.PostalCode = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "PSTLZ")];
                        vendor.Region = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "REGIO")];
                        vendor.SearchTerm = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "SORTL")];
                        vendor.Street = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "STRAS")];
                        vendor.Address = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "ADRNR")];
                        vendor.Name = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "MCOD1")];
                        vendor.Name2 = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "MCOD2")];
                        vendor.City = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "MCOD3")];
                        vendor.Title = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "ANRED")];
                        vendor.TrainStation = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "BAHNS")];
                        vendor.LocationNo1 = int.Parse(resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "BBBNR")]);
                        vendor.LocationNo2 = int.Parse(resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "BBSNR")]);
                        vendor.Authorization = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "BEGRU")];
                        vendor.Industry = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "BRSCH")];
                        vendor.CheckDigit = int.Parse(resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "BUBKZ")]);
                        vendor.DataLine = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "DATLT")];
                        vendor.DmeIndicator = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "DTAMS")];
                        //vendor.InstructionKey = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "DTAWS")];
                        vendor.CreatedOn = ToDateTimeSapNullSafe(resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "ERDAT")]);
                        vendor.Group = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "KTOKK")];

                        lstResult.Add(vendor);
                    }

                    //reset filter
                    if (leftItemCount > 1000)
                    {
                        @params.OPTIONS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestOPTIONS>(1000);
                        leftItemCount = leftItemCount - 1000;
                    }
                    else
                    {
                        @params.OPTIONS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestOPTIONS>(leftItemCount);
                    }

                }
                i++;
                // j++;
            }

            RespMessages = lstResult.Count() > 0 ? "Data Vendor Load Successfully" : RespMessages;
            final = new GeneralActionResponse<VendorModel>()
            {
                TotalRow = lstResult.Count(),
                ResponseCode = "00",
                ResponseMessages = RespMessages
            };

            final.SetRecords(lstResult);

            return final;
        }

        public static List<string> GetVendorCodeByCompanyCode(string totalVendor)
        {
            var vendorList = new List<string>();
            var client = new mi_osReadTableMCClient();
            client.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["SAPUserName"];
            client.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["SAPPassword"];

            var @params = new dt_ReadTableMC_Request();

            @params.CLIENT = ConfigurationManager.AppSettings["SAPClient"];
            @params.QUERY_TABLE = "LFB1";
            @params.DELIMITER = "|";
            @params.NO_DATA = "";
            @params.ROWSKIPS = "0";
            @params.ROWCOUNT = totalVendor;


            @params.OPTIONS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestOPTIONS>(1);
            @params.OPTIONS[0].TEXT = "BUKRS EQ '" + ConfigurationManager.AppSettings["SAPOrgCode"] + "'";

            @params.FIELDS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestFIELDS>(1);
            @params.FIELDS[0].FIELDNAME = "LIFNR";

            var result = client.mi_osReadTableMC(@params);

            //Data list not found
            if (result.DATA == null) throw new Exception("Data not found!");

            var updatedVendorList = new List<VendorModel>();
            foreach (var item in result.DATA)
            {
                var resultRow = item.WA.Split('|').Select(p => p.Trim()).ToList();
                vendorList.Add(resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "LIFNR")]);
            }

            return vendorList;
        }

        public static GeneralActionResponse<VendorModel> getVendorPerformance(GeneralActionResponse<VendorModel> paging, string totalVendor)
        {
            List<VendorModel> lstResult = new List<VendorModel>();
            var final = new GeneralActionResponse<VendorModel>();
            string RespMessages = "Data Vendor Not Found";

            //get vendor Code PDSI
            var selectedVendorList = GetVendorCodeByCompanyCode(totalVendor);
            if (selectedVendorList.Count == 0)
            {

                final = new GeneralActionResponse<VendorModel>()
                {
                    TotalRow = selectedVendorList.Count(),
                    ResponseCode = "05",
                    ResponseMessages = RespMessages
                };

                final.SetRecords(lstResult);

                return final;
            }

            var client = new mi_osReadTableMCClient();
            client.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["SAPUserName"];
            client.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["SAPPassword"];

            var @params = new dt_ReadTableMC_Request();

            @params.CLIENT = ConfigurationManager.AppSettings["SAPClient"];
            @params.QUERY_TABLE = "ZMVISUM";
            @params.DELIMITER = "|";
            @params.NO_DATA = "";
            @params.ROWSKIPS = "0";
            @params.ROWCOUNT = totalVendor;

            @params.FIELDS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestFIELDS>(3);
            @params.FIELDS[0].FIELDNAME = "LIFNR";
            @params.FIELDS[1].FIELDNAME = "PCODET";
            @params.FIELDS[2].FIELDNAME = "TT_PO";

            int i = 0;
            int leftItemCount = selectedVendorList.Count;

            //First init options
            if (leftItemCount > 1000)
            {
                @params.OPTIONS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestOPTIONS>(1001);
                leftItemCount = leftItemCount - 1000;
                @params.OPTIONS[1000].TEXT = ") AND REGGROUP EQ 'KORP'";
            }
            else
            {
                @params.OPTIONS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestOPTIONS>(leftItemCount + 1);
                @params.OPTIONS[leftItemCount].TEXT = ") AND REGGROUP EQ 'KORP'";
            }

            foreach (var selectedVendor in selectedVendorList)
            {
                if ((i) % 1000 == 0)
                {
                    @params.OPTIONS[(i) % 1000].TEXT = "(LIFNR EQ '" + selectedVendor + "'";
                }
                else
                {
                    @params.OPTIONS[(i) % 1000].TEXT = " OR LIFNR EQ '" + selectedVendor + "'";
                }

                //we need to break transaction. SAP options paramater limited.
                if ((i + 1) % 1000 == 0 || i == (selectedVendorList.Count - 1))
                {
                    var result = client.mi_osReadTableMC(@params);

                    foreach (var item in result.DATA)
                    {
                        var resultRow = item.WA.Split('|').Select(p => p.Trim()).ToList();
                        var vendor = new VendorModel();
                        vendor.VendorId = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "LIFNR")];
                        vendor.PenaltyCode = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "PCODET")];
                        vendor.TotalPo = Int32.Parse(resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "TT_PO")]);

                        lstResult.Add(vendor);
                    }

                    //reset filter
                    if (leftItemCount > 1000)
                    {
                        @params.OPTIONS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestOPTIONS>(1001);
                        leftItemCount = leftItemCount - 1000;
                        @params.OPTIONS[1000].TEXT = ") AND REGGROUP EQ 'KORP'";
                    }
                    else
                    {
                        @params.OPTIONS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestOPTIONS>(leftItemCount + 1);
                        @params.OPTIONS[leftItemCount].TEXT = ") AND REGGROUP EQ 'KORP'";
                    }


                }
                i++;
                // j++;
            }

            RespMessages = lstResult.Count() > 0 ? "Data Performance Vendor Load Successfully" : RespMessages;
            final = new GeneralActionResponse<VendorModel>()
            {
                TotalRow = selectedVendorList.Count(),
                ResponseCode = "00",
                ResponseMessages = RespMessages
            };

            final.SetRecords(lstResult);

            return final;
        }

        public static GeneralActionResponse<VendorModel> getBidderListByCollectiveNumber(GeneralActionResponse<VendorModel> paging, string collectiveNumber)
        {
            List<VendorModel> lstResult = new List<VendorModel>();
            var final = new GeneralActionResponse<VendorModel>();
            string RespMessages = "Data Vendor Not Found";

            var client = new mi_osReadTableMCClient();
            client.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["SAPUserName"];
            client.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["SAPPassword"];

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
            ////new dt_ReadTableMC_RequestFIELDS[11];
            ////@params.FIELDS[0] = new dt_ReadTableMC_RequestFIELDS();
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
            
            if (result.DATA != null)
            {
                foreach (var item in result.DATA)
                {
                    var resultRow = item.WA.Split('|').Select(p => p.Trim()).ToList();
                    var participant = new VendorModel();

                    //Only Get Vendor Id From SAP
                    participant.VendorId = resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "LIFNR")];
                    participant.SequenceNo = Int32.Parse(resultRow[Array.FindIndex(result.FIELDS, sapRow => sapRow.FIELDNAME == "SEQNO")]);
                
                    lstResult.Add(participant);
                }
            }

            RespMessages = lstResult.Count() > 0 ? "Data Bidder List By Collective Number Load Successfully" : RespMessages;
            final = new GeneralActionResponse<VendorModel>()
            {
                TotalRow = lstResult.Count(),
                ResponseCode = "00",
                ResponseMessages = RespMessages
            };

            final.SetRecords(lstResult);

            return final;

        }

        private static DateTime? ToDateTimeSapNullSafe(string value)
        {
            DateTime? date = null;
            if (value != "00000000")
            {
                date = DateTime.ParseExact(value, "yyyyMMdd", CultureInfo.InvariantCulture);
            }

            return date;
        }
    }
}