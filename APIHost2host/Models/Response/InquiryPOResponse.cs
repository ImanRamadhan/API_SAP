using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIHost2host.Models.Response
{
    public class InquiryPOResponse
    {
        public string PO_NUMBER { get; set; }
        public string DOC_TYPE { get; set; }
        public string DOC_DATE { get; set; }
        public string VENDOR { get; set; }
        public string CURRENCY { get; set; }
        public string PUR_GROUP { get; set; }
        public string PURCH_ORG { get; set; }
        public string PMNTTRMS { get; set; }
        public string INCOTERMS1 { get; set; }
        public string INCOTERMS2 { get; set; }
        public string EXCH_RATE { get; set; }
        public string REL_IND { get; set; }
        public string REL_STATUS { get; set; }
        public string ZZMMMULTIPLIER { get; set; }
        public string ZZMMAFE { get; set; }
        public string ZZMMTKDN { get; set; }
        public string ZZMMAUTHNAME { get; set; }
        public string ZZMMAUTHPOS { get; set; }
        public string ZZMMPYMMTD { get; set; }
        public string ZZMMSPMK { get; set; }
        public string ZZMMNILBIAYA { get; set; }
        public string ZZMMPENAWAL { get; set; }
        public string ZZIP2P_OWNEREST { get; set; }
        public string ZZHSERISK { get; set; }
        public string ZZMMBIDLIST { get; set; }
        public string ZZSUBID { get; set; }
        public string ZZMMKOMODITAS { get; set; }
        public string ZZMMPROCLIST { get; set; }
        public string ZZMMPROCLISTI { get; set; }
        public List<POTextHeader> POTEXTHEADER { get; set; }
        public List<POItem> POITEM { get; set; }
        public InquiryPOResponse()
        {

        }
    }

    public class POTextHeader
    {
        public string TEXT_ID { get; set; }
        public string TEXT_FORM { get; set; }
        public string TEXT_LINE { get; set; }
    }

    public class POItem
    {
        public string PO_ITEM { get; set; }
        public string MATERIAL { get; set; }
        public string SHORT_TEXT { get; set; }
        public string QUANTITY { get; set; }
        public string UNIT { get; set; }
        public string NET_PRICE { get; set; }
        public string PRICE_UNIT { get; set; }
        public string PLANT { get; set; }
        public string PREQ_NO { get; set; }
        public string PREQ_ITEM { get; set; }
        public string RFQ { get; set; }
        public string RFQ_ITEM { get; set; }
        public string PREQ_NAME { get; set; }
        public string ITEM_CAT { get; set; }
        public string ACCTASSCAT { get; set; }
        public string MAT_GRP { get; set; }
        public string STORE_LOC { get; set; }
        public string BATCH { get; set; }
        public string AGREEMENT { get; set; }
        public string AGMT_ITEM { get; set; }
        public string OVERDELTOL { get; set; }
        public string UNDER_TOL { get; set; }
        public string UNLIMITED { get; set; }
        public string GR_IND { get; set; }
        public string GR_NON_VAL { get; set; }
        public string NO_MORE_GR { get; set; }
        public string IR_IND { get; set; }
        public string FINAL_INV { get; set; }
        public string GR_BASEDIV { get; set; }
        public string PART_INV { get; set; }
        public string TAX_CODE { get; set; }
        public string PCKG_NO { get; set; }
        public string DISTRIB { get; set; }
        public List<POTextItem> POTEXTITEM { get; set; }
        public List<POAccount> POACCOUNT { get; set; }
        public List<POSchedule> POSCHEDULE { get; set; }
        public List<POAddressDelivery> POADDRDELIVERY { get; set; }
        public List<POLimits> POLIMITS { get; set; }
        public List<POServices> POSERVICES { get; set; }
        public List<POServiceAccessValues> POSRVACCESSVALUES { get; set; }
        public List<POServiceText> POSERVICETEXT { get; set; }
    }

    public class POTextItem
    {
        public string TEXT_ID { get; set; }
        public string TEXT_FORM { get; set; }
        public string TEXT_LINE { get; set; }
    }

    public class POAccount
    {
        public string SERIAL_NO { get; set; }
        public string G_L_ACCT { get; set; }
        public string COST_CTR { get; set; }
        public string ORDER_NO { get; set; }
        public string WBS_ELEM_E { get; set; }
        public string NETWORK { get; set; }
        public string ACTIVITY { get; set; }
        public string CMMT_ITEM_LONG { get; set; }
        public string ASSET_NO { get; set; }
        public string QUANTITY { get; set; }
        public string DISTR_PERC { get; set; }
    }

    public class POSchedule
    {
        public string DELIV_DATE { get; set; }
    }

    public class POAddressDelivery
    {
        public string NAME { get; set; }
        public string NAME_2 { get; set; }
        public string STREET { get; set; }
        public string HOUSE_NO { get; set; }
        public string CITY { get; set; }
        public string POSTL_COD1 { get; set; }
    }

    public class POLimits
    {
        public string PCKG_NO { get; set; }
        public string LIMIT { get; set; }
        public string EXP_VALUE { get; set; }
        public string NO_LIMIT { get; set; }
    }

    public class POServices
    {
        public string PCKG_NO { get; set; }
        public string LINE_NO { get; set; }
        public string EXT_LINE { get; set; }
        public string SERVICE { get; set; }
        public string SHORT_TEXT { get; set; }
        public string QUANTITY { get; set; }
        public string BASE_UOM { get; set; }
        public string GROSS_VAL { get; set; }
        public string PRICE_UNIT { get; set; }
        public string NET_VALUE { get; set; }
        public string DISTRIB { get; set; }
    }

    public class POServiceAccessValues
    {
        public string PCKG_NO { get; set; }
        public string LINE_NO { get; set; }
        public string SERNO_LINE { get; set; }
        public string PERCENTAGE { get; set; }
        public string SERIAL_NO { get; set; }
        public string QUANTITY { get; set; }
        public string NET_VALUE { get; set; }
    }

    public class POServiceText
    {
        public string PCKG_NO { get; set; }
        public string LINE_NO { get; set; }
        public string TEXT_ID { get; set; }
        public string FORMAT_COL { get; set; }
        public string TEXT_LINE { get; set; }
    }
}