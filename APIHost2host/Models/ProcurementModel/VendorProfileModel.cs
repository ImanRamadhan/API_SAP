using APIHost2host.Models.AppFrameworks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APIHost2host.Models.ProcurementModel;
using APIHost2host.PO_Service;
using System.Configuration;
using static APIHost2Host.Helper.HelpMe;

namespace APIHost2host.Models.ProcurementModel
{
    public class VendorProfileModel
    {
        public string VendorId { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string InternalChar { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Counter { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ObjectClass { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ClassType { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string IntCounter { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CharValue { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ValueFrom { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string IntMeasUnit { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ValueTo { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ToleranceFrom { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ToleranceTo { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Percentage { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Increment { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Author { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ChangeNumber { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ValidFrom { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DeletionInd { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string InstanceCntr { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Position { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CompType { get; set; }

        public static GeneralActionResponse<VendorProfileModel> getDataProfileVendor(GeneralActionResponse<VendorProfileModel> paging, string totalVendor)
        {

            List<VendorProfileModel> lstResult = new List<VendorProfileModel>();
            var final = new GeneralActionResponse<VendorProfileModel>();
            string RespMessages = "Data Vendor Not Found";

            //get vendor Code PDSI
            var selectedVendorList = VendorModel.GetVendorCodeByCompanyCode(totalVendor);
            if (selectedVendorList.Count == 0)
            {

                final = new GeneralActionResponse<VendorProfileModel>()
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
            @params.QUERY_TABLE = "AUSP";
            @params.DELIMITER = "|";
            @params.NO_DATA = "";
            @params.ROWSKIPS = "0";
            @params.ROWCOUNT = totalVendor;

            @params.FIELDS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestFIELDS>(24);
            @params.FIELDS[0].FIELDNAME = "OBJEK";
            @params.FIELDS[1].FIELDNAME = "ATINN";
            @params.FIELDS[2].FIELDNAME = "ATZHL";
            @params.FIELDS[3].FIELDNAME = "MAFID";
            @params.FIELDS[4].FIELDNAME = "KLART";
            @params.FIELDS[5].FIELDNAME = "ADZHL";
            @params.FIELDS[6].FIELDNAME = "ATWRT";
            @params.FIELDS[7].FIELDNAME = "ATFLV";
            @params.FIELDS[8].FIELDNAME = "ATAWE";
            @params.FIELDS[9].FIELDNAME = "ATFLB";
            @params.FIELDS[10].FIELDNAME = "ATAW1";
            @params.FIELDS[11].FIELDNAME = "ATCOD";
            @params.FIELDS[12].FIELDNAME = "ATTLV";
            @params.FIELDS[13].FIELDNAME = "ATTLB";
            @params.FIELDS[14].FIELDNAME = "ATPRZ";
            @params.FIELDS[15].FIELDNAME = "ATINC";
            @params.FIELDS[16].FIELDNAME = "ATAUT";
            @params.FIELDS[17].FIELDNAME = "AENNR";
            @params.FIELDS[18].FIELDNAME = "DATUV";
            @params.FIELDS[19].FIELDNAME = "LKENZ";
            @params.FIELDS[20].FIELDNAME = "ATIMB";
            @params.FIELDS[21].FIELDNAME = "ATZIS";
            @params.FIELDS[22].FIELDNAME = "ATSRT";
            @params.FIELDS[23].FIELDNAME = "ATVGLART";


            //Data list not found

            lstResult = new List<VendorProfileModel>();
            int i = 0;
            int leftItemCount = selectedVendorList.Count;

            //First init options
            if (leftItemCount > 1000)
            {
                @params.OPTIONS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestOPTIONS>(1000 + 1);
                leftItemCount = leftItemCount - 1000;
                @params.OPTIONS[1000].TEXT = ") AND MANDT EQ '" + ConfigurationManager.AppSettings["SAPClient"] + "'";
                ////Filter Komisaris
                //@params.OPTIONS[1000 + 1].TEXT = " AND (ATINN EQ '0000000005'";
                ////Filter Direksi
                //@params.OPTIONS[1000 + 2].TEXT = " OR ATINN EQ '0000000019'";
                ////Filter Kualifikasi
                //@params.OPTIONS[1000 + 3].TEXT = " OR ATINN EQ '0000000010')";
            }
            else
            {
                @params.OPTIONS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestOPTIONS>(leftItemCount + 1);
                @params.OPTIONS[leftItemCount].TEXT = ") AND MANDT EQ '" + ConfigurationManager.AppSettings["SAPClient"] + "'";
                ////Filter Komisaris
                //@params.OPTIONS[leftItemCount + 1].TEXT = " AND (ATINN EQ '0000000005'";
                ////Filter Direksi
                //@params.OPTIONS[leftItemCount + 2].TEXT = " OR ATINN EQ '0000000019')";
                ////Filter Kualifikasi
                //@params.OPTIONS[leftItemCount + 3].TEXT = " OR ATINN EQ '0000000010')";
            }

            //need it to filter by regulation group, bulk merge need unique match target
            //@params.OPTIONS[1001].TEXT = " AND REGGROUP EQ 'KORP'";

            //var result = client.mi_osReadTableMC(@params);
            //if (result.DATA == null) throw new Exception("Data not found!");

            foreach (var selectedVendor in selectedVendorList)
            {
                if ((i) % 1000 == 0)
                {
                    @params.OPTIONS[(i) % 1000].TEXT = "(OBJEK EQ '" + selectedVendor + "'";
                }
                else
                {
                    @params.OPTIONS[(i) % 1000].TEXT = " OR OBJEK EQ '" + selectedVendor + "'";
                }

                //we need to break transaction. SAP options paramater limited.
                if ((i + 1) % 1000 == 0 || i == (selectedVendorList.Count - 1))
                {
                    var result = client.mi_osReadTableMC(@params);
                    if (result.DATA != null)
                    {

                        foreach (var item in result.DATA)
                        {
                            var resultRow = item.WA.Split('|').Select(p => p.Trim()).ToList();

                            var vp = new VendorProfileModel();
                            vp.VendorId = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "OBJEK")];
                            vp.InternalChar = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "ATINN")];
                            vp.Counter = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "ATZHL")];
                            vp.ObjectClass = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "MAFID")];
                            vp.ClassType = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "KLART")];
                            vp.IntCounter = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "ADZHL")];
                            vp.CharValue = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "ATWRT")];
                            vp.ValueFrom = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "ATFLV")];
                            vp.IntMeasUnit = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "ATAWE")];
                            vp.ValueTo = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "ATFLB")];
                            vp.IntMeasUnit = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "ATAW1")];
                            vp.Code = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "ATCOD")];
                            vp.ToleranceFrom = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "ATTLV")];
                            vp.ToleranceTo = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "ATTLB")];
                            vp.Percentage = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "ATPRZ")];
                            vp.Increment = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "ATINC")];
                            vp.Author = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "ATAUT")];
                            vp.ChangeNumber = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "AENNR")];
                            vp.ValidFrom = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "DATUV")];
                            vp.DeletionInd = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "LKENZ")];
                            //vp.InternalChar = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "ATIMB")];
                            vp.InstanceCntr = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "ATZIS")];
                            vp.Position = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "ATSRT")];
                            vp.CompType = resultRow[Array.FindIndex(result.FIELDS, row => row.FIELDNAME == "ATVGLART")];


                            lstResult.Add(vp);
                        }
                    }


                    //reset filter
                    if (leftItemCount > 1000)
                    {
                        @params.OPTIONS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestOPTIONS>(1000 + 1);
                        leftItemCount = leftItemCount - 1000;
                        @params.OPTIONS[1000].TEXT = ") AND MANDT EQ '" + ConfigurationManager.AppSettings["SAPOrgCode"] + "'";

                        ////Filter Komisaris
                        //@params.OPTIONS[1000 + 1].TEXT = " AND (ATINN EQ '0000000005'";
                        ////Filter Direksi
                        //@params.OPTIONS[1000 + 2].TEXT = " OR ATINN EQ '0000000019'";
                        ////Filter Kualifikasi
                        //@params.OPTIONS[1000 + 3].TEXT = " OR ATINN EQ '0000000010')";
                    }
                    else
                    {
                        @params.OPTIONS = InitializeArrayHelper.InitializeArray<dt_ReadTableMC_RequestOPTIONS>(leftItemCount + 1);
                        @params.OPTIONS[leftItemCount].TEXT = ") AND MANDT EQ '" + ConfigurationManager.AppSettings["SAPOrgCode"] + "'";
                        ////Filter Komisaris
                        //@params.OPTIONS[leftItemCount + 1].TEXT = " AND (ATINN EQ '0000000005'";
                        ////Filter Direksi
                        //@params.OPTIONS[leftItemCount + 2].TEXT = " OR ATINN EQ '0000000019'";
                        ////Filter Kualifikasi
                        //@params.OPTIONS[leftItemCount + 3].TEXT = " OR ATINN EQ '0000000010')";
                    }


                }
                i++;
                // j++;
            }

            RespMessages = lstResult.Count() > 0 ? "Data Vendor Profile Load Successfully" : RespMessages;
            final = new GeneralActionResponse<VendorProfileModel>()
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