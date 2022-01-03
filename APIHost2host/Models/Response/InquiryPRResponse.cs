using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIHost2host.Models.Response
{
    public class InquiryPRResponse
    {
        public string PREQ_NO { get; set; }
        public string PR_TYPE { get; set; }
        public List<PRHeaderText> PRHEADERTEXT { get; set; }
        public List<PRItem> PRITEM { get; set; }

        public InquiryPRResponse()
        {

        }
    }

    public class PRHeaderText
    {
        public string TEXT_ID { get; set; }
        public string TEXT_FORM { get; set; }
        public string TEXT_LINE { get; set; }
    }

    public class PRItem
    {
        public string PREQ_ITEM { get; set; }
        public string MATERIAL { get; set; }
        public string SHORT_TEXT { get; set; }
        public string QUANTITY { get; set; }
        public string UNIT { get; set; }
        public string PREQ_PRICE { get; set; }
        public string CURRENCY { get; set; }
        public string PRICE_UNIT { get; set; }
        public string PLANT { get; set; }
        public string PUR_GROUP { get; set; }
        public string PREQ_DATE { get; set; }
        public string DELIV_DATE { get; set; }
        public string PREQ_NAME { get; set; }
        public string REL_IND { get; set; }
        public string REL_STATUS { get; set; }
        public string ITEM_CAT { get; set; }
        public string PURCH_ORG { get; set; }
        public string AGREEMENT { get; set; }
        public string AGMT_ITEM { get; set; }
        public string VALUE_ITEM { get; set; }
        public string ZZMMAUTHNAME { get; set; }
        public string ZZMMAUTHPOS { get; set; }
        public List<PRItemText> PRITEMTEXT { get; set; }
        public List<PRAccount> PRACCOUNT { get; set; }
        public List<PRAddressDelivery> PRADDRDELIVERY { get; set; }
    }

    public class PRItemText
    {
        public string TEXT_ID { get; set; }
        public string TEXT_FORM { get; set; }
        public string TEXT_LINE { get; set; }
    }

    public class PRAccount
    {
        public string GL_ACCOUNT { get; set; }
        public string COSTCENTER { get; set; }
        public string ORDERID { get; set; }
        public string WBS_ELEMENT { get; set; }
    }

    public class PRAddressDelivery
    {
        public string NAME { get; set; }
        public string STREET { get; set; }
        public string HOUSE_NO { get; set; }
        public string CITY { get; set; }
    }
}