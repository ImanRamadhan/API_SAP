using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using APIHost2host.Models.POModel;
using APIHost2host.Models.AppFrameworks;
using APIHost2host.Models.Response;
using System.Web.Http.Description;
using System.Web.Services.Protocols;
using System.IO;
using System.Web.Script.Serialization;
using APIHost2host.Models.RFQModel;

namespace APIHost2host.Controllers
{
    public class POController : ApiController
    {
        /// <summary>
        /// Inquiry Collective Number
        /// </summary>
        /// <param name="pageSize">jumlah item dalam 1 page</param>
        /// <param name="pageIndex">index page yang ingin ditampilkan</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(GeneralActionResponse<BidderListHeader>))]
        public HttpResponseMessage inquiryCollectiveNumber(string collectiveNumber)
        {
            var result = new GeneralActionResponse<BidderListHeader>();

            return Request.CreateResponse<GeneralActionResponse<BidderListHeader>>(BidderListHeader.getBidderListFromSAP(result, collectiveNumber));
        }

        /// <summary>
        /// Inquiry RFQ Number
        /// </summary>
        /// <param name="pageSize">jumlah item dalam 1 page</param>
        /// <param name="pageIndex">index page yang ingin ditampilkan</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(GeneralActionResponse<RFQHeader>))]
        public HttpResponseMessage inquiryRFQNumber(string RFQNumber)
        {
            var result = new GeneralActionResponse<RFQHeader>();

            return Request.CreateResponse<GeneralActionResponse<RFQHeader>>(RFQHeader.getRFQHeader(result, RFQNumber));
        }

        /// <summary>
        /// Inquiry Purchase Order
        /// </summary>
        /// <param name="pageSize">jumlah item dalam 1 page</param>
        /// <param name="pageIndex">index page yang ingin ditampilkan</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(GeneralActionResponse<InquiryPOResponse>))]
        public HttpResponseMessage inquiryPO(string PONumber)
        {
            var result = new GeneralActionResponse<InquiryPOResponse>();

            return Request.CreateResponse<GeneralActionResponse<InquiryPOResponse>>(InquiryPO.inquiryPO(result, PONumber));
        }

        /// <summary>
        /// Create Purchase Order
        /// </summary>
        /// <param name="requestPO">Data PO</param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(GeneralActionResponse<CreatePOResponse>))]
        public async System.Threading.Tasks.Task<HttpResponseMessage> createPurchaseOrder(RequestPO request)
        {
            LogModel log = new LogModel();
            var result = new GeneralActionResponse<CreatePOResponse>();
            try
            {
                result = await RequestPO.createPOAsync(request);
            }
            catch (SoapException e)
            {
                result.ResponseMessages = "Failed create PO : " + e.Message;
            }

            return Request.CreateResponse<GeneralActionResponse<CreatePOResponse>>(HttpStatusCode.OK, result);
        }
        
    }
}