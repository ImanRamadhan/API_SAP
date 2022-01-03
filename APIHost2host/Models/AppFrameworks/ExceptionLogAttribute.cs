using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using APIHost2Host.Helper;
using System.Text;
using System.Net;

namespace APIHost2host.Models.AppFrameworks
{
    public class ExceptionLogAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            try
            {
                string rawRequest;

                using (var stream = new MemoryStream())
                {
                    var context = (HttpContextBase)actionExecutedContext.Request.Properties["MS_HttpContext"];
                    context.Request.InputStream.Seek(0, SeekOrigin.Begin);
                    context.Request.InputStream.CopyTo(stream);
                    rawRequest = Encoding.UTF8.GetString(stream.ToArray());
                }

                var log = new LogModel()
                {
                    IPAddress = actionExecutedContext.Request.GetClientIpAddress() ?? HttpContext.Current.Request.UserHostAddress,
                    HostName = HttpContext.Current.Request.UserHostName,
                    RequestUrl = actionExecutedContext.Request.RequestUri.AbsoluteUri,
                    Method = actionExecutedContext.Request.Method,
                    RequestContent = rawRequest,
                    ErrorMessage = actionExecutedContext.Exception.GetBaseException().Message + Environment.NewLine + actionExecutedContext.Exception.GetBaseException().StackTrace,
                    Type = "E"
                };
            }
            catch
            {

            }
            actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Internal Server Error");

            //base.OnException(actionExecutedContext);
        }
    }

    
}