using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIHost2host.Models.Master
{
    public class MaterialItem
    {
        public string ItemID { get; set; }
        public string PRNumber { get; set; }
        public string SAPKONNR { get; set; }
        public string SAPKTPNR { get; set; }
        public string PRItem { get; set; }
        public string ReqID { get; set; }
        public string SeqItem { get; set; }
        public string MATNR { get; set; }
        public string MatPartNo { get; set; }
        public string MATDesc { get; set; }
        public string UoM { get; set; }
        public string MATType { get; set; }
        public string Qty { get; set; }
        public string Actual_Qty { get; set; }
        public string HargaSatuan { get; set; }
        public string QtySent { get; set; }
        public string MATDescDetail { get; set; }
        public decimal HargaTotal
        {
            get
            {
                return Decimal.Parse(Actual_Qty) * Decimal.Parse(HargaSatuan);
            }
        }
    }
}