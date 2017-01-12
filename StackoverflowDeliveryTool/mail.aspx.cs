using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
namespace StackoverflowDeliveryTool
{
    public partial class mail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Services.WebMethod]
        public static string SendEmail(string subject,string comment,string link, string messageId,string useralias,string ttitle,string points)

        {
            string msgbody;
       
            if ("v-"== useralias.Substring(0,2))
            {
                 msgbody = "<!DOCTYPE html><html><body><table border = 1 style =\"border-collapse: collapse; border: 1px orange; \">" +
                                 "<tr><th colspan=2 style=\"background-color:orange\">Review comments by Support Engineer</th></tr>" +
                                 "<tr><td style =\"width:80px\">Thread Title:</td><td \"width:auto\">" + ttitle + "</td></tr>" +
                                 "<tr><td style=\"width:80px\">Thread link:</td><td \"width:auto\">" + link + "</td></tr><tr><td style=\"width:80px\">" +
                                  "Points:</td><td \"width:auto\">" + points + "</td></tr>" +
                                 "<tr><td style=\"width:80px\">Comment:</td><td \"width:auto\">" + comment + "</td></tr>" +
                                 "<tr><td style =\"width:80px\">Comment by:</td><td \"width:auto\">" + useralias + "</td></tr>" +
                                 "<tr><td style =\"width:80px\">Comment time:</td><td \"width:auto\">" + DateTime.Now.ToString() + "</td></tr>" +
                                 "<tr><td colspan=2>Please Visit the link mentioned above and take appropriate action as soon as possible.</td>" +
                                 "</tr><tr><td colspan=2>Best Regards,<br/>MSDN Support Team</td></tr></table></body></html>";
            }
            else
            { 
                msgbody= "<!DOCTYPE html><html><body><table border = 1 style =\"border-collapse: collapse; border: 1px orange; \">" +
                                  "<tr><th colspan=2 style=\"background-color:orange\">Review comments by FTE</th></tr>" +
                                  "<tr><td style =\"width:80px\">Thread Title:</td><td \"width:auto\">" + ttitle + "</td></tr>" +
                                  "<tr><td style=\"width:80px\">Thread link:</td><td \"width:auto\">" + link + "</td></tr><tr><td style=\"width:80px\">" +
                                   "Points:</td><td \"width:auto\">" + points + "</td></tr>" +
                                  "<tr><td style=\"width:80px\">Comment:</td><td \"width:auto\">" + comment + "</td></tr>" +
                                  "<tr><td style =\"width:80px\">Comment by:</td><td \"width:auto\">" + useralias + "</td></tr>" +
                                  "<tr><td style =\"width:80px\">Comment time:</td><td \"width:auto\">" + DateTime.Now.ToString() + "</td></tr>" +
                                  "<tr><td colspan=2>Please Visit the link mentioned above and take appropriate action as soon as possible.</td>" +
                                  "</tr><tr><td colspan=2>Best Regards,<br/>MSDN Support Team</td></tr></table></body></html>";
            }
            using (MailMessage mm = new MailMessage("deepakpanchal10@outlook.com", messageId))
            //"dpanchal620@gmail.com"
            {

                mm.Subject = subject;

                mm.Body = msgbody;

                //if (fuAttachment.HasFile)

                //{

                //    string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);

                //    mm.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));

                //}

                mm.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.live.com";
                // "smtp - mail.outlook.com";//"smtp.gmail.com";

                smtp.EnableSsl = true;
                smtp.DeliveryMethod= SmtpDeliveryMethod.Network;

                NetworkCredential NetworkCred = new NetworkCredential("deepakpanchal10@outlook.com", "Xcd9974235817$$");//Xcd9974235817

                
                smtp.UseDefaultCredentials = true;

                smtp.Credentials = NetworkCred;

                smtp.Port = 587;
                try
                {
                    smtp.Send(mm);
                    return "mail sent";
                }
                catch(Exception e)
                {
                    Console.Write(e.ToString());
                    return e.ToString();
                }
                
                // ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);

            }

        }
    }
}