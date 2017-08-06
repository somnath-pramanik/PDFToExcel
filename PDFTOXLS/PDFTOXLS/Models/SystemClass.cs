using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace PDFTOXLS.Models
{
    public class SystemClass : IDisposable
    {

        public static string GetUserName()
        {
            string userID = "";
            HttpCookie myCookie = HttpContext.Current.Request.Cookies[".ASPXAUTH"];
            if (myCookie != null)
            {
                string value = myCookie.Value;
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(value);
                userID = Convert.ToString(ticket.Name);
            }
            return userID;
        }
        public string GetLoggedUser()
        {
            string userID = "";
            HttpCookie myCookie = HttpContext.Current.Request.Cookies[".ASPXAUTH"];
            if (myCookie != null)
            {
                string value = myCookie.Value;
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(value);
                userID = Convert.ToString(ticket.Name);
            }
            return userID;
        }

        public Int32 LogoutUser()
        {
            Int32 userID = 0;
            HttpCookie myCookie = HttpContext.Current.Request.Cookies[".ASPXAUTH"];
            if (myCookie != null)
            {
                myCookie.Expires = DateTime.Now;
                userID = 1;
            }
            return userID;
        }

        public void Dispose()
        {
        }

        // public int SY_ULEVEL1()
        //{
        //    MainContext _mc = new MainContext();
        //     string LEVEL_STR = _mc.EX_USER.Where(c => c.EXUSER == SystemClass.GetUserName()).Select(c => c.LAVEL).FirstOrDefault();
        //    int SY_ULEVEL1 =0;
        //     if (LEVEL_STR.Contains("1,"))
        //                SY_ULEVEL1 = 1;
        //            else
        //                SY_ULEVEL1 = 0;
        //     return SY_ULEVEL1;
        //}

    }
}