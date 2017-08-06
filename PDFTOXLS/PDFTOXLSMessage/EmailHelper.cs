using System;
using System.Collections.Generic;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.IO;
using System.Data.Entity;
using System.Linq;
using PDFTOXLS.Models;

namespace TicketMessage
{
    public class EmailHelper
    {
        public void SendUserEmail(string ToEmail, string Subject, string Message)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            try
            {
                string server_domain = ConfigurationManager.AppSettings["DomainName"];
                string mailFrom = ConfigurationManager.AppSettings["VerificationSenderEmail"];
                string password = ConfigurationManager.AppSettings["EmailPassword"];
                int emailport = Convert.ToInt32(ConfigurationManager.AppSettings["EmailPort"]);
                string dispname = ConfigurationManager.AppSettings["dispname"];
                mail.From = new MailAddress(mailFrom, dispname);
                mail.To.Add(ToEmail);
                mail.Subject = Subject;
                mail.Body = Message;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.Normal;
                smtp.Host = server_domain;
                smtp.Port = emailport;
                smtp.Credentials = new System.Net.NetworkCredential(mailFrom, password);
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (SmtpFailedRecipientsException ex)
            {
                for (int i = 0; i <= ex.InnerExceptions.Length; i++)
                {
                    SmtpStatusCode status = ex.InnerExceptions[i].StatusCode;
                    if ((status == SmtpStatusCode.MailboxBusy) | (status == SmtpStatusCode.MailboxUnavailable))
                    {
                        System.Threading.Thread.Sleep(5000);
                        smtp.Send(mail);

                    }
                }

            }
            catch (Exception e)
            {
                e.Message.ToString();
            }

        }

        public string forgotPasswordMailBody(string tomailid)
        {
            MainContext _mc = new MainContext();
            var usrdtls = (from usr in _mc.Ex_user_new.Where(x => x.E_MAIL == tomailid)
                           select new
                           {
                               USER_FNAME = usr.USER_FNAME,
                               USER_LNAME = usr.USER_LNAME,
                               PASS = usr.PASS
                           }).FirstOrDefault();

            string firstname = usrdtls.USER_FNAME;
            string lastname = usrdtls.USER_LNAME;
            string pwd = usrdtls.PASS;
            var xx = new ExactllyEnc.ExactllyEncrypt();
            string dpwd = xx.E_CRYPT(pwd.ToString().Trim(), "D");
            string str_directory = HttpContext.Current.Server.MapPath("~/PDFTOXLS");
            var gparent = Directory.GetParent(Directory.GetParent(str_directory).ToString());
            string body = string.Empty;
            StreamReader reader = new StreamReader(gparent + "\\TicketMessage\\EmailTemplate\\ForgotPasswordTemplate.html");
            body = reader.ReadToEnd();
            body = body.Replace("##PWD##", dpwd);
            return body;
        }
    }
}
