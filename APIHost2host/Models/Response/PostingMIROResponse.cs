using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIHost2host.Models.Response
{
    public class PostingMIROResponse
    {
        public string RetType { get; set; }
        public string ID { get; set; }
        public string Number { get; set; }
        public string Message { get; set; }
        public string Log_No { get; set; }
        public string Log_Msg_No { get; set; }
        public string Message_V1 { get; set; }
        public string Message_V2 { get; set; }
        public string Message_V3 { get; set; }
        public string Message_V4 { get; set; }
        public string Parameter { get; set; }
        public int Row { get; set; }
        public string Field { get; set; }
        public string System { get; set; }
    }
}