using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIHost2host.Models.Response
{
    public class CreateGRResponse
    {
        public string GRNumber { get; set; }
        public string MANDT { get; set; }
        public string MBLNR_EXT { get; set; }
        public string MBLNR { get; set; }
        public string MJAHR { get; set; }
        public string COMM_FLAG { get; set; }
        public string TYPE { get; set; }
        public string MESSAGE { get; set; }
    }
}