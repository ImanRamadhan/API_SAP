using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Data.SqlClient;
using APIHost2Host.Helper;
using System.IO;
using System.Threading.Tasks;

namespace APIHost2host.Models.AppFrameworks
{
    public class LogModel
    {
        public string IPAddress { get; set; }
        public string HostName { get; set; }
        public string RequestUrl { get; set; }
        public HttpMethod Method { get; set; }
        public string RequestContent { get; set; }
        public string ResponseContent { get; set; }
        public string Type { get; set; }
        public string ErrorMessage { get; set; }

        public async Task InsertLogToService(string createdBy, string method, string log, string log2)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["UrlLOGService"].ToString());
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Authentication", 
                System.Configuration.ConfigurationManager.AppSettings["TokenLOGService"].ToString());
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Request request = new Request
            {
                CreatedBy = createdBy,
                Aplikasi = "API SAP",
                Method = method,
                Log = log,
                Log2 = log2
            };
            
            HttpResponseMessage response = await client.PostAsJsonAsync(
                                                                System.Configuration.ConfigurationManager.AppSettings["PosturlLog"].ToString(), 
                                                                request);
            response.EnsureSuccessStatusCode();
        }

        public void InsertLog(string text)
        {
            //logic insert log to mongoDB
            string path = @"c:\temp\MyTest.txt";

            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                string createText = text + Environment.NewLine;
                File.WriteAllText(path, createText);
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            string appendText = text + Environment.NewLine;
            File.AppendAllText(path, appendText);
        }
    }

    public class Request
    {
        public string CreatedBy { get; set; }
        public string Aplikasi { get; set; }
        public string Method { get; set; }
        public string Log { get; set; }
        public string Log2 { get; set; }
    }
}