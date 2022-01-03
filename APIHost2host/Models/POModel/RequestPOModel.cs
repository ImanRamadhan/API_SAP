using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using APIHost2host.Models.Master;
using APIHost2host.Models.AppFrameworks;
using APIHost2host.Models.Response;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Web.Services.Protocols;
using System.Web.Script.Serialization;

namespace APIHost2host.Models.POModel
{
    public class RequestPO
    {
        public string TypeAction { get; set; } //type action digunakan untuk proses simulate (X) atau posting (string.empty)
        public string Username { get; set; }
        public string CustPO { get; set; }
        public string ReqId { get; set; }
        public string MANDT { get; set; }
        //public string ReqDescription { get; set; }
        //public string DueDate { get; set; }
        //public string RequestStatus { get; set; }
        //public string RequestStatusDesc { get; set; }
        //public string CreatedDate { get; set; }
        public string OTV { get; set; }
        public string VendorStreetHouse { get; set; }
        public string VendorHouseNumber { get; set; }
        public string VendorPostalCode { get; set; }
        public string VendorCity { get; set; }
        public string VendorCountryID { get; set; }
        public string DeliveryName { get; set; }
        public string DeliveryStreetHouse { get; set; }
        public string DeliveryHouseNumber { get; set; }
        public string DeliveryPostalCode { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryCountryID { get; set; }
        public string PMName { get; set; }
        public string Toko { get; set; }
        public string TokoID { get; set; }
        //public string ResponseID { get; set; }
        public string WBS_Lv_ID { get; set; }
        public string OrderID { get; set; }
        //public string Requestor { get; set; }
        public string TaxType { get; set; }
        public List<MaterialItem> MaterialItems { get; set; }
        public string SAPBUKRS { get; set; }
        public string SAPWAERS { get; set; }
        public string SAPEKORG { get; set; }
        public string SAPEKGRP { get; set; }
        public string SAPFRGKE { get; set; }
        public string SAPZTERM { get; set; }
        public string SAPZZMMTYPE { get; set; }
        public string SAPBSART { get; set; }
        public string SAPOPTYPE { get; set; }
        public string SAPKNTTP { get; set; }
        public string SAPWERKS { get; set; }
        public string SAPREPOS { get; set; }
        public string SAPWEBRE { get; set; }
        public string SAPZEKKN { get; set; }
        public string SAPSAKTO { get; set; }
        public string SAPEINDT { get; set; }
        public string ZZMMAUTHNAME { get; set; }
        public string ZZMMAUTHPOS { get; set; }
        //public decimal GrandTotal
        //{
        //    get
        //    {
        //        decimal result = 0;

        //        (MaterialItems ?? new List<MaterialItem>()).ForEach(t => result += t.HargaTotal);

        //        return result;
        //    }
        //}

        public static async System.Threading.Tasks.Task<GeneralActionResponse<CreatePOResponse>> createPOAsync(RequestPO request)
        {
            LogModel log = new LogModel();

            try
            {
                var result = new GeneralActionResponse<CreatePOResponse>();

                var poparams = new PO_Services2.dt_po_requestPO_DETAILS[1];

                var xmlPo = "";

                var param = new PO_Services2.dt_po_requestPO_DETAILS
                {

                    MANDT = request.MANDT,
                    OPTYPE = request.SAPOPTYPE,
                    EBELN_EXT = request.CustPO,
                    TESTRUN = request.TypeAction,

                    BSART = request.SAPBSART, //Perubahan Posting Type Untuk LTC
                    AEDAT = DateTime.Now.ToString("yyyyMMdd"),

                    //kosongan
                    DELETE_IND = "",
                    WKURS = "",
                    INCO1 = "",
                    INCO2 = "",
                    ZZMMSHIPDAT = "",
                    ZZMMLCFINAL = "",
                    ZZMMBONDNO = "",
                    ZZMMBANKL = "",
                    ZZMMVLDSTART = "",
                    ZZMMVLDEND = "",
                    ZZMMDLVTIME = "",
                    ZZMMUOT = "",
                    ZZMMPARTALLOW = "",
                    ZZMMAFE = "",
                    ZZMMTKDN = "",
                    ZZMMAUTHNAME = request.ZZMMAUTHNAME ?? "",
                    ZZMMAUTHPOS = request.ZZMMAUTHPOS ?? "",
                    ZZMMPYMMTD = "",
                    RESIKO = "",
                    ZZMMKOMODITAS = "",
                    ZZMMSTATUSPT = "",
                    ZZMMPROCLIST = "",
                    ZZMMBIDLIST = "",
                    ZZIP2P_SUBBID = "",
                    ZZIP2P_OWNEREST = "",
                    ZZIP2P_CURR = "",
                    ZZMMTTYPE = "",
                    BEDAT = DateTime.Now.ToString("yyyyMMdd"),
                    LIFNR = request.OTV ?? "",//data.TokoID,
                    BUKRS = request.SAPBUKRS, //table rf_parameter
                    WAERS = request.SAPWAERS, //table rf_parameter
                    EKORG = request.SAPEKORG, //table rf_parameter
                    EKGRP = request.SAPEKGRP, //table rf_parameter
                    FRGKE = request.SAPFRGKE, //table rf_parameter
                    ZTERM = request.SAPZTERM, //table rf_parameter
                    ZZMMTYPE = request.SAPZZMMTYPE, //table rf_parameter
                };

                param.POPARTNER = new PO_Services2.dt_po_requestPO_DETAILSPOPARTNER[1]
                {
                    new PO_Services2.dt_po_requestPO_DETAILSPOPARTNER()
                    {
                        BUSPARTNO = "",
                        PARTNERDESC = ""
                    }
                };

                param.VERSIONS = new PO_Services2.dt_po_requestPO_DETAILSVERSIONS()
                {
                    COMPLETED = "X",
                    DESCRIPTION = "CREATE"
                };

                param.HEADERTEXT = new PO_Services2.dt_po_requestPO_DETAILSHEADERTEXT[1];
                param.HEADERTEXT[0] = new PO_Services2.dt_po_requestPO_DETAILSHEADERTEXT()
                {
                    TEXT_ID = (System.Configuration.ConfigurationManager.AppSettings["HEADERTEXT_ID"] ?? "F01").ToString(),//"F01",
                    TEXT_LINE = "Vendor : " + request.Toko + " ," + Environment.NewLine + "Nomor Vendor : " + request.OTV + " ," + Environment.NewLine + "Shipping To : " + request.DeliveryName //Nama Vendor \n Nomor Vendor \n Shipping To
                };

                //var pmlen = Convert.ToInt32((System.Configuration.ConfigurationManager.AppSettings["PMNAME_LENGTH"] ?? "10").ToString());

                param.POADDRVENDOR = new PO_Services2.dt_po_requestPO_DETAILSPOADDRVENDOR()
                {
                    CITY = request.VendorCity,
                    COUNTRY = request.VendorCountryID,
                    FAX_NUMBER = "",
                    HOUSE_NO = request.VendorHouseNumber,
                    NAME = (request.PMName.Length > 20) ? request.PMName.Substring(0, 20 - 1) : request.PMName,
                    NAME_2 = "",
                    POSTL_COD1 = request.VendorPostalCode,
                    STREET = request.VendorStreetHouse,
                    TEL1_NUMBR = ""
                };

                param.ITEMS = new PO_Services2.dt_po_requestPO_DETAILSITEMS[request.MaterialItems.Count];

                for (int i = 0; i < param.ITEMS.Length; i++)
                {
                    var nr = new PO_Services2.dt_po_requestPO_DETAILSITEMS()
                    {
                        EBELP = request.MaterialItems[i].SeqItem,

                        //kosongan
                        DELETE_IND = "",
                        PSTYP = "",
                        LGORT = "",
                        PEINH = "",
                        BPRME = "",
                        WEUNB = "",
                        WEPOS = "",
                        ELIKZ = "",
                        EREKZ = "",
                        KONNR = request.MaterialItems[i].SAPKONNR, //no kontrak
                        KTPNR = request.MaterialItems[i].SAPKTPNR, //no kontrak item
                        PCKG_NO = "",
                        LEBRE = "",
                        PREQ_ITEM = request.MaterialItems[i].PRItem,
                        PREQ_NO = request.MaterialItems[i].PRNumber,
                        DISTRIB = "",


                        //

                        KNTTP = request.SAPKNTTP,
                        MWSKZ = request.TaxType ?? "",
                        MATNR = request.MaterialItems[i].MATNR,
                        WERKS = request.SAPWERKS,
                        MATKL = request.MaterialItems[i].MATType,
                        TXZ01 = request.MaterialItems[i].MATDesc,
                        MENGE = request.MaterialItems[i].Actual_Qty,
                        MEINS = request.MaterialItems[i].UoM,
                        NETPR = request.MaterialItems[i].HargaSatuan,
                        REPOS = request.SAPREPOS,
                        WEBRE = request.SAPWEBRE,
                        AFNAM = (request.Username.Length > 10) ? request.Username.Substring(0, 9) : request.Username,
                        ADDRDELIVERY = new PO_Services2.dt_po_requestPO_DETAILSITEMSADDRDELIVERY[1]
                        {
                            new PO_Services2.dt_po_requestPO_DETAILSITEMSADDRDELIVERY()
                            {
                                ADDR_NO = request.DeliveryHouseNumber,
                                NAME1 = request.DeliveryName,
                                NAME2 = "",
                                CITY1 = request.DeliveryCity,
                                POST_CODE1 = request.DeliveryPostalCode,
                                STREET = request.DeliveryStreetHouse,
                                HOUSE_NUM1 = request.DeliveryHouseNumber,
                                LAND1 = "",
                                REGION = ""
                            }
                        },
                        ITEMTEXT = new PO_Services2.dt_po_requestPO_DETAILSITEMSITEMTEXT[1]
                        {
                            new PO_Services2.dt_po_requestPO_DETAILSITEMSITEMTEXT()
                            {
                                TEXT_ID = (System.Configuration.ConfigurationManager.AppSettings["TEXT_ID"]??"F01").ToString(),
                                TEXT_LINE = request.MaterialItems[i].MATDescDetail
                            }
                        },

                        SCHEDULE = new PO_Services2.dt_po_requestPO_DETAILSITEMSSCHEDULE[1]
                        {
                            new PO_Services2.dt_po_requestPO_DETAILSITEMSSCHEDULE()
                            {
                                //ETENR = (i+1).ToString(),// data.MaterialItems[i].SeqItem.ToString(),
                                ETENR = "1", //Fixing Double Qty in PO Items
                                EINDT = request.SAPEINDT,
                                QUANTITY = request.MaterialItems[i].Actual_Qty.ToString(),
                                BANFN = "",
                                BNFPO = "",
                                DELETE_IND = ""
                            }
                        },
                        ACCNTASSIGNMENT = new PO_Services2.dt_po_requestPO_DETAILSITEMSACCNTASSIGNMENT[1]
                        {
                            new PO_Services2.dt_po_requestPO_DETAILSITEMSACCNTASSIGNMENT()
                            {
                                ZEKKN = request.SAPZEKKN,//data.MaterialItems[0].SeqItem.ToString(),
                                SAKTO = request.SAPSAKTO,
                                PS_PSP_PNR = request.WBS_Lv_ID,
                                AUFNR = request.OrderID,
                                DELETE_IND = "",
                                FIPOS = "",
                                FISTL = "",
                                KOSTL = "",
                                MENGE = "",
                                NPLNR = "",
                                VPROZ = ""
                            }
                        },
                        CONDITIONTYPE = new PO_Services2.dt_po_requestPO_DETAILSITEMSCONDITIONTYPE[1]
                        {
                            new PO_Services2.dt_po_requestPO_DETAILSITEMSCONDITIONTYPE()
                            {
                                STUNR = "",
                                DZAEHK = "",
                                KSCHL = "",
                                KBETR = "",
                                WAERS = "",
                                LIFNR = "",
                                CHANGE_ID = ""
                            }
                        },

                    };

                    param.ITEMS[i] = nr;
                }

                param.LIMITS = new PO_Services2.dt_po_requestPO_DETAILSLIMITS[1]
                {
                    new PO_Services2.dt_po_requestPO_DETAILSLIMITS()
                    {
                        PACKNO = "",
                        SUMLIMIT = "",
                        SUMNOLIM = "",
                        COMMITMENT = ""
                    }
                };

                param.SERVICE = new PO_Services2.dt_po_requestPO_DETAILSSERVICE[1]
                {
                    new PO_Services2.dt_po_requestPO_DETAILSSERVICE()
                    {
                        PACKNO_EXT = "",
                        INTROW_EXT = "",
                        EXTROW = "",
                        OUTL_IND = "",
                        SUB_PACKNO = "",
                        SRVPOS = "",
                        DEL_IND = "",
                        MENGE = "",
                        MEINS = "",
                        PEINH = "",
                        BRTWR = "",
                        TXZ01 = "",
                        PLN_PACKNO  = "",
                        PLN_INTROW = "",
                        DISTRIB = ""
                    }
                };

                param.POSRVACCESSVALUES = new PO_Services2.dt_po_requestPO_DETAILSPOSRVACCESSVALUES[1]
                {
                    new PO_Services2.dt_po_requestPO_DETAILSPOSRVACCESSVALUES()
                    {
                        PACKNO = "",
                        INTROW = "",
                        NUMKN = "",
                        ZEKKN = "",
                        MENGE = "",
                        WPROZ = ""
                    }
                };

                poparams[0] = param;

                System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential(
                                                                    System.Configuration.ConfigurationManager.AppSettings["SAPUserName"].ToString(),
                                                                    System.Configuration.ConfigurationManager.AppSettings["SAPPassword"].ToString()
                                                                    );

                var svcObj = new PO_Services2.mi_os_poService();

                svcObj.Credentials = networkCredential;

                PO_Services2.dt_po_responsePO_DETAILS[] retval;

                try
                {

                    XmlSerializer xsSubmit = new XmlSerializer(poparams.GetType());

                    using (var sww = new StringWriter())
                    {
                        using (XmlWriter writer = XmlWriter.Create(sww))
                        {
                            xsSubmit.Serialize(writer, poparams);
                            xmlPo = sww.ToString(); // Your XML
                        }
                    }

                    //insert log request
                    var json = new JavaScriptSerializer().Serialize(poparams);
                    await log.InsertLogToService(request.Username, "Request Create PO", json.ToString(), xmlPo);

                    retval = svcObj.mi_os_po(poparams);
                    
                    //insert log response
                    var jsonRes = new JavaScriptSerializer().Serialize(retval);
                    await log.InsertLogToService(request.Username, "Response Create PO", jsonRes.ToString(), "");

                    //simulate success
                    if (request.TypeAction == "X" && retval[0].TYPE == "" && retval[0].MESSAGE == "")
                    {
                        result.ResponseCode = "00";
                        result.ResponseMessages = "Simulate Test Create PO Successfully";

                        return result;
                    }

                    if (retval[0].TYPE != System.Configuration.ConfigurationManager.AppSettings["SuccessKey"].ToString())
                    {
                        result.ResponseCode = "20";
                        result.ResponseMessages = "Create PO Failed " + retval[0].MESSAGE + Environment.NewLine;

                        

                        log.Type = "E";
                        log.ErrorMessage = "Create PO Failed " + retval[0].MESSAGE + " " + xmlPo;

                        foreach (var item in retval[0].MSG_DETAILS)
                        {
                            if (item.TYPE == "E")
                            {
                                log.ErrorMessage += "; " + item.MSG_DET;
                                result.ResponseMessages += item.MSG_DET + "; " + Environment.NewLine;
                            }
                        }

                        log.InsertLog(log.ErrorMessage);

                        return result;
                    }
                    else
                    {
                        List<CreatePOResponse> lstRespCreatePO = new List<CreatePOResponse>();
                        CreatePOResponse data = new CreatePOResponse();
                        data.PONumber = retval[0].EBELN;
                        data.MANDT = retval[0].MANDT;
                        data.EBELN_EXT = retval[0].EBELN_EXT;
                        data.EBELN = retval[0].EBELN;
                        data.FRGKE = retval[0].FRGKE;
                        data.COMM_FLAG = retval[0].COMM_FLAG;
                        data.TYPE = retval[0].TYPE;
                        data.MESSAGE = retval[0].MESSAGE;
                        lstRespCreatePO.Add(data);

                        result.ResponseCode = "00";
                        result.ResponseMessages = "Create PO Successfully." + retval[0].MESSAGE;
                        result.ResponseData = lstRespCreatePO;
                    }

                }
                catch (SoapException e)
                {
                    result.ResponseCode = "99";
                    result.ResponseMessages = "Create PO Failed " + e.Message + e.Detail.InnerText;
                    
                    log.Type = "E";
                    log.ErrorMessage = "Create PO Failed " + e.Message + " " + e.Detail.InnerText + " " + xmlPo + " " + e.StackTrace;

                    log.InsertLog(log.ErrorMessage);

                    return result;
                }
                catch (Exception e)
                {
                    result.ResponseCode = "99";
                    result.ResponseMessages = "Create PO Failed " + e.Message;
                    
                    log.Type = "E";
                    log.ErrorMessage = "Create PO Failed " + e.Message + " " + xmlPo + " " + e.StackTrace;

                    log.InsertLog(log.ErrorMessage);

                    return result;
                }

                return result;
            }
            catch (Exception ex)
            {
                var final = new GeneralActionResponse<CreatePOResponse>()
                {
                    ResponseCode = "99",
                    ResponseMessages = "Error Exception : " + ex.Message.ToString()
                };

                return final;
            }
        }
    }
}