using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIHost2host.Models.Response
{
    public class CreatePOResponse
    {
        public string PONumber { get; set; }
        public string MANDT { get; set; }
        public string EBELN_EXT { get; set; }
        public string EBELN { get; set; }
        public string FRGKE { get; set; }
        public string COMM_FLAG { get; set; }
        public string TYPE { get; set; }
        public string MESSAGE { get; set; }
    }
}