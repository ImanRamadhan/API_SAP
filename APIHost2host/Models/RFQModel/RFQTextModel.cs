using APIHost2host.RFQ_Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using static APIHost2Host.Helper.HelpMe;

namespace APIHost2host.Models.RFQModel
{
    public class RFQText
    {
        public string TextId { get; set; }
        public string TextForm { get; set; }
        public string TextLine { get; set; }

        public List<RFQText> getRFQText(string RFQNumber)
        {
            var client = new mi_os_rfqpoService();
            client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["SAPUserName"], ConfigurationManager.AppSettings["SAPPassword"]);
            var @params = new dt_rfqpo_request();

            @params.RFQPO_DETAIL = new dt_rfqpo_requestRFQPO_DETAIL();
            @params.RFQPO_DETAIL.EKORG = ConfigurationManager.AppSettings["SAPOrgCode"];
            @params.RFQPO_DETAIL.MANDT = ConfigurationManager.AppSettings["SAPClient"];
            @params.RFQPO_DETAIL.BUKRS = ConfigurationManager.AppSettings["SAPOrgCode"];
            @params.RFQPO_DETAIL.EBELN = new dt_rfqpo_requestRFQPO_DETAILEBELN[1];
            @params.RFQPO_DETAIL.EBELN[0] = new dt_rfqpo_requestRFQPO_DETAILEBELN();
            @params.RFQPO_DETAIL.EBELN[0].SIGN = "I";
            @params.RFQPO_DETAIL.EBELN[0].OPTION = "EQ";
            @params.RFQPO_DETAIL.EBELN[0].LOW = RFQNumber;
            @params.RFQPO_DETAIL.EBELN[0].HIGH = RFQNumber;

            var result = client.mi_os_rfqpo(@params);

            List<RFQText> rfqTextList = new List<RFQText>();
            if (result.Length > 0)
            {
                var sapRfqText = result[0].HEADERTEXT;

                if (result[0].HEADERTEXT != null)
                {
                    foreach (var sapRfqTextItem in sapRfqText)
                    {
                        var rfqTextItem = new RFQText();
                        rfqTextItem.TextId = sapRfqTextItem.TEXT_ID;
                        rfqTextItem.TextForm = sapRfqTextItem.TEXT_FORM;
                        rfqTextItem.TextLine = sapRfqTextItem.TEXT_LINE;
                        rfqTextList.Add(rfqTextItem);
                    }
                }
            }
            return rfqTextList;
        }
    }
}