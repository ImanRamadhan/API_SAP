using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APIHost2host.Models.AppFrameworks;
using APIHost2host.Models.Response;
//using SAPProxy;

namespace APIHost2host.Models.MIROModel
{
    public class MiroPosting
    {
        public string Username { get; set; }
        public string InvoiceDate { get; set; }
        public string Reference { get; set; }
        public string PostingDate { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string TaxCode { get; set; }
        public string BusinessPlace { get; set; }
        public string Text { get; set; }
        public string NoPO { get; set; }
        public string BaselineDate { get; set; }
        public string PaymentTerms { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentReference { get; set; }

        public static async System.Threading.Tasks.Task<GeneralActionResponse<PostingMIROResponse>> postingMIROAsync(MiroPosting request)
        {
            LogModel log = new LogModel();

            try
            {
                var result = new GeneralActionResponse<PostingMIROResponse>();
                string jsonMiro = string.Empty;
                string xmlMiro = string.Empty;



                //insert logging posting MIRO
                await log.InsertLogToService(request.Username, "Request Posting MIRO", jsonMiro, xmlMiro);

                return result;
            }
            catch (Exception ex)
            {
                var final = new GeneralActionResponse<PostingMIROResponse>()
                {
                    ResponseCode = "99",
                    ResponseMessages = "Error Exception : " + ex.Message.ToString()
                };

                return final;
            }
        }
    }
}