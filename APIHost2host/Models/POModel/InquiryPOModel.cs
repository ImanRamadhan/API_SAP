using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using APIHost2host.Models.AppFrameworks;
using APIHost2host.Models.Response;
using APIHost2host.PO_InqServices;

namespace APIHost2host.Models.POModel
{
    public class InquiryPO
    {
        public static GeneralActionResponse<InquiryPOResponse> inquiryPO(GeneralActionResponse<InquiryPOResponse> paging, string PONumber)
        {
            try { 
                var poparams = new dt_GetPO_RequestPO_DETAILS[1];

                var client = new mi_os_GetPOService();

                NetworkCredential networkCredential = new NetworkCredential(ConfigurationManager.AppSettings["SAPUserName"].ToString(),
                                                                            ConfigurationManager.AppSettings["SAPPassword"].ToString());
                client.Credentials = networkCredential;

                var @params = new dt_GetPO_RequestPO_DETAILS();

                @params.CLIENT = ConfigurationManager.AppSettings["SAPClient"];
                @params.PO_NUMBER = PONumber;

                poparams[0] = @params;

                var final = new GeneralActionResponse<InquiryPOResponse>()
                {
                    TotalRow = 0,
                    ResponseCode = "05",
                    ResponseMessages = "PO Number Not Found!"
                };

                var sapResult = client.mi_os_GetPO(poparams);

                List<InquiryPOResponse> lstInquiryPO = new List<InquiryPOResponse>();

                if (!sapResult[0].PO_NUMBER.Equals(""))
                {
                    //mapping object for response sap inquiry PO
                    InquiryPOResponse data = new InquiryPOResponse();
                    data.PO_NUMBER = sapResult[0].PO_NUMBER;
                    data.DOC_TYPE = sapResult[0].DOC_TYPE;
                    data.DOC_DATE = sapResult[0].DOC_DATE;
                    data.VENDOR = sapResult[0].VENDOR;
                    data.CURRENCY = sapResult[0].CURRENCY;
                    data.PUR_GROUP = sapResult[0].PUR_GROUP;
                    data.PURCH_ORG = sapResult[0].PURCH_ORG;
                    data.PMNTTRMS = sapResult[0].PMNTTRMS;
                    data.INCOTERMS1 = sapResult[0].INCOTERMS1;
                    data.INCOTERMS2 = sapResult[0].INCOTERMS2;
                    data.EXCH_RATE = sapResult[0].EXCH_RATE;
                    data.REL_IND = sapResult[0].REL_IND;
                    data.REL_STATUS = sapResult[0].REL_STATUS;
                    data.ZZMMMULTIPLIER = sapResult[0].ZZMMMULTIPLIER;
                    data.ZZMMAFE = sapResult[0].ZZMMAFE;
                    data.ZZMMTKDN = sapResult[0].ZZMMTKDN;
                    data.ZZMMAUTHNAME = sapResult[0].ZZMMAUTHNAME;
                    data.ZZMMAUTHPOS = sapResult[0].ZZMMAUTHPOS;
                    data.ZZMMPYMMTD = sapResult[0].ZZMMPYMMTD;
                    data.ZZMMSPMK = sapResult[0].ZZMMSPMK;
                    data.ZZMMNILBIAYA = sapResult[0].ZZMMNILBIAYA;
                    data.ZZMMPENAWAL = sapResult[0].ZZMMPENAWAL;
                    data.ZZIP2P_OWNEREST = sapResult[0].ZZIP2P_OWNEREST;
                    data.ZZHSERISK = sapResult[0].ZZHSERISK;
                    data.ZZMMBIDLIST = sapResult[0].ZZMMBIDLIST;
                    data.ZZSUBID = sapResult[0].ZZSUBID;
                    data.ZZMMKOMODITAS = sapResult[0].ZZMMKOMODITAS;
                    data.ZZMMPROCLIST = sapResult[0].ZZMMPROCLIST;
                    data.ZZMMPROCLISTI = sapResult[0].ZZMMPROCLISTI;

                    if (sapResult[0].POITEM.Count() > 0)
                    {
                        List<POItem> lstDataPOItem = new List<POItem>();
                        foreach (var POItem in sapResult[0].POITEM)
                        {
                            POItem dataPOItem = new POItem();
                            dataPOItem.PO_ITEM = POItem.PO_ITEM;
                            dataPOItem.MATERIAL = POItem.MATERIAL;
                            dataPOItem.SHORT_TEXT = POItem.SHORT_TEXT;
                            dataPOItem.QUANTITY = POItem.QUANTITY;
                            dataPOItem.UNIT = POItem.UNIT;
                            dataPOItem.NET_PRICE = POItem.NET_PRICE;
                            dataPOItem.PRICE_UNIT = POItem.PRICE_UNIT;
                            dataPOItem.PLANT = POItem.PLANT;
                            dataPOItem.PREQ_NO = POItem.PREQ_NO;
                            dataPOItem.PREQ_ITEM = POItem.PREQ_ITEM;
                            dataPOItem.RFQ = POItem.RFQ;
                            dataPOItem.RFQ_ITEM = POItem.RFQ_ITEM;
                            dataPOItem.PREQ_NAME = POItem.PREQ_NAME;
                            dataPOItem.ITEM_CAT = POItem.ITEM_CAT;
                            dataPOItem.ACCTASSCAT = POItem.ACCTASSCAT;
                            dataPOItem.MAT_GRP = POItem.MAT_GRP;
                            dataPOItem.STORE_LOC = POItem.STORE_LOC;
                            dataPOItem.BATCH = POItem.BATCH;
                            dataPOItem.AGREEMENT = POItem.AGREEMENT;
                            dataPOItem.AGMT_ITEM = POItem.AGMT_ITEM;
                            dataPOItem.OVERDELTOL = POItem.OVERDELTOL;
                            dataPOItem.UNDER_TOL = POItem.UNDER_TOL;
                            dataPOItem.UNLIMITED = POItem.UNLIMITED;
                            dataPOItem.GR_IND = POItem.GR_IND;
                            dataPOItem.GR_NON_VAL = POItem.GR_NON_VAL;
                            dataPOItem.NO_MORE_GR = POItem.NO_MORE_GR;
                            dataPOItem.IR_IND = POItem.IR_IND;
                            dataPOItem.FINAL_INV = POItem.FINAL_INV;
                            dataPOItem.GR_BASEDIV = POItem.GR_BASEDIV;
                            dataPOItem.PART_INV = POItem.PART_INV;
                            dataPOItem.TAX_CODE = POItem.TAX_CODE;
                            dataPOItem.PCKG_NO = POItem.PCKG_NO;
                            dataPOItem.DISTRIB = POItem.DISTRIB;

                            if (POItem.POTEXTITEM != null)
                            { 
                                if (POItem.POTEXTITEM.Count() > 0)
                                {
                                    List<POTextItem> lstDataPOTextItem = new List<POTextItem>();
                                    foreach (var POTextItem in POItem.POTEXTITEM)
                                    {
                                        POTextItem poTextItem = new POTextItem();
                                        poTextItem.TEXT_ID = POTextItem.TEXT_ID;
                                        poTextItem.TEXT_FORM = POTextItem.TEXT_FORM;
                                        poTextItem.TEXT_LINE = POTextItem.TEXT_LINE;

                                        lstDataPOTextItem.Add(poTextItem);
                                    }
                                    dataPOItem.POTEXTITEM = lstDataPOTextItem;
                                }
                            }

                            if (POItem.POACCOUNT != null)
                            { 
                                if (POItem.POACCOUNT.Count() > 0)
                                {
                                    List<POAccount> lstDataPOAccount = new List<POAccount>();
                                    foreach (var POAccount in POItem.POACCOUNT)
                                    {
                                        POAccount poAccount = new POAccount();
                                        poAccount.SERIAL_NO = POAccount.SERIAL_NO;
                                        poAccount.G_L_ACCT = POAccount.G_L_ACCT;
                                        poAccount.COST_CTR = POAccount.COST_CTR;
                                        poAccount.ORDER_NO = POAccount.ORDER_NO;
                                        poAccount.WBS_ELEM_E = POAccount.WBS_ELEM_E;
                                        poAccount.NETWORK = POAccount.NETWORK;
                                        poAccount.ACTIVITY = POAccount.ACTIVITY;
                                        poAccount.CMMT_ITEM_LONG = POAccount.CMMT_ITEM_LONG;
                                        poAccount.ASSET_NO = POAccount.ASSET_NO;
                                        poAccount.QUANTITY = POAccount.QUANTITY;
                                        poAccount.DISTR_PERC = POAccount.DISTR_PERC;

                                        lstDataPOAccount.Add(poAccount);
                                    }
                                    dataPOItem.POACCOUNT = lstDataPOAccount;
                                }
                            }

                            if (POItem.POSCHEDULE != null)
                            { 
                                if (POItem.POSCHEDULE.Count() > 0)
                                {
                                    List<POSchedule> lstDataPOSchedule = new List<POSchedule>();
                                    foreach (var POSchedule in POItem.POSCHEDULE)
                                    {
                                        POSchedule poSchedule = new POSchedule();
                                        poSchedule.DELIV_DATE = POSchedule.DELIV_DATE;

                                        lstDataPOSchedule.Add(poSchedule);
                                    }
                                    dataPOItem.POSCHEDULE = lstDataPOSchedule;
                                }
                            }

                            if (POItem.POADDRDELIVERY != null)
                            { 
                                if (POItem.POADDRDELIVERY.Count() > 0)
                                {
                                    List<POAddressDelivery> lstDataPOAddrDeliv = new List<POAddressDelivery>();
                                    foreach (var POAddressDeliv in POItem.POADDRDELIVERY)
                                    {
                                        POAddressDelivery poAddressDeliv = new POAddressDelivery();
                                        poAddressDeliv.NAME = POAddressDeliv.NAME;
                                        poAddressDeliv.NAME_2 = POAddressDeliv.NAME_2;
                                        poAddressDeliv.STREET = POAddressDeliv.STREET;
                                        poAddressDeliv.HOUSE_NO = POAddressDeliv.HOUSE_NO;
                                        poAddressDeliv.CITY = POAddressDeliv.CITY;
                                        poAddressDeliv.POSTL_COD1 = POAddressDeliv.POSTL_COD1;

                                        lstDataPOAddrDeliv.Add(poAddressDeliv);
                                    }
                                    dataPOItem.POADDRDELIVERY = lstDataPOAddrDeliv;
                                }
                            }

                            if (POItem.POLIMITS != null)
                            { 
                                if (POItem.POLIMITS.Count() > 0)
                                {
                                    List<POLimits> lstDataPOLimits = new List<POLimits>();
                                    foreach (var POLimits in POItem.POLIMITS)
                                    {
                                        POLimits poLimits = new POLimits();
                                        poLimits.PCKG_NO = POLimits.PCKG_NO;
                                        poLimits.LIMIT = POLimits.LIMIT;
                                        poLimits.EXP_VALUE = POLimits.EXP_VALUE;
                                        poLimits.NO_LIMIT = POLimits.NO_LIMIT;

                                        lstDataPOLimits.Add(poLimits);
                                    }
                                    dataPOItem.POLIMITS = lstDataPOLimits;
                                }
                            }

                            if (POItem.POSERVICES != null)
                            { 
                                if (POItem.POSERVICES.Count() > 0)
                                {
                                    List<POServices> lstDataPOServices = new List<POServices>();
                                    foreach (var POServices in POItem.POSERVICES)
                                    {
                                        POServices poServices = new POServices();
                                        poServices.PCKG_NO = POServices.PCKG_NO;
                                        poServices.LINE_NO = POServices.LINE_NO;
                                        poServices.EXT_LINE = POServices.EXT_LINE;
                                        poServices.SERVICE = POServices.SERVICE;
                                        poServices.SHORT_TEXT = POServices.SHORT_TEXT;
                                        poServices.QUANTITY = POServices.QUANTITY;
                                        poServices.BASE_UOM = POServices.BASE_UOM;
                                        poServices.GROSS_VAL = POServices.GROSS_VAL;
                                        poServices.PRICE_UNIT = POServices.PRICE_UNIT;
                                        poServices.NET_VALUE = POServices.NET_VALUE;
                                        poServices.DISTRIB = POServices.DISTRIB;

                                        lstDataPOServices.Add(poServices);
                                    }
                                    dataPOItem.POSERVICES = lstDataPOServices;
                                }
                            }

                            if (POItem.POSRVACCESSVALUES != null)
                            { 
                                if (POItem.POSRVACCESSVALUES.Count() > 0)
                                {
                                    List<POServiceAccessValues> lstDataPOSrvAccessValues = new List<POServiceAccessValues>();
                                    foreach (var POSrvAccessValues in POItem.POSRVACCESSVALUES)
                                    {
                                        POServiceAccessValues poSrvAccessValues = new POServiceAccessValues();
                                        poSrvAccessValues.PCKG_NO = POSrvAccessValues.PCKG_NO;
                                        poSrvAccessValues.LINE_NO = POSrvAccessValues.LINE_NO;
                                        poSrvAccessValues.SERNO_LINE = POSrvAccessValues.SERNO_LINE;
                                        poSrvAccessValues.PERCENTAGE = POSrvAccessValues.PERCENTAGE;
                                        poSrvAccessValues.SERIAL_NO = POSrvAccessValues.SERIAL_NO;
                                        poSrvAccessValues.QUANTITY = POSrvAccessValues.QUANTITY;
                                        poSrvAccessValues.NET_VALUE = POSrvAccessValues.NET_VALUE;

                                        lstDataPOSrvAccessValues.Add(poSrvAccessValues);
                                    }
                                    dataPOItem.POSRVACCESSVALUES = lstDataPOSrvAccessValues;
                                }
                            }

                            if (POItem.POSERVICETEXT != null)
                            { 
                                if (POItem.POSERVICETEXT.Count() > 0)
                                {
                                    List<POServiceText> lstDataPOServiceText = new List<POServiceText>();
                                    foreach (var POServiceText in POItem.POSERVICETEXT)
                                    {
                                        POServiceText poServiceText = new POServiceText();
                                        poServiceText.PCKG_NO = POServiceText.PCKG_NO;
                                        poServiceText.LINE_NO = POServiceText.LINE_NO;
                                        poServiceText.TEXT_ID = POServiceText.TEXT_ID;
                                        poServiceText.FORMAT_COL = POServiceText.FORMAT_COL;
                                        poServiceText.TEXT_LINE = POServiceText.TEXT_LINE;

                                        lstDataPOServiceText.Add(poServiceText);
                                    }
                                    dataPOItem.POSERVICETEXT = lstDataPOServiceText;
                                }
                            }

                            lstDataPOItem.Add(dataPOItem);
                        }
                        data.POITEM = lstDataPOItem;
                    }

                    if(sapResult[0].POTEXTHEADER != null)
                    {
                        if (sapResult[0].POTEXTHEADER.Count() > 0)
                        {
                            List<POTextHeader> lstDataPOTextHeader = new List<POTextHeader>();
                            foreach (var POTextHeader in sapResult[0].POTEXTHEADER)
                            {
                                POTextHeader dataPOTextHeader = new POTextHeader();
                                dataPOTextHeader.TEXT_ID = POTextHeader.TEXT_ID;
                                dataPOTextHeader.TEXT_FORM = POTextHeader.TEXT_FORM;
                                dataPOTextHeader.TEXT_LINE = POTextHeader.TEXT_LINE;

                                lstDataPOTextHeader.Add(dataPOTextHeader);
                            }
                            data.POTEXTHEADER = lstDataPOTextHeader;
                        }
                    }

                    lstInquiryPO.Add(data);

                    final = new GeneralActionResponse<InquiryPOResponse>()
                    {
                        TotalRow = lstInquiryPO.Count(),
                        ResponseCode = "00",
                        ResponseMessages = "Inquiry PO Successfully.."
                    };

                }

                final.SetRecords(lstInquiryPO);

                return final;
            }
            catch (Exception ex)
            {
                var final = new GeneralActionResponse<InquiryPOResponse>()
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