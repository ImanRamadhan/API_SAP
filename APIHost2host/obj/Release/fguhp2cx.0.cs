#if _DYNAMIC_XMLSERIALIZER_COMPILATION
[assembly:System.Security.AllowPartiallyTrustedCallers()]
[assembly:System.Security.SecurityTransparent()]
[assembly:System.Security.SecurityRules(System.Security.SecurityRuleSet.Level1)]
#endif
[assembly:System.Reflection.AssemblyVersionAttribute("1.0.0.0")]
[assembly:System.Xml.Serialization.XmlSerializerVersionAttribute(ParentAssemblyId=@"6830bea0-8904-4ede-ae68-3bff264e108e,", Version=@"4.0.0.0")]
namespace Microsoft.Xml.Serialization.GeneratedAssembly {

    public class XmlSerializationWriter1 : System.Xml.Serialization.XmlSerializationWriter {

        public void Write26_mi_os_po(object[] p) {
            WriteStartDocument();
            TopLevelElement();
            int pLength = p.Length;
            if (pLength > 0) {
                {
                    global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILS[] a = (global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILS[])((global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILS[])p[0]);
                    if (a != null){
                        WriteStartElement(@"mt_po_request", @"urn:pertamina:po", null, false);
                        for (int ia = 0; ia < a.Length; ia++) {
                            Write15_dt_po_requestPO_DETAILS(@"PO_DETAILS", @"", ((global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILS)a[ia]), false, false);
                        }
                        WriteEndElement();
                    }
                }
            }
        }

        public void Write27_mi_os_poInHeaders(object[] p) {
            WriteStartDocument();
            TopLevelElement();
            int pLength = p.Length;
        }

        public void Write28_mi_os_gr_pips(object[] p) {
            WriteStartDocument();
            TopLevelElement();
            int pLength = p.Length;
            if (pLength > 0) {
                {
                    global::APIHost2host.GR_Services.dt_gr_requestGR_DETAILS[] a = (global::APIHost2host.GR_Services.dt_gr_requestGR_DETAILS[])((global::APIHost2host.GR_Services.dt_gr_requestGR_DETAILS[])p[0]);
                    if (a != null){
                        WriteStartElement(@"mt_gr_request", @"urn:pertamina:gr", null, false);
                        for (int ia = 0; ia < a.Length; ia++) {
                            Write23_dt_gr_requestGR_DETAILS(@"GR_DETAILS", @"", ((global::APIHost2host.GR_Services.dt_gr_requestGR_DETAILS)a[ia]), false, false);
                        }
                        WriteEndElement();
                    }
                }
            }
        }

        public void Write29_mi_os_gr_pipsInHeaders(object[] p) {
            WriteStartDocument();
            TopLevelElement();
            int pLength = p.Length;
        }

        void Write23_dt_gr_requestGR_DETAILS(string n, string ns, global::APIHost2host.GR_Services.dt_gr_requestGR_DETAILS o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::APIHost2host.GR_Services.dt_gr_requestGR_DETAILS)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:pertamina:gr");
            WriteElementString(@"MANDT", @"", ((global::System.String)o.@MANDT));
            WriteElementString(@"OPTYPE", @"", ((global::System.String)o.@OPTYPE));
            WriteElementString(@"MBLNR_EXT", @"", ((global::System.String)o.@MBLNR_EXT));
            WriteElementString(@"MBLNR", @"", ((global::System.String)o.@MBLNR));
            WriteElementString(@"MJAHR", @"", ((global::System.String)o.@MJAHR));
            WriteElementString(@"TESTRUN", @"", ((global::System.String)o.@TESTRUN));
            WriteElementString(@"BLDAT", @"", ((global::System.String)o.@BLDAT));
            WriteElementString(@"BUDAT", @"", ((global::System.String)o.@BUDAT));
            WriteElementString(@"LFSNR", @"", ((global::System.String)o.@LFSNR));
            WriteElementString(@"FRBNR", @"", ((global::System.String)o.@FRBNR));
            WriteElementString(@"BKTXT", @"", ((global::System.String)o.@BKTXT));
            WriteElementString(@"ZDEL", @"", ((global::System.String)o.@ZDEL));
            WriteElementString(@"TGLDELIVER", @"", ((global::System.String)o.@TGLDELIVER));
            WriteElementString(@"ZMULTIPLIER", @"", ((global::System.String)o.@ZMULTIPLIER));
            WriteElementString(@"ZJUSTIFIKASI", @"", ((global::System.String)o.@ZJUSTIFIKASI));
            WriteElementString(@"TKDN", @"", ((global::System.String)o.@TKDN));
            {
                global::APIHost2host.GR_Services.dt_gr_requestGR_DETAILSITEMS[] a = (global::APIHost2host.GR_Services.dt_gr_requestGR_DETAILSITEMS[])o.@ITEMS;
                if (a != null) {
                    for (int ia = 0; ia < a.Length; ia++) {
                        Write22_dt_gr_requestGR_DETAILSITEMS(@"ITEMS", @"", ((global::APIHost2host.GR_Services.dt_gr_requestGR_DETAILSITEMS)a[ia]), false, false);
                    }
                }
            }
            WriteEndElement(o);
        }

        void Write22_dt_gr_requestGR_DETAILSITEMS(string n, string ns, global::APIHost2host.GR_Services.dt_gr_requestGR_DETAILSITEMS o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::APIHost2host.GR_Services.dt_gr_requestGR_DETAILSITEMS)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:pertamina:gr");
            WriteElementString(@"EBELN", @"", ((global::System.String)o.@EBELN));
            WriteElementString(@"EBELP", @"", ((global::System.String)o.@EBELP));
            WriteElementString(@"MATNR", @"", ((global::System.String)o.@MATNR));
            WriteElementString(@"ERFMG", @"", ((global::System.String)o.@ERFMG));
            WriteElementString(@"ERFME", @"", ((global::System.String)o.@ERFME));
            WriteElementString(@"LSMNG", @"", ((global::System.String)o.@LSMNG));
            WriteElementString(@"BWART", @"", ((global::System.String)o.@BWART));
            WriteElementString(@"INSMK", @"", ((global::System.String)o.@INSMK));
            WriteElementString(@"WERKS", @"", ((global::System.String)o.@WERKS));
            WriteElementString(@"LGORT", @"", ((global::System.String)o.@LGORT));
            WriteElementString(@"WEMPF", @"", ((global::System.String)o.@WEMPF));
            WriteElementString(@"ABLAD", @"", ((global::System.String)o.@ABLAD));
            WriteElementString(@"SGTXT", @"", ((global::System.String)o.@SGTXT));
            WriteElementString(@"ITEMINDICATOR", @"", ((global::System.String)o.@ITEMINDICATOR));
            WriteElementString(@"ELIKZ", @"", ((global::System.String)o.@ELIKZ));
            WriteElementString(@"PRCTR", @"", ((global::System.String)o.@PRCTR));
            WriteElementString(@"KOSTL", @"", ((global::System.String)o.@KOSTL));
            WriteElementString(@"REF_DOC_YR", @"", ((global::System.String)o.@REF_DOC_YR));
            WriteElementString(@"REF_DOC", @"", ((global::System.String)o.@REF_DOC));
            WriteElementString(@"REF_DOC_IT", @"", ((global::System.String)o.@REF_DOC_IT));
            WriteEndElement(o);
        }

        void Write15_dt_po_requestPO_DETAILS(string n, string ns, global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILS o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILS)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:pertamina:po");
            WriteElementString(@"MANDT", @"", ((global::System.String)o.@MANDT));
            WriteElementString(@"OPTYPE", @"", ((global::System.String)o.@OPTYPE));
            WriteElementString(@"EBELN_EXT", @"", ((global::System.String)o.@EBELN_EXT));
            WriteElementString(@"TESTRUN", @"", ((global::System.String)o.@TESTRUN));
            WriteElementString(@"BSART", @"", ((global::System.String)o.@BSART));
            WriteElementString(@"DELETE_IND", @"", ((global::System.String)o.@DELETE_IND));
            WriteElementString(@"AEDAT", @"", ((global::System.String)o.@AEDAT));
            WriteElementString(@"BEDAT", @"", ((global::System.String)o.@BEDAT));
            WriteElementString(@"LIFNR", @"", ((global::System.String)o.@LIFNR));
            WriteElementString(@"BUKRS", @"", ((global::System.String)o.@BUKRS));
            WriteElementString(@"WAERS", @"", ((global::System.String)o.@WAERS));
            WriteElementString(@"EKORG", @"", ((global::System.String)o.@EKORG));
            WriteElementString(@"WKURS", @"", ((global::System.String)o.@WKURS));
            WriteElementString(@"EKGRP", @"", ((global::System.String)o.@EKGRP));
            WriteElementString(@"FRGKE", @"", ((global::System.String)o.@FRGKE));
            WriteElementString(@"ZTERM", @"", ((global::System.String)o.@ZTERM));
            WriteElementString(@"INCO1", @"", ((global::System.String)o.@INCO1));
            WriteElementString(@"INCO2", @"", ((global::System.String)o.@INCO2));
            WriteElementString(@"ZZMMTTYPE", @"", ((global::System.String)o.@ZZMMTTYPE));
            WriteElementString(@"ZZMMSHIPDAT", @"", ((global::System.String)o.@ZZMMSHIPDAT));
            WriteElementString(@"ZZMMTYPE", @"", ((global::System.String)o.@ZZMMTYPE));
            WriteElementString(@"ZZMMLCFINAL", @"", ((global::System.String)o.@ZZMMLCFINAL));
            WriteElementString(@"ZZMMBONDNO", @"", ((global::System.String)o.@ZZMMBONDNO));
            WriteElementString(@"ZZMMBANKL", @"", ((global::System.String)o.@ZZMMBANKL));
            WriteElementString(@"ZZMMVLDSTART", @"", ((global::System.String)o.@ZZMMVLDSTART));
            WriteElementString(@"ZZMMVLDEND", @"", ((global::System.String)o.@ZZMMVLDEND));
            WriteElementString(@"ZZMMDLVTIME", @"", ((global::System.String)o.@ZZMMDLVTIME));
            WriteElementString(@"ZZMMUOT", @"", ((global::System.String)o.@ZZMMUOT));
            WriteElementString(@"ZZMMPARTALLOW", @"", ((global::System.String)o.@ZZMMPARTALLOW));
            WriteElementString(@"ZZMMAFE", @"", ((global::System.String)o.@ZZMMAFE));
            WriteElementString(@"ZZMMTKDN", @"", ((global::System.String)o.@ZZMMTKDN));
            WriteElementString(@"ZZMMAUTHNAME", @"", ((global::System.String)o.@ZZMMAUTHNAME));
            WriteElementString(@"ZZMMAUTHPOS", @"", ((global::System.String)o.@ZZMMAUTHPOS));
            WriteElementString(@"ZZMMPYMMTD", @"", ((global::System.String)o.@ZZMMPYMMTD));
            WriteElementString(@"RESIKO", @"", ((global::System.String)o.@RESIKO));
            WriteElementString(@"ZZMMKOMODITAS", @"", ((global::System.String)o.@ZZMMKOMODITAS));
            WriteElementString(@"ZZMMSTATUSPT", @"", ((global::System.String)o.@ZZMMSTATUSPT));
            WriteElementString(@"ZZMMPROCLIST", @"", ((global::System.String)o.@ZZMMPROCLIST));
            WriteElementString(@"ZZMMBIDLIST", @"", ((global::System.String)o.@ZZMMBIDLIST));
            WriteElementString(@"ZZIP2P_SUBBID", @"", ((global::System.String)o.@ZZIP2P_SUBBID));
            WriteElementString(@"ZZIP2P_OWNEREST", @"", ((global::System.String)o.@ZZIP2P_OWNEREST));
            WriteElementString(@"ZZIP2P_CURR", @"", ((global::System.String)o.@ZZIP2P_CURR));
            Write2_Item(@"VERSIONS", @"", ((global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSVERSIONS)o.@VERSIONS), false, false);
            {
                global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSHEADERTEXT[] a = (global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSHEADERTEXT[])o.@HEADERTEXT;
                if (a != null) {
                    for (int ia = 0; ia < a.Length; ia++) {
                        Write3_Item(@"HEADERTEXT", @"", ((global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSHEADERTEXT)a[ia]), false, false);
                    }
                }
            }
            Write4_Item(@"POADDRVENDOR", @"", ((global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSPOADDRVENDOR)o.@POADDRVENDOR), false, false);
            {
                global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSPOPARTNER[] a = (global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSPOPARTNER[])o.@POPARTNER;
                if (a != null) {
                    for (int ia = 0; ia < a.Length; ia++) {
                        Write5_Item(@"POPARTNER", @"", ((global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSPOPARTNER)a[ia]), false, false);
                    }
                }
            }
            {
                global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMS[] a = (global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMS[])o.@ITEMS;
                if (a != null) {
                    for (int ia = 0; ia < a.Length; ia++) {
                        Write11_dt_po_requestPO_DETAILSITEMS(@"ITEMS", @"", ((global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMS)a[ia]), false, false);
                    }
                }
            }
            {
                global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSLIMITS[] a = (global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSLIMITS[])o.@LIMITS;
                if (a != null) {
                    for (int ia = 0; ia < a.Length; ia++) {
                        Write12_dt_po_requestPO_DETAILSLIMITS(@"LIMITS", @"", ((global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSLIMITS)a[ia]), false, false);
                    }
                }
            }
            {
                global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSSERVICE[] a = (global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSSERVICE[])o.@SERVICE;
                if (a != null) {
                    for (int ia = 0; ia < a.Length; ia++) {
                        Write13_dt_po_requestPO_DETAILSSERVICE(@"SERVICE", @"", ((global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSSERVICE)a[ia]), false, false);
                    }
                }
            }
            {
                global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSPOSRVACCESSVALUES[] a = (global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSPOSRVACCESSVALUES[])o.@POSRVACCESSVALUES;
                if (a != null) {
                    for (int ia = 0; ia < a.Length; ia++) {
                        Write14_Item(@"POSRVACCESSVALUES", @"", ((global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSPOSRVACCESSVALUES)a[ia]), false, false);
                    }
                }
            }
            WriteEndElement(o);
        }

        void Write14_Item(string n, string ns, global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSPOSRVACCESSVALUES o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSPOSRVACCESSVALUES)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:pertamina:po");
            WriteElementString(@"PACKNO", @"", ((global::System.String)o.@PACKNO));
            WriteElementString(@"INTROW", @"", ((global::System.String)o.@INTROW));
            WriteElementString(@"NUMKN", @"", ((global::System.String)o.@NUMKN));
            WriteElementString(@"ZEKKN", @"", ((global::System.String)o.@ZEKKN));
            WriteElementString(@"MENGE", @"", ((global::System.String)o.@MENGE));
            WriteElementString(@"WPROZ", @"", ((global::System.String)o.@WPROZ));
            WriteEndElement(o);
        }

        void Write13_dt_po_requestPO_DETAILSSERVICE(string n, string ns, global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSSERVICE o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSSERVICE)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:pertamina:po");
            WriteElementString(@"PACKNO_EXT", @"", ((global::System.String)o.@PACKNO_EXT));
            WriteElementString(@"INTROW_EXT", @"", ((global::System.String)o.@INTROW_EXT));
            WriteElementString(@"EXTROW", @"", ((global::System.String)o.@EXTROW));
            WriteElementString(@"OUTL_IND", @"", ((global::System.String)o.@OUTL_IND));
            WriteElementString(@"SUB_PACKNO", @"", ((global::System.String)o.@SUB_PACKNO));
            WriteElementString(@"SRVPOS", @"", ((global::System.String)o.@SRVPOS));
            WriteElementString(@"DEL_IND", @"", ((global::System.String)o.@DEL_IND));
            WriteElementString(@"MENGE", @"", ((global::System.String)o.@MENGE));
            WriteElementString(@"MEINS", @"", ((global::System.String)o.@MEINS));
            WriteElementString(@"PEINH", @"", ((global::System.String)o.@PEINH));
            WriteElementString(@"BRTWR", @"", ((global::System.String)o.@BRTWR));
            WriteElementString(@"TXZ01", @"", ((global::System.String)o.@TXZ01));
            WriteElementString(@"PLN_PACKNO", @"", ((global::System.String)o.@PLN_PACKNO));
            WriteElementString(@"PLN_INTROW", @"", ((global::System.String)o.@PLN_INTROW));
            WriteElementString(@"DISTRIB", @"", ((global::System.String)o.@DISTRIB));
            WriteEndElement(o);
        }

        void Write12_dt_po_requestPO_DETAILSLIMITS(string n, string ns, global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSLIMITS o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSLIMITS)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:pertamina:po");
            WriteElementString(@"PACKNO", @"", ((global::System.String)o.@PACKNO));
            WriteElementString(@"SUMLIMIT", @"", ((global::System.String)o.@SUMLIMIT));
            WriteElementString(@"SUMNOLIM", @"", ((global::System.String)o.@SUMNOLIM));
            WriteElementString(@"COMMITMENT", @"", ((global::System.String)o.@COMMITMENT));
            WriteEndElement(o);
        }

        void Write11_dt_po_requestPO_DETAILSITEMS(string n, string ns, global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMS o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMS)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:pertamina:po");
            WriteElementString(@"EBELP", @"", ((global::System.String)o.@EBELP));
            WriteElementString(@"DELETE_IND", @"", ((global::System.String)o.@DELETE_IND));
            WriteElementString(@"PSTYP", @"", ((global::System.String)o.@PSTYP));
            WriteElementString(@"KNTTP", @"", ((global::System.String)o.@KNTTP));
            WriteElementString(@"MWSKZ", @"", ((global::System.String)o.@MWSKZ));
            WriteElementString(@"MATNR", @"", ((global::System.String)o.@MATNR));
            WriteElementString(@"WERKS", @"", ((global::System.String)o.@WERKS));
            WriteElementString(@"LGORT", @"", ((global::System.String)o.@LGORT));
            WriteElementString(@"MATKL", @"", ((global::System.String)o.@MATKL));
            WriteElementString(@"TXZ01", @"", ((global::System.String)o.@TXZ01));
            WriteElementString(@"MENGE", @"", ((global::System.String)o.@MENGE));
            WriteElementString(@"MEINS", @"", ((global::System.String)o.@MEINS));
            WriteElementString(@"NETPR", @"", ((global::System.String)o.@NETPR));
            WriteElementString(@"PEINH", @"", ((global::System.String)o.@PEINH));
            WriteElementString(@"BPRME", @"", ((global::System.String)o.@BPRME));
            WriteElementString(@"WEUNB", @"", ((global::System.String)o.@WEUNB));
            WriteElementString(@"REPOS", @"", ((global::System.String)o.@REPOS));
            WriteElementString(@"WEBRE", @"", ((global::System.String)o.@WEBRE));
            WriteElementString(@"WEPOS", @"", ((global::System.String)o.@WEPOS));
            WriteElementString(@"ELIKZ", @"", ((global::System.String)o.@ELIKZ));
            WriteElementString(@"EREKZ", @"", ((global::System.String)o.@EREKZ));
            WriteElementString(@"AFNAM", @"", ((global::System.String)o.@AFNAM));
            WriteElementString(@"KONNR", @"", ((global::System.String)o.@KONNR));
            WriteElementString(@"KTPNR", @"", ((global::System.String)o.@KTPNR));
            WriteElementString(@"PCKG_NO", @"", ((global::System.String)o.@PCKG_NO));
            WriteElementString(@"LEBRE", @"", ((global::System.String)o.@LEBRE));
            WriteElementString(@"PREQ_NO", @"", ((global::System.String)o.@PREQ_NO));
            WriteElementString(@"PREQ_ITEM", @"", ((global::System.String)o.@PREQ_ITEM));
            WriteElementString(@"DISTRIB", @"", ((global::System.String)o.@DISTRIB));
            {
                global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMSADDRDELIVERY[] a = (global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMSADDRDELIVERY[])o.@ADDRDELIVERY;
                if (a != null) {
                    for (int ia = 0; ia < a.Length; ia++) {
                        Write6_Item(@"ADDRDELIVERY", @"", ((global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMSADDRDELIVERY)a[ia]), false, false);
                    }
                }
            }
            {
                global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMSITEMTEXT[] a = (global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMSITEMTEXT[])o.@ITEMTEXT;
                if (a != null) {
                    for (int ia = 0; ia < a.Length; ia++) {
                        Write7_Item(@"ITEMTEXT", @"", ((global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMSITEMTEXT)a[ia]), false, false);
                    }
                }
            }
            {
                global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMSSCHEDULE[] a = (global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMSSCHEDULE[])o.@SCHEDULE;
                if (a != null) {
                    for (int ia = 0; ia < a.Length; ia++) {
                        Write8_Item(@"SCHEDULE", @"", ((global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMSSCHEDULE)a[ia]), false, false);
                    }
                }
            }
            {
                global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMSACCNTASSIGNMENT[] a = (global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMSACCNTASSIGNMENT[])o.@ACCNTASSIGNMENT;
                if (a != null) {
                    for (int ia = 0; ia < a.Length; ia++) {
                        Write9_Item(@"ACCNTASSIGNMENT", @"", ((global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMSACCNTASSIGNMENT)a[ia]), false, false);
                    }
                }
            }
            {
                global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMSCONDITIONTYPE[] a = (global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMSCONDITIONTYPE[])o.@CONDITIONTYPE;
                if (a != null) {
                    for (int ia = 0; ia < a.Length; ia++) {
                        Write10_Item(@"CONDITIONTYPE", @"", ((global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMSCONDITIONTYPE)a[ia]), false, false);
                    }
                }
            }
            WriteEndElement(o);
        }

        void Write10_Item(string n, string ns, global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMSCONDITIONTYPE o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMSCONDITIONTYPE)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:pertamina:po");
            WriteElementString(@"STUNR", @"", ((global::System.String)o.@STUNR));
            WriteElementString(@"DZAEHK", @"", ((global::System.String)o.@DZAEHK));
            WriteElementString(@"KSCHL", @"", ((global::System.String)o.@KSCHL));
            WriteElementString(@"KBETR", @"", ((global::System.String)o.@KBETR));
            WriteElementString(@"WAERS", @"", ((global::System.String)o.@WAERS));
            WriteElementString(@"LIFNR", @"", ((global::System.String)o.@LIFNR));
            WriteElementString(@"CHANGE_ID", @"", ((global::System.String)o.@CHANGE_ID));
            WriteEndElement(o);
        }

        void Write9_Item(string n, string ns, global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMSACCNTASSIGNMENT o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMSACCNTASSIGNMENT)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:pertamina:po");
            WriteElementString(@"ZEKKN", @"", ((global::System.String)o.@ZEKKN));
            WriteElementString(@"DELETE_IND", @"", ((global::System.String)o.@DELETE_IND));
            WriteElementString(@"MENGE", @"", ((global::System.String)o.@MENGE));
            WriteElementString(@"VPROZ", @"", ((global::System.String)o.@VPROZ));
            WriteElementString(@"SAKTO", @"", ((global::System.String)o.@SAKTO));
            WriteElementString(@"KOSTL", @"", ((global::System.String)o.@KOSTL));
            WriteElementString(@"AUFNR", @"", ((global::System.String)o.@AUFNR));
            WriteElementString(@"PS_PSP_PNR", @"", ((global::System.String)o.@PS_PSP_PNR));
            WriteElementString(@"NPLNR", @"", ((global::System.String)o.@NPLNR));
            WriteElementString(@"FISTL", @"", ((global::System.String)o.@FISTL));
            WriteElementString(@"FIPOS", @"", ((global::System.String)o.@FIPOS));
            WriteEndElement(o);
        }

        void Write8_Item(string n, string ns, global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMSSCHEDULE o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMSSCHEDULE)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:pertamina:po");
            WriteElementString(@"ETENR", @"", ((global::System.String)o.@ETENR));
            WriteElementString(@"EINDT", @"", ((global::System.String)o.@EINDT));
            WriteElementString(@"QUANTITY", @"", ((global::System.String)o.@QUANTITY));
            WriteElementString(@"BANFN", @"", ((global::System.String)o.@BANFN));
            WriteElementString(@"BNFPO", @"", ((global::System.String)o.@BNFPO));
            WriteElementString(@"DELETE_IND", @"", ((global::System.String)o.@DELETE_IND));
            WriteEndElement(o);
        }

        void Write7_Item(string n, string ns, global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMSITEMTEXT o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMSITEMTEXT)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:pertamina:po");
            WriteElementString(@"TEXT_ID", @"", ((global::System.String)o.@TEXT_ID));
            WriteElementString(@"TEXT_LINE", @"", ((global::System.String)o.@TEXT_LINE));
            WriteEndElement(o);
        }

        void Write6_Item(string n, string ns, global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMSADDRDELIVERY o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSITEMSADDRDELIVERY)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:pertamina:po");
            WriteElementString(@"ADDR_NO", @"", ((global::System.String)o.@ADDR_NO));
            WriteElementString(@"NAME1", @"", ((global::System.String)o.@NAME1));
            WriteElementString(@"NAME2", @"", ((global::System.String)o.@NAME2));
            WriteElementString(@"CITY1", @"", ((global::System.String)o.@CITY1));
            WriteElementString(@"POST_CODE1", @"", ((global::System.String)o.@POST_CODE1));
            WriteElementString(@"STREET", @"", ((global::System.String)o.@STREET));
            WriteElementString(@"HOUSE_NUM1", @"", ((global::System.String)o.@HOUSE_NUM1));
            WriteElementString(@"LAND1", @"", ((global::System.String)o.@LAND1));
            WriteElementString(@"REGION", @"", ((global::System.String)o.@REGION));
            WriteEndElement(o);
        }

        void Write5_Item(string n, string ns, global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSPOPARTNER o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSPOPARTNER)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:pertamina:po");
            WriteElementString(@"PARTNERDESC", @"", ((global::System.String)o.@PARTNERDESC));
            WriteElementString(@"BUSPARTNO", @"", ((global::System.String)o.@BUSPARTNO));
            WriteEndElement(o);
        }

        void Write4_Item(string n, string ns, global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSPOADDRVENDOR o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSPOADDRVENDOR)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:pertamina:po");
            WriteElementString(@"NAME", @"", ((global::System.String)o.@NAME));
            WriteElementString(@"NAME_2", @"", ((global::System.String)o.@NAME_2));
            WriteElementString(@"STREET", @"", ((global::System.String)o.@STREET));
            WriteElementString(@"HOUSE_NO", @"", ((global::System.String)o.@HOUSE_NO));
            WriteElementString(@"POSTL_COD1", @"", ((global::System.String)o.@POSTL_COD1));
            WriteElementString(@"CITY", @"", ((global::System.String)o.@CITY));
            WriteElementString(@"COUNTRY", @"", ((global::System.String)o.@COUNTRY));
            WriteElementString(@"TEL1_NUMBR", @"", ((global::System.String)o.@TEL1_NUMBR));
            WriteElementString(@"FAX_NUMBER", @"", ((global::System.String)o.@FAX_NUMBER));
            WriteEndElement(o);
        }

        void Write3_Item(string n, string ns, global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSHEADERTEXT o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSHEADERTEXT)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:pertamina:po");
            WriteElementString(@"TEXT_ID", @"", ((global::System.String)o.@TEXT_ID));
            WriteElementString(@"TEXT_LINE", @"", ((global::System.String)o.@TEXT_LINE));
            WriteEndElement(o);
        }

        void Write2_Item(string n, string ns, global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSVERSIONS o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::APIHost2host.PO_Services2.dt_po_requestPO_DETAILSVERSIONS)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:pertamina:po");
            WriteElementString(@"COMPLETED", @"", ((global::System.String)o.@COMPLETED));
            WriteElementString(@"DESCRIPTION", @"", ((global::System.String)o.@DESCRIPTION));
            WriteEndElement(o);
        }

        protected override void InitCallbacks() {
        }
    }

    public class XmlSerializationReader1 : System.Xml.Serialization.XmlSerializationReader {

        public object[] Read26_mi_os_poResponse() {
            Reader.MoveToContent();
            object[] p = new object[1];
            bool[] paramsRead = new bool[1];
            Reader.MoveToContent();
            int whileIterations0 = 0;
            int readerCount0 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id1_mt_po_response && (object) Reader.NamespaceURI == (object)id2_urnpertaminapo)) {
                        if (!ReadNull()) {
                            global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILS[] a_0_0 = null;
                            int ca_0_0 = 0;
                            if ((Reader.IsEmptyElement)) {
                                Reader.Skip();
                            }
                            else {
                                Reader.ReadStartElement();
                                Reader.MoveToContent();
                                int whileIterations1 = 0;
                                int readerCount1 = ReaderCount;
                                while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                                    if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                                        if (((object) Reader.LocalName == (object)id3_PO_DETAILS && (object) Reader.NamespaceURI == (object)id4_Item)) {
                                            a_0_0 = (global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILS[])EnsureArrayIndex(a_0_0, ca_0_0, typeof(global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILS));a_0_0[ca_0_0++] = Read20_dt_po_responsePO_DETAILS(false, true);
                                        }
                                        else {
                                            UnknownNode(null, @":PO_DETAILS");
                                        }
                                    }
                                    else {
                                        UnknownNode(null, @":PO_DETAILS");
                                    }
                                    Reader.MoveToContent();
                                    CheckReaderCount(ref whileIterations1, ref readerCount1);
                                }
                            ReadEndElement();
                            }
                            p[0] = (global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILS[])ShrinkArray(a_0_0, ca_0_0, typeof(global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILS), false);
                        }
                        paramsRead[0] = true;
                    }
                    else {
                        UnknownNode((object)p, @"urn:pertamina:po:mt_po_response");
                    }
                }
                else {
                    UnknownNode((object)p, @"urn:pertamina:po:mt_po_response");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations0, ref readerCount0);
            }
            return p;
        }

        public object[] Read27_mi_os_poResponseOutHeaders() {
            Reader.MoveToContent();
            object[] p = new object[0];
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations2 = 0;
            int readerCount2 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    UnknownNode((object)p, @"");
                }
                else {
                    UnknownNode((object)p, @"");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations2, ref readerCount2);
            }
            return p;
        }

        public object[] Read28_mi_os_gr_pipsResponse() {
            Reader.MoveToContent();
            object[] p = new object[1];
            bool[] paramsRead = new bool[1];
            Reader.MoveToContent();
            int whileIterations3 = 0;
            int readerCount3 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id5_mt_gr_response && (object) Reader.NamespaceURI == (object)id6_urnpertaminagr)) {
                        if (!ReadNull()) {
                            global::APIHost2host.GR_Services.dt_gr_responseGR_DETAILS[] a_0_0 = null;
                            int ca_0_0 = 0;
                            if ((Reader.IsEmptyElement)) {
                                Reader.Skip();
                            }
                            else {
                                Reader.ReadStartElement();
                                Reader.MoveToContent();
                                int whileIterations4 = 0;
                                int readerCount4 = ReaderCount;
                                while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                                    if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                                        if (((object) Reader.LocalName == (object)id7_GR_DETAILS && (object) Reader.NamespaceURI == (object)id4_Item)) {
                                            a_0_0 = (global::APIHost2host.GR_Services.dt_gr_responseGR_DETAILS[])EnsureArrayIndex(a_0_0, ca_0_0, typeof(global::APIHost2host.GR_Services.dt_gr_responseGR_DETAILS));a_0_0[ca_0_0++] = Read25_dt_gr_responseGR_DETAILS(false, true);
                                        }
                                        else {
                                            UnknownNode(null, @":GR_DETAILS");
                                        }
                                    }
                                    else {
                                        UnknownNode(null, @":GR_DETAILS");
                                    }
                                    Reader.MoveToContent();
                                    CheckReaderCount(ref whileIterations4, ref readerCount4);
                                }
                            ReadEndElement();
                            }
                            p[0] = (global::APIHost2host.GR_Services.dt_gr_responseGR_DETAILS[])ShrinkArray(a_0_0, ca_0_0, typeof(global::APIHost2host.GR_Services.dt_gr_responseGR_DETAILS), false);
                        }
                        paramsRead[0] = true;
                    }
                    else {
                        UnknownNode((object)p, @"urn:pertamina:gr:mt_gr_response");
                    }
                }
                else {
                    UnknownNode((object)p, @"urn:pertamina:gr:mt_gr_response");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations3, ref readerCount3);
            }
            return p;
        }

        public object[] Read29_Item() {
            Reader.MoveToContent();
            object[] p = new object[0];
            bool[] paramsRead = new bool[0];
            Reader.MoveToContent();
            int whileIterations5 = 0;
            int readerCount5 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    UnknownNode((object)p, @"");
                }
                else {
                    UnknownNode((object)p, @"");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations5, ref readerCount5);
            }
            return p;
        }

        global::APIHost2host.GR_Services.dt_gr_responseGR_DETAILS Read25_dt_gr_responseGR_DETAILS(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id6_urnpertaminagr)) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::APIHost2host.GR_Services.dt_gr_responseGR_DETAILS o;
            o = new global::APIHost2host.GR_Services.dt_gr_responseGR_DETAILS();
            global::APIHost2host.GR_Services.dt_gr_responseGR_DETAILSMSG_DETAILS[] a_7 = null;
            int ca_7 = 0;
            bool[] paramsRead = new bool[8];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                o.@MSG_DETAILS = (global::APIHost2host.GR_Services.dt_gr_responseGR_DETAILSMSG_DETAILS[])ShrinkArray(a_7, ca_7, typeof(global::APIHost2host.GR_Services.dt_gr_responseGR_DETAILSMSG_DETAILS), true);
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations6 = 0;
            int readerCount6 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id8_MANDT && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@MANDT = Reader.ReadElementString();
                        }
                        paramsRead[0] = true;
                    }
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id9_MBLNR_EXT && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@MBLNR_EXT = Reader.ReadElementString();
                        }
                        paramsRead[1] = true;
                    }
                    else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id10_MBLNR && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@MBLNR = Reader.ReadElementString();
                        }
                        paramsRead[2] = true;
                    }
                    else if (!paramsRead[3] && ((object) Reader.LocalName == (object)id11_MJAHR && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@MJAHR = Reader.ReadElementString();
                        }
                        paramsRead[3] = true;
                    }
                    else if (!paramsRead[4] && ((object) Reader.LocalName == (object)id12_COMM_FLAG && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@COMM_FLAG = Reader.ReadElementString();
                        }
                        paramsRead[4] = true;
                    }
                    else if (!paramsRead[5] && ((object) Reader.LocalName == (object)id13_TYPE && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@TYPE = Reader.ReadElementString();
                        }
                        paramsRead[5] = true;
                    }
                    else if (!paramsRead[6] && ((object) Reader.LocalName == (object)id14_MESSAGE && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@MESSAGE = Reader.ReadElementString();
                        }
                        paramsRead[6] = true;
                    }
                    else if (((object) Reader.LocalName == (object)id15_MSG_DETAILS && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        a_7 = (global::APIHost2host.GR_Services.dt_gr_responseGR_DETAILSMSG_DETAILS[])EnsureArrayIndex(a_7, ca_7, typeof(global::APIHost2host.GR_Services.dt_gr_responseGR_DETAILSMSG_DETAILS));a_7[ca_7++] = Read24_Item(false, true);
                    }
                    else {
                        UnknownNode((object)o, @":MANDT, :MBLNR_EXT, :MBLNR, :MJAHR, :COMM_FLAG, :TYPE, :MESSAGE, :MSG_DETAILS");
                    }
                }
                else {
                    UnknownNode((object)o, @":MANDT, :MBLNR_EXT, :MBLNR, :MJAHR, :COMM_FLAG, :TYPE, :MESSAGE, :MSG_DETAILS");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations6, ref readerCount6);
            }
            o.@MSG_DETAILS = (global::APIHost2host.GR_Services.dt_gr_responseGR_DETAILSMSG_DETAILS[])ShrinkArray(a_7, ca_7, typeof(global::APIHost2host.GR_Services.dt_gr_responseGR_DETAILSMSG_DETAILS), true);
            ReadEndElement();
            return o;
        }

        global::APIHost2host.GR_Services.dt_gr_responseGR_DETAILSMSG_DETAILS Read24_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id6_urnpertaminagr)) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::APIHost2host.GR_Services.dt_gr_responseGR_DETAILSMSG_DETAILS o;
            o = new global::APIHost2host.GR_Services.dt_gr_responseGR_DETAILSMSG_DETAILS();
            bool[] paramsRead = new bool[2];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations7 = 0;
            int readerCount7 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id13_TYPE && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@TYPE = Reader.ReadElementString();
                        }
                        paramsRead[0] = true;
                    }
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id16_MSG_DET && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@MSG_DET = Reader.ReadElementString();
                        }
                        paramsRead[1] = true;
                    }
                    else {
                        UnknownNode((object)o, @":TYPE, :MSG_DET");
                    }
                }
                else {
                    UnknownNode((object)o, @":TYPE, :MSG_DET");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations7, ref readerCount7);
            }
            ReadEndElement();
            return o;
        }

        global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILS Read20_dt_po_responsePO_DETAILS(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_urnpertaminapo)) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILS o;
            o = new global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILS();
            global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSMSG_DETAILS[] a_7 = null;
            int ca_7 = 0;
            global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSITEMS[] a_8 = null;
            int ca_8 = 0;
            global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSSERVICE[] a_9 = null;
            int ca_9 = 0;
            global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSPOSRVACCESSVALUES[] a_10 = null;
            int ca_10 = 0;
            bool[] paramsRead = new bool[11];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                o.@MSG_DETAILS = (global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSMSG_DETAILS[])ShrinkArray(a_7, ca_7, typeof(global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSMSG_DETAILS), true);
                o.@ITEMS = (global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSITEMS[])ShrinkArray(a_8, ca_8, typeof(global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSITEMS), true);
                o.@SERVICE = (global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSSERVICE[])ShrinkArray(a_9, ca_9, typeof(global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSSERVICE), true);
                o.@POSRVACCESSVALUES = (global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSPOSRVACCESSVALUES[])ShrinkArray(a_10, ca_10, typeof(global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSPOSRVACCESSVALUES), true);
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations8 = 0;
            int readerCount8 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id8_MANDT && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@MANDT = Reader.ReadElementString();
                        }
                        paramsRead[0] = true;
                    }
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id17_EBELN_EXT && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@EBELN_EXT = Reader.ReadElementString();
                        }
                        paramsRead[1] = true;
                    }
                    else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id18_EBELN && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@EBELN = Reader.ReadElementString();
                        }
                        paramsRead[2] = true;
                    }
                    else if (!paramsRead[3] && ((object) Reader.LocalName == (object)id19_FRGKE && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@FRGKE = Reader.ReadElementString();
                        }
                        paramsRead[3] = true;
                    }
                    else if (!paramsRead[4] && ((object) Reader.LocalName == (object)id12_COMM_FLAG && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@COMM_FLAG = Reader.ReadElementString();
                        }
                        paramsRead[4] = true;
                    }
                    else if (!paramsRead[5] && ((object) Reader.LocalName == (object)id13_TYPE && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@TYPE = Reader.ReadElementString();
                        }
                        paramsRead[5] = true;
                    }
                    else if (!paramsRead[6] && ((object) Reader.LocalName == (object)id14_MESSAGE && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@MESSAGE = Reader.ReadElementString();
                        }
                        paramsRead[6] = true;
                    }
                    else if (((object) Reader.LocalName == (object)id15_MSG_DETAILS && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        a_7 = (global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSMSG_DETAILS[])EnsureArrayIndex(a_7, ca_7, typeof(global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSMSG_DETAILS));a_7[ca_7++] = Read16_Item(false, true);
                    }
                    else if (((object) Reader.LocalName == (object)id20_ITEMS && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        a_8 = (global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSITEMS[])EnsureArrayIndex(a_8, ca_8, typeof(global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSITEMS));a_8[ca_8++] = Read17_dt_po_responsePO_DETAILSITEMS(false, true);
                    }
                    else if (((object) Reader.LocalName == (object)id21_SERVICE && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        a_9 = (global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSSERVICE[])EnsureArrayIndex(a_9, ca_9, typeof(global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSSERVICE));a_9[ca_9++] = Read18_Item(false, true);
                    }
                    else if (((object) Reader.LocalName == (object)id22_POSRVACCESSVALUES && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        a_10 = (global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSPOSRVACCESSVALUES[])EnsureArrayIndex(a_10, ca_10, typeof(global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSPOSRVACCESSVALUES));a_10[ca_10++] = Read19_Item(false, true);
                    }
                    else {
                        UnknownNode((object)o, @":MANDT, :EBELN_EXT, :EBELN, :FRGKE, :COMM_FLAG, :TYPE, :MESSAGE, :MSG_DETAILS, :ITEMS, :SERVICE, :POSRVACCESSVALUES");
                    }
                }
                else {
                    UnknownNode((object)o, @":MANDT, :EBELN_EXT, :EBELN, :FRGKE, :COMM_FLAG, :TYPE, :MESSAGE, :MSG_DETAILS, :ITEMS, :SERVICE, :POSRVACCESSVALUES");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations8, ref readerCount8);
            }
            o.@MSG_DETAILS = (global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSMSG_DETAILS[])ShrinkArray(a_7, ca_7, typeof(global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSMSG_DETAILS), true);
            o.@ITEMS = (global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSITEMS[])ShrinkArray(a_8, ca_8, typeof(global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSITEMS), true);
            o.@SERVICE = (global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSSERVICE[])ShrinkArray(a_9, ca_9, typeof(global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSSERVICE), true);
            o.@POSRVACCESSVALUES = (global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSPOSRVACCESSVALUES[])ShrinkArray(a_10, ca_10, typeof(global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSPOSRVACCESSVALUES), true);
            ReadEndElement();
            return o;
        }

        global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSPOSRVACCESSVALUES Read19_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_urnpertaminapo)) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSPOSRVACCESSVALUES o;
            o = new global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSPOSRVACCESSVALUES();
            bool[] paramsRead = new bool[8];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations9 = 0;
            int readerCount9 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id23_PACKNO_EXT && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@PACKNO_EXT = Reader.ReadElementString();
                        }
                        paramsRead[0] = true;
                    }
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id24_INTROW_EXT && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@INTROW_EXT = Reader.ReadElementString();
                        }
                        paramsRead[1] = true;
                    }
                    else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id25_NUMKN_EXT && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@NUMKN_EXT = Reader.ReadElementString();
                        }
                        paramsRead[2] = true;
                    }
                    else if (!paramsRead[3] && ((object) Reader.LocalName == (object)id26_PACKNO && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@PACKNO = Reader.ReadElementString();
                        }
                        paramsRead[3] = true;
                    }
                    else if (!paramsRead[4] && ((object) Reader.LocalName == (object)id27_INTROW && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@INTROW = Reader.ReadElementString();
                        }
                        paramsRead[4] = true;
                    }
                    else if (!paramsRead[5] && ((object) Reader.LocalName == (object)id28_NUMKN && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@NUMKN = Reader.ReadElementString();
                        }
                        paramsRead[5] = true;
                    }
                    else if (!paramsRead[6] && ((object) Reader.LocalName == (object)id29_ZEKKN_EXT && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@ZEKKN_EXT = Reader.ReadElementString();
                        }
                        paramsRead[6] = true;
                    }
                    else if (!paramsRead[7] && ((object) Reader.LocalName == (object)id30_ZEKKN && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@ZEKKN = Reader.ReadElementString();
                        }
                        paramsRead[7] = true;
                    }
                    else {
                        UnknownNode((object)o, @":PACKNO_EXT, :INTROW_EXT, :NUMKN_EXT, :PACKNO, :INTROW, :NUMKN, :ZEKKN_EXT, :ZEKKN");
                    }
                }
                else {
                    UnknownNode((object)o, @":PACKNO_EXT, :INTROW_EXT, :NUMKN_EXT, :PACKNO, :INTROW, :NUMKN, :ZEKKN_EXT, :ZEKKN");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations9, ref readerCount9);
            }
            ReadEndElement();
            return o;
        }

        global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSSERVICE Read18_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_urnpertaminapo)) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSSERVICE o;
            o = new global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSSERVICE();
            bool[] paramsRead = new bool[6];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations10 = 0;
            int readerCount10 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id23_PACKNO_EXT && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@PACKNO_EXT = Reader.ReadElementString();
                        }
                        paramsRead[0] = true;
                    }
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id24_INTROW_EXT && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@INTROW_EXT = Reader.ReadElementString();
                        }
                        paramsRead[1] = true;
                    }
                    else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id26_PACKNO && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@PACKNO = Reader.ReadElementString();
                        }
                        paramsRead[2] = true;
                    }
                    else if (!paramsRead[3] && ((object) Reader.LocalName == (object)id27_INTROW && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@INTROW = Reader.ReadElementString();
                        }
                        paramsRead[3] = true;
                    }
                    else if (!paramsRead[4] && ((object) Reader.LocalName == (object)id31_EXTROW && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@EXTROW = Reader.ReadElementString();
                        }
                        paramsRead[4] = true;
                    }
                    else if (!paramsRead[5] && ((object) Reader.LocalName == (object)id32_SUB_PACKNO && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@SUB_PACKNO = Reader.ReadElementString();
                        }
                        paramsRead[5] = true;
                    }
                    else {
                        UnknownNode((object)o, @":PACKNO_EXT, :INTROW_EXT, :PACKNO, :INTROW, :EXTROW, :SUB_PACKNO");
                    }
                }
                else {
                    UnknownNode((object)o, @":PACKNO_EXT, :INTROW_EXT, :PACKNO, :INTROW, :EXTROW, :SUB_PACKNO");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations10, ref readerCount10);
            }
            ReadEndElement();
            return o;
        }

        global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSITEMS Read17_dt_po_responsePO_DETAILSITEMS(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_urnpertaminapo)) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSITEMS o;
            o = new global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSITEMS();
            bool[] paramsRead = new bool[2];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations11 = 0;
            int readerCount11 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id33_EBELP_EXT && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@EBELP_EXT = Reader.ReadElementString();
                        }
                        paramsRead[0] = true;
                    }
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id34_EBELP && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@EBELP = Reader.ReadElementString();
                        }
                        paramsRead[1] = true;
                    }
                    else {
                        UnknownNode((object)o, @":EBELP_EXT, :EBELP");
                    }
                }
                else {
                    UnknownNode((object)o, @":EBELP_EXT, :EBELP");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations11, ref readerCount11);
            }
            ReadEndElement();
            return o;
        }

        global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSMSG_DETAILS Read16_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_urnpertaminapo)) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSMSG_DETAILS o;
            o = new global::APIHost2host.PO_Services2.dt_po_responsePO_DETAILSMSG_DETAILS();
            bool[] paramsRead = new bool[2];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations12 = 0;
            int readerCount12 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id13_TYPE && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@TYPE = Reader.ReadElementString();
                        }
                        paramsRead[0] = true;
                    }
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id16_MSG_DET && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        {
                            o.@MSG_DET = Reader.ReadElementString();
                        }
                        paramsRead[1] = true;
                    }
                    else {
                        UnknownNode((object)o, @":TYPE, :MSG_DET");
                    }
                }
                else {
                    UnknownNode((object)o, @":TYPE, :MSG_DET");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations12, ref readerCount12);
            }
            ReadEndElement();
            return o;
        }

        protected override void InitCallbacks() {
        }

        string id10_MBLNR;
        string id6_urnpertaminagr;
        string id15_MSG_DETAILS;
        string id11_MJAHR;
        string id30_ZEKKN;
        string id8_MANDT;
        string id26_PACKNO;
        string id7_GR_DETAILS;
        string id19_FRGKE;
        string id18_EBELN;
        string id20_ITEMS;
        string id25_NUMKN_EXT;
        string id4_Item;
        string id34_EBELP;
        string id2_urnpertaminapo;
        string id21_SERVICE;
        string id27_INTROW;
        string id28_NUMKN;
        string id22_POSRVACCESSVALUES;
        string id29_ZEKKN_EXT;
        string id33_EBELP_EXT;
        string id17_EBELN_EXT;
        string id1_mt_po_response;
        string id9_MBLNR_EXT;
        string id5_mt_gr_response;
        string id3_PO_DETAILS;
        string id23_PACKNO_EXT;
        string id32_SUB_PACKNO;
        string id12_COMM_FLAG;
        string id13_TYPE;
        string id31_EXTROW;
        string id14_MESSAGE;
        string id24_INTROW_EXT;
        string id16_MSG_DET;

        protected override void InitIDs() {
            id10_MBLNR = Reader.NameTable.Add(@"MBLNR");
            id6_urnpertaminagr = Reader.NameTable.Add(@"urn:pertamina:gr");
            id15_MSG_DETAILS = Reader.NameTable.Add(@"MSG_DETAILS");
            id11_MJAHR = Reader.NameTable.Add(@"MJAHR");
            id30_ZEKKN = Reader.NameTable.Add(@"ZEKKN");
            id8_MANDT = Reader.NameTable.Add(@"MANDT");
            id26_PACKNO = Reader.NameTable.Add(@"PACKNO");
            id7_GR_DETAILS = Reader.NameTable.Add(@"GR_DETAILS");
            id19_FRGKE = Reader.NameTable.Add(@"FRGKE");
            id18_EBELN = Reader.NameTable.Add(@"EBELN");
            id20_ITEMS = Reader.NameTable.Add(@"ITEMS");
            id25_NUMKN_EXT = Reader.NameTable.Add(@"NUMKN_EXT");
            id4_Item = Reader.NameTable.Add(@"");
            id34_EBELP = Reader.NameTable.Add(@"EBELP");
            id2_urnpertaminapo = Reader.NameTable.Add(@"urn:pertamina:po");
            id21_SERVICE = Reader.NameTable.Add(@"SERVICE");
            id27_INTROW = Reader.NameTable.Add(@"INTROW");
            id28_NUMKN = Reader.NameTable.Add(@"NUMKN");
            id22_POSRVACCESSVALUES = Reader.NameTable.Add(@"POSRVACCESSVALUES");
            id29_ZEKKN_EXT = Reader.NameTable.Add(@"ZEKKN_EXT");
            id33_EBELP_EXT = Reader.NameTable.Add(@"EBELP_EXT");
            id17_EBELN_EXT = Reader.NameTable.Add(@"EBELN_EXT");
            id1_mt_po_response = Reader.NameTable.Add(@"mt_po_response");
            id9_MBLNR_EXT = Reader.NameTable.Add(@"MBLNR_EXT");
            id5_mt_gr_response = Reader.NameTable.Add(@"mt_gr_response");
            id3_PO_DETAILS = Reader.NameTable.Add(@"PO_DETAILS");
            id23_PACKNO_EXT = Reader.NameTable.Add(@"PACKNO_EXT");
            id32_SUB_PACKNO = Reader.NameTable.Add(@"SUB_PACKNO");
            id12_COMM_FLAG = Reader.NameTable.Add(@"COMM_FLAG");
            id13_TYPE = Reader.NameTable.Add(@"TYPE");
            id31_EXTROW = Reader.NameTable.Add(@"EXTROW");
            id14_MESSAGE = Reader.NameTable.Add(@"MESSAGE");
            id24_INTROW_EXT = Reader.NameTable.Add(@"INTROW_EXT");
            id16_MSG_DET = Reader.NameTable.Add(@"MSG_DET");
        }
    }

    public abstract class XmlSerializer1 : System.Xml.Serialization.XmlSerializer {
        protected override System.Xml.Serialization.XmlSerializationReader CreateReader() {
            return new XmlSerializationReader1();
        }
        protected override System.Xml.Serialization.XmlSerializationWriter CreateWriter() {
            return new XmlSerializationWriter1();
        }
    }

    public sealed class ArrayOfObjectSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"mi_os_po", @"urn:pertamina:po");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write26_mi_os_po((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer1 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"mi_os_poResponse", @"urn:pertamina:po");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read26_mi_os_poResponse();
        }
    }

    public sealed class ArrayOfObjectSerializer2 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"mi_os_poInHeaders", @"urn:pertamina:po");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write27_mi_os_poInHeaders((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer3 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"mi_os_poResponseOutHeaders", @"urn:pertamina:po");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read27_mi_os_poResponseOutHeaders();
        }
    }

    public sealed class ArrayOfObjectSerializer4 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"mi_os_gr_pips", @"urn:pertamina:gr");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write28_mi_os_gr_pips((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer5 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"mi_os_gr_pipsResponse", @"urn:pertamina:gr");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read28_mi_os_gr_pipsResponse();
        }
    }

    public sealed class ArrayOfObjectSerializer6 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"mi_os_gr_pipsInHeaders", @"urn:pertamina:gr");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write29_mi_os_gr_pipsInHeaders((object[])objectToSerialize);
        }
    }

    public sealed class ArrayOfObjectSerializer7 : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"mi_os_gr_pipsResponseOutHeaders", @"urn:pertamina:gr");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read29_Item();
        }
    }

    public class XmlSerializerContract : global::System.Xml.Serialization.XmlSerializerImplementation {
        public override global::System.Xml.Serialization.XmlSerializationReader Reader { get { return new XmlSerializationReader1(); } }
        public override global::System.Xml.Serialization.XmlSerializationWriter Writer { get { return new XmlSerializationWriter1(); } }
        System.Collections.Hashtable readMethods = null;
        public override System.Collections.Hashtable ReadMethods {
            get {
                if (readMethods == null) {
                    System.Collections.Hashtable _tmp = new System.Collections.Hashtable();
                    _tmp[@"APIHost2host.PO_Services2.mi_os_poService:APIHost2host.PO_Services2.dt_po_responsePO_DETAILS[] mi_os_po(APIHost2host.PO_Services2.dt_po_requestPO_DETAILS[]):Response"] = @"Read26_mi_os_poResponse";
                    _tmp[@"APIHost2host.PO_Services2.mi_os_poService:APIHost2host.PO_Services2.dt_po_responsePO_DETAILS[] mi_os_po(APIHost2host.PO_Services2.dt_po_requestPO_DETAILS[]):OutHeaders"] = @"Read27_mi_os_poResponseOutHeaders";
                    _tmp[@"APIHost2host.GR_Services.mi_os_gr_pipsService:APIHost2host.GR_Services.dt_gr_responseGR_DETAILS[] mi_os_gr_pips(APIHost2host.GR_Services.dt_gr_requestGR_DETAILS[]):Response"] = @"Read28_mi_os_gr_pipsResponse";
                    _tmp[@"APIHost2host.GR_Services.mi_os_gr_pipsService:APIHost2host.GR_Services.dt_gr_responseGR_DETAILS[] mi_os_gr_pips(APIHost2host.GR_Services.dt_gr_requestGR_DETAILS[]):OutHeaders"] = @"Read29_Item";
                    if (readMethods == null) readMethods = _tmp;
                }
                return readMethods;
            }
        }
        System.Collections.Hashtable writeMethods = null;
        public override System.Collections.Hashtable WriteMethods {
            get {
                if (writeMethods == null) {
                    System.Collections.Hashtable _tmp = new System.Collections.Hashtable();
                    _tmp[@"APIHost2host.PO_Services2.mi_os_poService:APIHost2host.PO_Services2.dt_po_responsePO_DETAILS[] mi_os_po(APIHost2host.PO_Services2.dt_po_requestPO_DETAILS[])"] = @"Write26_mi_os_po";
                    _tmp[@"APIHost2host.PO_Services2.mi_os_poService:APIHost2host.PO_Services2.dt_po_responsePO_DETAILS[] mi_os_po(APIHost2host.PO_Services2.dt_po_requestPO_DETAILS[]):InHeaders"] = @"Write27_mi_os_poInHeaders";
                    _tmp[@"APIHost2host.GR_Services.mi_os_gr_pipsService:APIHost2host.GR_Services.dt_gr_responseGR_DETAILS[] mi_os_gr_pips(APIHost2host.GR_Services.dt_gr_requestGR_DETAILS[])"] = @"Write28_mi_os_gr_pips";
                    _tmp[@"APIHost2host.GR_Services.mi_os_gr_pipsService:APIHost2host.GR_Services.dt_gr_responseGR_DETAILS[] mi_os_gr_pips(APIHost2host.GR_Services.dt_gr_requestGR_DETAILS[]):InHeaders"] = @"Write29_mi_os_gr_pipsInHeaders";
                    if (writeMethods == null) writeMethods = _tmp;
                }
                return writeMethods;
            }
        }
        System.Collections.Hashtable typedSerializers = null;
        public override System.Collections.Hashtable TypedSerializers {
            get {
                if (typedSerializers == null) {
                    System.Collections.Hashtable _tmp = new System.Collections.Hashtable();
                    _tmp.Add(@"APIHost2host.PO_Services2.mi_os_poService:APIHost2host.PO_Services2.dt_po_responsePO_DETAILS[] mi_os_po(APIHost2host.PO_Services2.dt_po_requestPO_DETAILS[]):Response", new ArrayOfObjectSerializer1());
                    _tmp.Add(@"APIHost2host.PO_Services2.mi_os_poService:APIHost2host.PO_Services2.dt_po_responsePO_DETAILS[] mi_os_po(APIHost2host.PO_Services2.dt_po_requestPO_DETAILS[])", new ArrayOfObjectSerializer());
                    _tmp.Add(@"APIHost2host.GR_Services.mi_os_gr_pipsService:APIHost2host.GR_Services.dt_gr_responseGR_DETAILS[] mi_os_gr_pips(APIHost2host.GR_Services.dt_gr_requestGR_DETAILS[]):InHeaders", new ArrayOfObjectSerializer6());
                    _tmp.Add(@"APIHost2host.PO_Services2.mi_os_poService:APIHost2host.PO_Services2.dt_po_responsePO_DETAILS[] mi_os_po(APIHost2host.PO_Services2.dt_po_requestPO_DETAILS[]):InHeaders", new ArrayOfObjectSerializer2());
                    _tmp.Add(@"APIHost2host.GR_Services.mi_os_gr_pipsService:APIHost2host.GR_Services.dt_gr_responseGR_DETAILS[] mi_os_gr_pips(APIHost2host.GR_Services.dt_gr_requestGR_DETAILS[]):Response", new ArrayOfObjectSerializer5());
                    _tmp.Add(@"APIHost2host.GR_Services.mi_os_gr_pipsService:APIHost2host.GR_Services.dt_gr_responseGR_DETAILS[] mi_os_gr_pips(APIHost2host.GR_Services.dt_gr_requestGR_DETAILS[])", new ArrayOfObjectSerializer4());
                    _tmp.Add(@"APIHost2host.GR_Services.mi_os_gr_pipsService:APIHost2host.GR_Services.dt_gr_responseGR_DETAILS[] mi_os_gr_pips(APIHost2host.GR_Services.dt_gr_requestGR_DETAILS[]):OutHeaders", new ArrayOfObjectSerializer7());
                    _tmp.Add(@"APIHost2host.PO_Services2.mi_os_poService:APIHost2host.PO_Services2.dt_po_responsePO_DETAILS[] mi_os_po(APIHost2host.PO_Services2.dt_po_requestPO_DETAILS[]):OutHeaders", new ArrayOfObjectSerializer3());
                    if (typedSerializers == null) typedSerializers = _tmp;
                }
                return typedSerializers;
            }
        }
        public override System.Boolean CanSerialize(System.Type type) {
            if (type == typeof(global::APIHost2host.PO_Services2.mi_os_poService)) return true;
            if (type == typeof(global::APIHost2host.GR_Services.mi_os_gr_pipsService)) return true;
            return false;
        }
        public override System.Xml.Serialization.XmlSerializer GetSerializer(System.Type type) {
            return null;
        }
    }
}
