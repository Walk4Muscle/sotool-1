using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace TagSpecifiedDataOperation
{
     class sendmail
    {//object sender, EventArgs e
        public void SendEmail()

        {

            using (MailMessage mm = new MailMessage("dpanchal620@gmail.com", "v-padee@microsoft.com"))

            {

                mm.Subject = "Review Report";

                mm.Body = "This is the Review of the case owned by you.";

                //if (fuAttachment.HasFile)

                //{

                //    string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);

                //    mm.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));

                //}

                mm.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.gmail.com";

                smtp.EnableSsl = true;

                NetworkCredential NetworkCred = new NetworkCredential("dpanchal620@gmail.com", "Xcd9974235817");

                smtp.UseDefaultCredentials = true;

                smtp.Credentials = NetworkCred;

                smtp.Port = 587;

                smtp.Send(mm);

               // ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);

            }

        }
    }
}
