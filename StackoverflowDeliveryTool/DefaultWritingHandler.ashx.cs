using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace StackoverflowDeliveryTool
{
    /// <summary>
    /// Summary description for DefaultWritingHandler
    /// </summary>
    public class DefaultWritingHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string from = context.Request.QueryString["from"]??DateTime.Now.AddDays(-7).ToString();
            string to= context.Request.QueryString["to"]??DateTime.Now.ToString();
            string owner = context.Request.QueryString["owner"] ?? "all";
            string status = context.Request.QueryString["status"] ?? "All";
            string scenario = context.Request.QueryString["scenario"] ?? "all";
            string delivery = context.Request.QueryString["delivery"] ?? "3";
            string content = "{"+$"'from':'{from}','to':'{to}','owner':'{owner}','status':'{status}','scenario':'{scenario}','delivery':'{delivery}'"+"}";

            var path = $"{HttpRuntime.AppDomainAppPath}js\\PageJS\\loadDefault.json";

            StreamWriter file = new StreamWriter(path);
            file.Write(content);
            file.Close();
           // var stream =  File.Open($"{Server}js/PageJS/loadDefault.json",FileMode.Open);
           // StreamWriter sw = new StreamWriter(stream);
           //sw.Write(content);

            context.Response.ContentType = "text/plain";
            context.Response.Write("Set successfully!");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}