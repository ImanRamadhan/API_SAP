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
    public class InquiryPR
    {
        public static GeneralActionResponse<InquiryPRResponse> inquiryPR(GeneralActionResponse<InquiryPRResponse> paging, string PRNumber)
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

                var final = new GeneralActionResponse<InquiryPRResponse>()
                {
                    TotalRow = 0,
                    ResponseCode = "05",
                    ResponseMessages = "PR Number Not Found!"
                };

                var sapResult = client.mi_os_GetPR(poparams);

                List<InquiryPRResponse> lstInquiryPR = new List<InquiryPRResponse>();

                if (!sapResult[0].PREQ_NO.Equals("")) {
                    //mapping object for response sap inquiry PR
                    InquiryPRResponse data = new InquiryPRResponse();
                    data.PREQ_NO = sapResult[0].PREQ_NO;
                    data.PR_TYPE = sapResult[0].PR_TYPE;

                    if (sapResult[0].PRHEADERTEXT != null)
                    { 
                        if (sapResult[0].PRHEADERTEXT.Count() > 0)
                        {
                            List<PRHeaderText> lstDataPRHT = new List<PRHeaderText>();
                            foreach (var PRHeaderT in sapResult[0].PRHEADERTEXT)
                            {
                                PRHeaderText dataPRHT = new PRHeaderText();
                                dataPRHT.TEXT_ID = PRHeaderT.TEXT_ID;
                                dataPRHT.TEXT_FORM = PRHeaderT.TEXT_FORM;
                                dataPRHT.TEXT_LINE = PRHeaderT.TEXT_LINE;

                                lstDataPRHT.Add(dataPRHT);
                            }
                            data.PRHEADERTEXT = lstDataPRHT;
                        }
                    }

                    if (sapResult[0].PRITEM != null)
                    {
                        if (sapResult[0].PRITEM.Count() > 0)
                        {
                            List<PRItem> lstDataPRI = new List<PRItem>();
                            foreach (var PRItem in sapResult[0].PRITEM)
                            {
                                PRItem dataPRI = new PRItem();
                                dataPRI.PREQ_ITEM = PRItem.PREQ_ITEM;
                                dataPRI.MATERIAL = PRItem.MATERIAL;
                                dataPRI.SHORT_TEXT = PRItem.SHORT_TEXT;
                                dataPRI.QUANTITY = PRItem.QUANTITY;
                                dataPRI.UNIT = PRItem.UNIT;
                                dataPRI.PREQ_PRICE = PRItem.PREQ_PRICE;
                                dataPRI.CURRENCY = PRItem.CURRENCY;
                                dataPRI.PRICE_UNIT = PRItem.PRICE_UNIT;
                                dataPRI.PLANT = PRItem.PLANT;
                                dataPRI.PUR_GROUP = PRItem.PUR_GROUP;
                                dataPRI.PREQ_DATE = PRItem.PREQ_DATE;
                                dataPRI.DELIV_DATE = PRItem.DELIV_DATE;
                                dataPRI.PREQ_NAME = PRItem.PREQ_NAME;
                                dataPRI.REL_IND = PRItem.REL_IND;
                                dataPRI.REL_STATUS = PRItem.REL_STATUS;
                                dataPRI.ITEM_CAT = PRItem.ITEM_CAT;
                                dataPRI.PURCH_ORG = PRItem.PURCH_ORG;
                                dataPRI.AGREEMENT = PRItem.AGREEMENT;
                                dataPRI.AGMT_ITEM = PRItem.AGMT_ITEM;
                                dataPRI.VALUE_ITEM = PRItem.VALUE_ITEM;
                                dataPRI.ZZMMAUTHNAME = PRItem.ZZMMAUTHNAME;
                                dataPRI.ZZMMAUTHPOS = PRItem.ZZMMAUTHPOS;
                                List<PRItemText> lstPRIT = new List<PRItemText>();
                                if (PRItem.PRITEMTEXT != null)
                                {
                                    foreach (var dtPRItemText in PRItem.PRITEMTEXT)
                                    {
                                        PRItemText dataPRIT = new PRItemText();
                                        dataPRIT.TEXT_ID = dtPRItemText.TEXT_ID;
                                        dataPRIT.TEXT_FORM = dtPRItemText.TEXT_FORM;
                                        dataPRIT.TEXT_LINE = dtPRItemText.TEXT_LINE;

                                        lstPRIT.Add(dataPRIT);
                                    }
                                }
                                dataPRI.PRITEMTEXT = lstPRIT;

                                List<PRAccount> lstACCOUNT = new List<PRAccount>();
                                if (PRItem.PRACCOUNT != null)
                                {
                                    foreach (var dtAccount in PRItem.PRACCOUNT)
                                    {
                                        PRAccount dataAccount = new PRAccount();
                                        dataAccount.COSTCENTER = dtAccount.COSTCENTER;
                                        dataAccount.GL_ACCOUNT = dtAccount.GL_ACCOUNT;
                                        dataAccount.ORDERID = dtAccount.ORDERID;
                                        dataAccount.WBS_ELEMENT = dtAccount.WBS_ELEMENT;

                                        lstACCOUNT.Add(dataAccount);
                                    }
                                }
                                dataPRI.PRACCOUNT = lstACCOUNT;

                                List<PRAddressDelivery> lstAddrDeliv = new List<PRAddressDelivery>();
                                if (PRItem.PRADDRDELIVERY != null)
                                {
                                    foreach (var dtAddrDelive in PRItem.PRADDRDELIVERY)
                                    {
                                        PRAddressDelivery dataAddrDev = new PRAddressDelivery();
                                        dataAddrDev.NAME = dtAddrDelive.NAME;
                                        dataAddrDev.STREET = dtAddrDelive.STREET;
                                        dataAddrDev.HOUSE_NO = dtAddrDelive.HOUSE_NO;
                                        dataAddrDev.CITY = dtAddrDelive.CITY;

                                        lstAddrDeliv.Add(dataAddrDev);
                                    }
                                }
                                dataPRI.PRADDRDELIVERY = lstAddrDeliv;

                                lstDataPRI.Add(dataPRI);
                            }
                            data.PRITEM = lstDataPRI;
                        }
                    }

                    lstInquiryPR.Add(data);

                    final = new GeneralActionResponse<InquiryPRResponse>()
                    {
                        TotalRow = lstInquiryPR.Count(),
                        ResponseCode = "00",
                        ResponseMessages = "Inquiry PR Successfully..",
                    };

                }

                final.SetRecords(lstInquiryPR);

                return final;
            }
            catch (Exception ex)
            {
                var final = new GeneralActionResponse<InquiryPRResponse>()
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