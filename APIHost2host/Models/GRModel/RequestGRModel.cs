using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APIHost2host.Models.Master;
using APIHost2host.Models.AppFrameworks;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using APIHost2Host.Helper;
using APIHost2host.Models.Response;
using System.Web.Services.Protocols;
using System.Web.Script.Serialization;

namespace APIHost2host.Models.GRModel
{
    public class RequestGR
    {
        public string TypeAction { get; set; } //type action digunakan untuk proses simulate (X) atau posting (string.empty)
        public string OPType { get; set; }
        public string CustGR { get; set; }
        public string PoEBELN { get; set; }
        public string MANDT { get; set; }
        public string ZDEL { get; set; }
        public string BWART { get; set; }
        public string WERKS { get; set; }
        public string ITEMINDICATOR { get; set; }
        public string BLDAT { get; set; }
        public string BUDAT { get; set; }
        public string TGLDELIVER { get; set; }
        public List<MaterialItem> MaterialItems { get; set; }

        public static async System.Threading.Tasks.Task<GeneralActionResponse<CreateGRResponse>> createGRAsync(RequestGR request)
        {
            LogModel log = new LogModel();

            try {
                var result = new GeneralActionResponse<CreateGRResponse>();

                var xmlGr = "";
                var svcGr = new GR_Services.mi_os_gr_pipsService();

                System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential(
                                                                                System.Configuration.ConfigurationManager.AppSettings["SAPUserName"].ToString(), 
                                                                                System.Configuration.ConfigurationManager.AppSettings["SAPPassword"].ToString());

                svcGr.Credentials = networkCredential;
                
                var grparams = new GR_Services.dt_gr_requestGR_DETAILS[1]
                {
                    new GR_Services.dt_gr_requestGR_DETAILS()
                    {
                        MANDT = request.MANDT,
                        OPTYPE = request.OPType,
                        MBLNR_EXT = request.CustGR,
                        BLDAT = request.BLDAT,
                        BUDAT = request.BUDAT,
                        BKTXT = "",
                        FRBNR = "",
                        LFSNR = "",
                        MBLNR = "",
                        MJAHR = "",
                        TESTRUN = request.TypeAction,
                        TGLDELIVER = request.TGLDELIVER,
                        TKDN = "",
                        ZDEL = request.ZDEL,
                        ZJUSTIFIKASI = "",
                        ZMULTIPLIER = ""
                    }
                };

                grparams[0].ITEMS = new GR_Services.dt_gr_requestGR_DETAILSITEMS[request.MaterialItems.Count];


                for (int i = 0; i < request.MaterialItems.Count; i++)
                {
                    var nr = new GR_Services.dt_gr_requestGR_DETAILSITEMS()
                    {
                        EBELN = request.PoEBELN,
                        EBELP = (i + 1).ToString(),
                        ERFMG = request.MaterialItems[i].Actual_Qty.ToString(),
                        ERFME = request.MaterialItems[i].UoM,
                        BWART = request.BWART,
                        WERKS = request.WERKS,
                        SGTXT = request.MaterialItems[i].MATDesc,
                        ITEMINDICATOR = request.ITEMINDICATOR,

                        ABLAD = "",
                        ELIKZ = "",
                        INSMK = "",
                        KOSTL = "",
                        LGORT = "",
                        LSMNG = "",
                        MATNR = request.MaterialItems[i].MATNR,
                        PRCTR = "",
                        REF_DOC = "",
                        REF_DOC_YR = "",
                        REF_DOC_IT = "",
                        WEMPF = ""

                    };

                    grparams[0].ITEMS[i] = nr;

                }

                //svcGr.Credentials = new System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["XICredUser"].ToString(), System.Configuration.ConfigurationManager.AppSettings["XICredPass"].ToString());

                GR_Services.dt_gr_responseGR_DETAILS[] retvalGr;

                try
                {
                    XmlSerializer xsSubmit = new XmlSerializer(grparams.GetType());

                    using (var sww = new StringWriter())
                    {
                        using (XmlWriter writer = XmlWriter.Create(sww))
                        {
                            xsSubmit.Serialize(writer, grparams);
                            xmlGr = sww.ToString(); // Your XML
                        }
                    }

                    //insert log request
                    var json = new JavaScriptSerializer().Serialize(grparams);
                    await log.InsertLogToService(request.CustGR, "Request Create GR", json.ToString(), xmlGr);

                    retvalGr = svcGr.mi_os_gr_pips(grparams);

                    //insert log response
                    var jsonRes = new JavaScriptSerializer().Serialize(retvalGr);
                    await log.InsertLogToService(request.CustGR, "Response Create GR", jsonRes.ToString(), "");

                    if (retvalGr[0].TYPE != System.Configuration.ConfigurationManager.AppSettings["SuccessKey"].ToString())
                    {
                        result.ResponseCode = "20";
                        result.ResponseMessages = "Create GR Failed " + retvalGr[0].MESSAGE;

                        log = new LogModel();

                        log.Type = "E";
                        log.ErrorMessage = "Create GR Failed " + retvalGr[0].MESSAGE + " " + grparams.ToJson();

                        foreach (var item in retvalGr[0].MSG_DETAILS)
                        {
                            if (item.TYPE == "E")
                            {
                                log.ErrorMessage += "; " + item.MSG_DET;
                            }
                        }

                        log.InsertLog(log.ErrorMessage);

                        return result;
                    }
                    else
                    {
                        //success generate GR
                        List<CreateGRResponse> lstResponseGR = new List<CreateGRResponse>();
                        CreateGRResponse data = new CreateGRResponse();
                        data.GRNumber = retvalGr[0].MBLNR;
                        data.MANDT = retvalGr[0].MANDT;
                        data.MBLNR = retvalGr[0].MBLNR;
                        data.MBLNR_EXT = retvalGr[0].MBLNR_EXT;
                        lstResponseGR.Add(data);

                        result.ResponseCode = "00";
                        result.ResponseMessages = "Create GR Successfully. " + retvalGr[0].MESSAGE;
                        result.ResponseData = lstResponseGR;
                    }

                }
                catch (SoapException e)
                {
                    result.ResponseCode = "99";
                    result.ResponseMessages = "Create GR Failed " + e.Message + e.Detail.InnerText;

                    log = new LogModel();

                    log.Type = "E";
                    log.ErrorMessage = "Create GR Failed " + e.Message + e.Detail.InnerText + " " + grparams.ToJson() + " " + e.StackTrace;

                    log.InsertLog(log.ErrorMessage);

                    return result;
                }
                catch (Exception e)
                {
                    result.ResponseCode = "99";
                    result.ResponseMessages = "Create GR Failed " + e.GetBaseException().Message;

                    log = new LogModel();

                    log.Type = "E";
                    log.ErrorMessage = "Create GR Failed " + e.Message + " " + grparams.ToJson() + " " + e.StackTrace;

                    log.InsertLog(log.ErrorMessage);

                    return result;
                }

                return result;
            }
            catch (Exception ex)
            {
                var final = new GeneralActionResponse<CreateGRResponse>()
                {
                    ResponseCode = "99",
                    ResponseMessages = "Error Exception : " + ex.Message.ToString()
                };

                return final;
            }
        }        
    }
}