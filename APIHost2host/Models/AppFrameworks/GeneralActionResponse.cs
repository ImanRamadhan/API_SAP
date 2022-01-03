using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIHost2host.Models.AppFrameworks
{
    public class GeneralActionResponse<T> where T : new()
    {
        public string ResponseCode { get; set; }
        public string ResponseMessages { get; set; }
        public Int64 TotalRow { get; set; }
        public List<T> ResponseData { get; set; }
        public void SetRecords(List<T> list)
        {
            ResponseData = new List<T>();
            list.ForEach(t => ResponseData.Add(t));
        }
    }
}