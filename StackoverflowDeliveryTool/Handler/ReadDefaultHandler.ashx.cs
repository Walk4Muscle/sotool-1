using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace StackoverflowDeliveryTool.Handler
{
    /// <summary>
    /// Summary description for ReadDefaultHandler
    /// </summary>
    public class ReadDefaultHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var path = $"{HttpRuntime.AppDomainAppPath}js\\PageJS\\loadDefault.json";

            StreamReader file = new StreamReader(path);
            var content = file.ReadToEnd();
            file.Close();
            context.Response.ContentType = "text/json";
            context.Response.Write(content);
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