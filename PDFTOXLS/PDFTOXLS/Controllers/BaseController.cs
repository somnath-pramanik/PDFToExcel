using Microsoft.Ajax.Utilities;
using PDFTOXLS.Helper.Security;
using PDFTOXLS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PDFTOXLS.Controllers
{
     [Authorize]
     [CustomAuthorize]
    public class BaseController : Controller
    {
        //protected MainContext MainDb = new MainContext();
        //protected string userID = "";
        //public BaseController()
        //{
        //    SystemClass sclass = null;
        //    Ex_user_new _user= null;
        //    try
        //    {
        //        sclass = new SystemClass();
        //        userID = sclass.GetLoggedUser();
        //        if (userID.Trim() != "")
        //        {
        //           // _user = MainDb.Ex_user_new.SingleOrDefault(c => c.USR_ID ==);
        //            ViewBag.UserName = _user.USER_FNAME;
        //            ViewBag.logindateTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm");
        //        }
        //        else
        //        {
        //            ViewBag.UserName = "";
        //            ViewBag.logindateTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm");
        //        }
        //    }
        //    catch { }
        //    finally
        //    {
        //        if (_user != null)
        //        {
        //            _user.Dispose();
        //        }
        //        _user = null;
        //        if (sclass != null)
        //        {
        //            sclass.Dispose();
        //        }
        //        sclass = null;
        //    }
        //}

        
        public Ex_user_new CurrentUser
        {
            get
            {
                if (Session["user"] == null)
                {
                    return null;
                }
                var userID = (int)Session["user"];
                MainContext _mc = new MainContext();
                return _mc.Ex_user_new.Find(userID);
            }
            set
            {
                Session["user"] = value.USR_ID;
            }
        }

        


        //public string SiteRootOverride;
        //public string SiteRoot
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(SiteRootOverride))
        //        {
        //            //I don't really want the last /, I *need* that in my templates to delimate the variable from the rest
        //            string fullRoot = Request.Uri.Scheme + "://" + Request.Uri.Authority +
        //                              Context.UnderlyingContext.Request.ApplicationPath;
        //            if (fullRoot.EndsWith("/"))
        //            {
        //                SiteRootOverride = fullRoot.Substring(0, fullRoot.Length - 1);
        //            }
        //        }
        //        return SiteRootOverride;
        //    }
        //}
    }
}