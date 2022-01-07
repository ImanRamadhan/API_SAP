using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Net;
using APIHost2host.Models.AppFrameworks;
using APIHost2host.Models.Response;
using APIHost2host.PR_InqServices;

namespace APIHost2host.Models.PRModel
{
    public class InquiryREQ
    {
        public static GeneralActionResponse<PRReqResponse> inquiryREQ(GeneralActionResponse<PRReqResponse> paging, string PRNumber)
        {
            try {
                var poparams = new dt_GetPR_RequestPR_DETAILS[1];

                var client = new mi_os_GetPRService();

                NetworkCredential networkCredential = new NetworkCredential(ConfigurationManager.AppSettings["SAPUserName"].ToString(),
                                                                            ConfigurationManager.AppSettings["SAPPassword"].ToString());
                client.Credentials = networkCredential;

                var @params = new dt_GetPR_RequestPR_DETAILS();

                @params.CLIENT = ConfigurationManager.AppSettings["SAPClient"];
                @params.PREQ_NO = PRNumber;

                poparams[0] = @params;

                var final = new GeneralActionResponse<PRReqResponse>()
                {
                    TotalRow = 0,
                    ResponseCode = "05",
                    ResponseMessages = "PR Number Not Found!"
                };

                var sapResult = client.mi_os_GetPR(poparams);

                List<PRReqResponse> lstInquiryReq = new List<PRReqResponse>();

                if (!sapResult[0].PREQ_NO.Equals("")) {
                    //mapping object for response sap inquiry PR
                    PRReqResponse data = new PRReqResponse();
                    data.PREQ_NO = sapResult[0].PREQ_NO;
                    data.PR_TYPE = sapResult[0].PR_TYPE;
                    

                    if (sapResult[0].PRITEM != null)
                    {
                        data.PREQ_NAME = sapResult[0].PRITEM[0].PREQ_NAME;
                        data.ZZMMAUTHNAME = sapResult[0].PRITEM[0].ZZMMAUTHNAME;
                        data.ZZMMAUTHPOS = sapResult[0].PRITEM[0].ZZMMAUTHPOS;
                        int grandTotal = 0;
                        if (sapResult[0].PRITEM.Count() > 0)
                        {
                            List<PRReqItem> lstDataPRI = new List<PRReqItem>();
                            var PRItem = sapResult[0].PRITEM;
                            for (int i = 0; i < PRItem.Count(); i++ )
                            {
                                PRReqItem dataPRI = new PRReqItem();
                                string[] qty = PRItem[i].QUANTITY.Split('.');
                                string[] price = PRItem[i].PREQ_PRICE.Split('.');
                                int total = 0;

                                dataPRI.QUANTITY = qty[0];
                                dataPRI.PREQ_PRICE = price[0];
                                
                                total = int.Parse(dataPRI.QUANTITY) * int.Parse(dataPRI.PREQ_PRICE);
                                dataPRI.TOTAL_PRICE = total.ToString();
                                grandTotal += total;
                                lstDataPRI.Add(dataPRI);

                            }
                            data.GRAND_TOTAL = grandTotal.ToString(); 
                            data.PR_REQ_ITEM = lstDataPRI;
                        }
                    }

                    lstInquiryReq.Add(data);

                    final = new GeneralActionResponse<PRReqResponse>()
                    {
                        TotalRow = lstInquiryReq.Count(),
                        ResponseCode = "00",
                        ResponseMessages = "Inquiry Requisitioner Successfully..",
                    };

                }

                final.SetRecords(lstInquiryReq);

                return final;
            }
            catch (Exception ex)
            {
                var final = new GeneralActionResponse<PRReqResponse>()
                {
                    TotalRow = 0,
                    ResponseCode = "99",
                    ResponseMessages = "Error Exception : " + ex.Message.ToString()
                };

                return final;
            }
        }
    }
}