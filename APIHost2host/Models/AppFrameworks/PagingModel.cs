using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIHost2host.Models.AppFrameworks
{
    public class PagingModel<T> where T : new()
    {
        public Int64 TotalRow { get; set; }
        //public int PageIndex { get; set; }
        //public int PageSize { get; set; }
        //public List<KeyValue> QueryList { get; set; }
        //public string Query { get; set; }

        public string RespMessages { get; set; }
        public List<T> Records { get; set; }

        public void SetRecords(List<T> list)
        {
            Records = new List<T>();
            list.ForEach(t => Records.Add(t));
        }
    }
}