using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Data.Entity;
using PDFTOXLS.Models;
namespace PDFTOXLS.Controllers
{
    
    public class DashboardController : BaseController
    {
        MainContext _mc = new MainContext();
        [Authorize]
        public void Initpage()
        {
            try
            {
                SystemClass sclass = new SystemClass();
                string userID = sclass.GetLoggedUser();


                if (userID != null && userID != "")
                {

                    string[] pair = userID.Split(new[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                    string email = pair[0];
                    string passwordHash = pair[1];
                    string timezoneoffset = pair[2];
                    Ex_user_new currUser = _mc.Ex_user_new.SingleOrDefault(c => c.E_MAIL == email && c.UserStatus == UserStatus.Active);

                    if (currUser != null)
                    {
                        Session["user"] = currUser.USR_ID;
                        Session["UserName"] = currUser.USER_FNAME;
                        Session["timezoneoffset"] = timezoneoffset.Trim();
                        ViewBag.DashboardCssClass = "active";
                        ViewBag.UserName = currUser.FullName;
                        ViewBag.userimage = currUser.UserImg;
                        ViewBag.CurrentUser = currUser;
                    }
                }
                else
                {

                    Response.Redirect("~/Home/Index");
                }



               
            }
            catch
            {
               
            }

        }
        public ActionResult Index()
        {
           
            return View();
        }
         [Authorize]
        public ActionResult Dashboard()
        {
            Initpage();
            try
            {
                string SiteRoot = System.Configuration.ConfigurationManager.AppSettings["SiteRoot"];
                ViewBag.SiteRoot = SiteRoot;
                //AuthSite();
                string query = "SELECT  Id,Username=isnull((select USER_FNAME+''+ USER_LNAME from ex_user_new where USR_ID=L.UserId),''),pdffilename,xlsfilename,datecreated FROM  (SELECT  ROW_NUMBER() OVER (ORDER BY   ##ID##   ##desc##) as row,* FROM PdfConvertRecord  WHERE  UserId="+CurrentUser.USR_ID+" and  ##filters## ) L   Where   ##paging##  ";
                ////SELECT  Count(*)  FROM Leads L WHERE isconverted=0 and OwnerID =" + CurrentUser.Id + "  ##filters##";
                ViewBag.query = query;
               
            }

            catch
            {

            }

            return View();
        }

        public ActionResult ConverPdfToExcel()
        {
            int userid = CurrentUser.USR_ID;
            ViewBag.userid = userid;
            return View();
         }
      
  
    }
}
