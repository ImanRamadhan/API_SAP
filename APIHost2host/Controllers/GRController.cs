using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using APIHost2host.Models.GRModel;
using APIHost2host.Models.AppFrameworks;
using System.Web.Http.Description;
using System.Web.Services.Protocols;
using APIHost2host.Models.Response;

namespace APIHost2host.Controllers
{
    public class GRController : ApiController
    {
        /// <summary>
        /// Create Good Receipt
        /// </summary>
        /// <param name="requestGR">Data GR</param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(GeneralActionResponse<CreateGRResponse>))]
        public async System.Threading.Tasks.Task<HttpResponseMessage> createGoodReceipt(RequestGR request)
        {
            var result = new GeneralActionResponse<CreateGRResponse>();
            try
            {
                result = await RequestGR.createGRAsync(request);
            }
            catch (SoapException e)
            {
                result.ResponseCode = "99";
                result.ResponseMessages = "failed create GR : " + e.Message;
            }

            return Request.CreateResponse<GeneralActionResponse<CreateGRResponse>>(HttpStatusCode.OK, result);
        }
    }
}