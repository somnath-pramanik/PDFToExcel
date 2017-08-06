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
using PDFTOXLS.Helper.Security;
using Newtonsoft.Json;
using PDFTOXLS.Helper;



namespace PDFTOXLS.Controllers
{
    public class HomeController : Controller
    {
        //private CompanyContext db = new CompanyContext();
        private MainContext dbmain = new MainContext();
        public ActionResult Index()
        {
            SystemClass sclass = new SystemClass();
            string userID = sclass.GetLoggedUser();


            if (userID != null && userID!="")
            {

                string[] pair = userID.Split(new[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                string email = pair[0];
                string passwordHash = pair[1];
                string timezoneoffset = pair[2];
                Ex_user_new currUser = dbmain.Ex_user_new.SingleOrDefault(c => c.E_MAIL == email && c.UserStatus == UserStatus.Active);

                if (currUser != null)
                {
                    Session["user"] = currUser.USR_ID;
                    Session["UserName"] = currUser.USER_FNAME;
                    Session["timezoneoffset"] = timezoneoffset.Trim();
                    // Response.Redirect(FormsAuthentication.GetRedirectUrl(currUser.USER_FNAME, true));
                    //return Redirect("~/Dashboard/Dashboard");
                    // Response.Redirect("~/Dashboard/Dashboard");
                    //return View();
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(Ex_user_new User, string ReturnURL="")
        {
            SystemClass sclass = new SystemClass();
            string userID = sclass.GetLoggedUser();


            if (userID != null && userID != "")
            {

                string[] pair = userID.Split(new[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                string email = pair[0];
                string passwordHash = pair[1];
                string timezoneoffset = pair[2];
                Ex_user_new currUser = dbmain.Ex_user_new.SingleOrDefault(c => c.E_MAIL == email && c.UserStatus == UserStatus.Active);

                if (currUser != null)
                {
                    Session["user"] = currUser.USR_ID;
                    Session["UserName"] = currUser.USER_FNAME;
                    Session["timezoneoffset"] = timezoneoffset.Trim();
                    // Response.Redirect(FormsAuthentication.GetRedirectUrl(currUser.USER_FNAME, true));
                    return View("../Dashboard/Dashboard");
                    // Response.Redirect("~/Dashboard/Dashboard");
                    //return View();
                }
            }


            var loggeduser = dbmain.Ex_user_new.SingleOrDefault(c => c.E_MAIL == User.E_MAIL && c.UserStatus==UserStatus.Active);
            if (loggeduser == null)
            {
                ViewBag.Message = "Invalid Credential!!!  Or User Access Is Not Define for This User !!!";
                return View();
            }
            if (loggeduser.rolemaster == null)
            {
                ViewBag.Message = "User Access Is Not Define for This User !!!";
                return View();
            }

            //string loggedLocation = "";
            //loggedLocation = emp_head.BR_INIT;
            var xx = new ExactllyEnc.ExactllyEncrypt();
            //Session["Company"] = null;
            Session["user"] = loggeduser.USR_ID;

            //   Session["GroupId"] = loggeduser.Group.ID; //loggeduser.USERGROUP;

            Session["UserName"] = loggeduser.USER_FNAME;
            Session["timezoneoffset"] = Request.Form["timezoneoffset"];
            // ViewBag.Message =


            if (loggeduser == null)
            {
                ViewBag.Message = "Invalid Credential!!!";
                return View();
            }
            else
            {
                string dpwd = xx.E_CRYPT(loggeduser.PASS.ToString().Trim(), "D");
                if (User.PASS != dpwd)
                {
                    ViewBag.Message = "Invalid Credential!!!";
                    return View();
                }
                else
                {

                    MainContext _mc = new MainContext();
                    USERLOG usrlog = new USERLOG();

                    usrlog.user_id = loggeduser.USR_ID;

                    usrlog.EENT_DATE = DateTime.Now;
                    usrlog.EOUT_DATE = new DateTime(1900, 1, 1);
                    _mc.USERLOG.Add(usrlog);
                    _mc.SaveChanges();

                    HttpCookie AuthCookie;

                    //System.Web.Security.FormsAuthentication.SetAuthCookie(loggeduser.FullName.ToString(), true);
                    //AuthCookie = System.Web.Security.FormsAuthentication.GetAuthCookie(loggeduser.FullName.ToString(), true);


                    System.Web.Security.FormsAuthentication.SetAuthCookie(loggeduser.E_MAIL + "||" + loggeduser.PASS + "||" + Request.Form["timezoneoffset"], true);
                    AuthCookie = System.Web.Security.FormsAuthentication.GetAuthCookie(loggeduser.E_MAIL + "||" + loggeduser.PASS + "||" + Request.Form["timezoneoffset"], true);
                    AuthCookie.Expires = DateTime.Now.Add(new TimeSpan(130, 0, 0, 0));
                    Response.Cookies.Add(AuthCookie);
                    Response.Redirect(FormsAuthentication.GetRedirectUrl(loggeduser.FullName.ToString(), true));




                    // check if cookie exists and if yes update
                   // HttpCookie existingCookie = Request.Cookies["TicketAuthCookie"];
                    //if (existingCookie != null)
                    //{
                    //    // force to expire it
                    //    existingCookie.Value = loggeduser.E_MAIL + "||" + loggeduser.PASS + "||" + Request.Form["timezoneoffset"];
                    //    existingCookie.Expires = DateTime.Now.AddHours(-20);
                    //}

                    // create a cookie
                    //HttpCookie newCookie = new HttpCookie("TicketAuthCookie", loggeduser.E_MAIL + "||" + loggeduser.PASS + "||" + Request.Form["timezoneoffset"]);
                    //newCookie.Expires = DateTime.Today.AddDays(12);
                    //Response.Cookies.Add(newCookie);

                    // string userID = "";
                    // HttpCookie AuthCookie;
                    // System.Web.Security.FormsAuthentication.SetAuthCookie(loggeduser.USER_FNAME.ToString(), true);
                    // AuthCookie = System.Web.Security.FormsAuthentication.GetAuthCookie(loggeduser.USER_FNAME.ToString(), true);
                    // SystemClass sclass = new SystemClass();
                    // userID = sclass.GetLoggedUser();
                    // AuthCookie.Expires = DateTime.Now.AddDays(365);
                    // Response.Cookies.Add(AuthCookie);
                    // Response.Redirect(FormsAuthentication.GetRedirectUrl(loggeduser.USER_FNAME.ToString(), true));
                   // Response.Redirect("~/Dashboard/Dashboard");
                    // Response.Redirect("~/Setup/LayoutDefine");

                }

                return View();
            }
        }
        [HttpPost]
        public ActionResult ForgotPassword(string email)
        {
            ViewBag.E_MAIL = email;
            return View();
        }
        [HttpPost]
        public void SendMailtoUser()
        {

            string tomailid = Request.Form["emailid"];
            if (tomailid == "")
            {
                Response.Redirect("~/Home/ForgotPassword");
            }
            else if (tomailid != "")
            {
                MainContext _mc = new MainContext();
                var usrdtls = _mc.Ex_user_new.Where(x => x.E_MAIL == tomailid).ToList();
                if (usrdtls.Count() > 0)
                {
                    EmailHelper emailHelper = new EmailHelper();
                    string Subject = "Forgot Password Mail";
                    string mailBody = emailHelper.forgotPasswordMailBody(tomailid);
                    emailHelper.SendUserEmail(tomailid, Subject, mailBody);
                    Response.Redirect("~/Home/Index");
                }
                else
                {
                    Response.Redirect("~/Home/ForgotPassword");
                }
            }

        }

        [AllowAnonymous]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            // HttpCookie existingCookie = Request.Cookies["TicketAuthCookie"];
            //var existingCookie = new HttpCookie("TicketAuthCookie");
            //existingCookie.Expires = DateTime.Now.AddDays(-12);
            //Response.Cookies.Add(existingCookie);
           
            Session["user"] = null;
            // Session["GroupId"] = null;
            Session["UserName"] = null;
            Session["timezoneoffset"] = null;
            Session.Clear();
            Session.Remove("user");
            Session.Remove("GroupId");
            Session.Remove("UserName");

            MainContext _mc = new MainContext();
            SystemClass sclass = new SystemClass();
            if (Session["user"] != null)
            {
                var userID = (int)Session["user"];
                var usrlog = _mc.USERLOG.Where(m => m.user_id == userID).OrderByDescending(m => m.EENT_DATE).FirstOrDefault();
                if (usrlog != null)
                {
                    usrlog.EOUT_DATE = DateTime.Now;
                    _mc.Entry(usrlog).State = System.Data.EntityState.Modified;

                    _mc.SaveChanges();

                }
            }

            Response.Redirect(FormsAuthentication.LoginUrl + "?ReturnURL=" + Url.Action("Index", "Home"));
            //return RedirectToAction("Index", "Home", null);
            return View();
        }
    }
}
