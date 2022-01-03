using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using APIHost2host.Models.PRModel;
using APIHost2host.Models.AppFrameworks;
using APIHost2host.Models.Response;
using System.Web.Http.Description;
using System.Web.Services.Protocols;

namespace APIHost2host.Controllers
{
    public class PRController : ApiController
    {
        /// <summary>
        /// Inquiry Prequitision Order
        /// </summary>
        /// <param name="pageSize">jumlah item dalam 1 page</param>
        /// <param name="pageIndex">index page yang ingin ditampilkan</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(GeneralActionResponse<InquiryPRResponse>))]
        public HttpResponseMessage inquiryPR(string PRNumber)
        {
            var result = new GeneralActionResponse<InquiryPRResponse>();

            return Request.CreateResponse<GeneralActionResponse<InquiryPRResponse>>(InquiryPR.inquiryPR(result, PRNumber));
        }
    }
}