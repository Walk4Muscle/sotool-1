using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace StackoverflowDeliveryTool.Handler
{
    /// <summary>
    /// Summary description for CollectFeedbackHandler
    /// </summary>
    public class CollectFeedbackHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                var path = $"{HttpRuntime.AppDomainAppPath}feedback.csv";
                string owner = context.Request.QueryString["user"] ?? "default";
                string feedback = context.Request.QueryString["feedback"] ?? "default";
                FileStream file = File.Open(path, FileMode.Append, FileAccess.Write, FileShare.Write);
                var content = "Onwer:" + owner + ", feedback:" + feedback+"\r\n";
                StreamWriter sr = new StreamWriter(file);
                sr.Write(content);
                sr.Close();
                file.Close();

                context.Response.ContentType = "text/json";
                context.Response.Write("ok");
            }
            catch (Exception)
            {

                throw;
            }
           
           
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}