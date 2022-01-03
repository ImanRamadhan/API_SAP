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
using APIHost2host.Models.ProcurementModel;

namespace APIHost2host.Controllers
{
    public class VendorController : ApiController
    {
        /// <summary>
        /// Get Vendor Code By Company Code
        /// </summary>
        /// <param name="pageSize">jumlah item dalam 1 page</param>
        /// <param name="pageIndex">index page yang ingin ditampilkan</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(GeneralActionResponse<VendorModel>))]
        public HttpResponseMessage getVendorCodePDSI(string totalVendor)
        {
            return Request.CreateResponse<List<string>>(VendorModel.GetVendorCodeByCompanyCode(totalVendor));
        }

        /// <summary>
        /// Get Data All Vendor PDSI
        /// </summary>
        /// <param name="pageSize">jumlah item dalam 1 page</param>
        /// <param name="pageIndex">index page yang ingin ditampilkan</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(GeneralActionResponse<VendorModel>))]
        public HttpResponseMessage getDataVendorPDSI(string totalVendor)
        {
            var result = new GeneralActionResponse<VendorModel>();

            return Request.CreateResponse<GeneralActionResponse<VendorModel>>(VendorModel.getDataVendor(result, totalVendor));
        }

        /// <summary>
        /// Get Data Performance Vendor PDSI
        /// </summary>
        /// <param name="pageSize">jumlah item dalam 1 page</param>
        /// <param name="pageIndex">index page yang ingin ditampilkan</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(GeneralActionResponse<VendorModel>))]
        public HttpResponseMessage getDataPerformanceVendorPDSI(string totalVendor)
        {
            var result = new GeneralActionResponse<VendorModel>();

            return Request.CreateResponse<GeneralActionResponse<VendorModel>>(VendorModel.getVendorPerformance(result, totalVendor));
        }

        /// <summary>
        /// Get Data Profile Vendor PDSI
        /// </summary>
        /// <param name="pageSize">jumlah item dalam 1 page</param>
        /// <param name="pageIndex">index page yang ingin ditampilkan</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(GeneralActionResponse<VendorProfileModel>))]
        public HttpResponseMessage getDataProfileVendorPDSI(string totalVendor)
        {
            var result = new GeneralActionResponse<VendorProfileModel>();

            return Request.CreateResponse<GeneralActionResponse<VendorProfileModel>>(VendorProfileModel.getDataProfileVendor(result, totalVendor));
        }

        /// <summary>
        /// Get Data Bidder List By Collective Number
        /// </summary>
        /// <param name="pageSize">jumlah item dalam 1 page</param>
        /// <param name="pageIndex">index page yang ingin ditampilkan</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(GeneralActionResponse<VendorModel>))]
        public HttpResponseMessage getBidderListByCollectiveNumber(string collectiveNumber)
        {
            var result = new GeneralActionResponse<VendorModel>();

            return Request.CreateResponse<GeneralActionResponse<VendorModel>>(VendorModel.getBidderListByCollectiveNumber(result, collectiveNumber));
        }
    }
}