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
using System.Drawing;
using System.IO;
using PDFTOXLS.Helper;

namespace PDFTOXLS.Controllers
{
    public class UserController : BaseController
    {

        private readonly ImageHelper _helper;
       
        public UserController()
        {
            _helper = new ImageHelper();

        }
        public void Initpage()
        {
            try
            {
                SystemClass sclass = new SystemClass();
                string userID = sclass.GetLoggedUser();


                if (userID != null && userID != "")
                {
                    MainContext _mc = new MainContext();
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

                Response.Redirect("~/Home/Index");
            }

        }
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult Dashboard()
        {
          
            return View();
        }
       
        public ActionResult TicketDetails()
        {
           
            return View();
        }
        //public ActionResult DefineGroup()
        //{
        //   
        //    return View();
        //}

      
        //public ActionResult List()
        //{
        //    Initpage();
        //    string SiteRoot = System.Configuration.ConfigurationManager.AppSettings["SiteRoot"];
        //    ViewBag.SiteRoot = SiteRoot;
        //    //AuthSite();
        //    string query = "SELECT  extarnal=Case when L.IsInternalOrExternal=1 THEN 'Yes' ELSE 'No' END, RoleName=ISNULL((select RoleName from RoleMaster where Id=L.RoleMasterId),''),L.E_MAIL,L.WELCOM_MSG,USR_ID,USER_FNAME,USER_LNAME   FROM  (SELECT  ROW_NUMBER() OVER (ORDER BY   ##ID##   ##desc##) as row,* FROM EX_USER_NEW  WHERE ##filters## ) L   Where   ##paging##  ";
        //    ////SELECT  Count(*)  FROM Leads L WHERE isconverted=0 and OwnerID =" + CurrentUser.Id + "  ##filters##";
        //    ViewBag.query = query;
        //    //ViewData["query"] = query;

        //    return View();
        //}

        [HttpPost]
        public void Save(Ex_user_new exuser, HttpPostedFileBase uploadFile)
        {

            string _ErrorMsg = "";
            MainContext _mc = new MainContext();
            //CompanyContext _CompContext = new CompanyContext();
            try
            {
                string TicketAccess = Request.Form["TicketAccess"];
                //string selectedTeam = Request.Form["selectedTeam"];
                string selectedTeam = Request.Form["selectedTeam"];
                if (TicketAccess != null && TicketAccess == "GlobalAccess")
                {
                    exuser.IsGlobalAccess = true;
                }
                else if (TicketAccess != null && TicketAccess == "TeamAccess")
                {
                    exuser.IsTeamAccess = true;
                }
                else if (TicketAccess != null && TicketAccess == "SelfAccess")
                {
                    exuser.IsSelfAccess = true;
                }


                if (exuser.USR_ID > 0)
                {
                    //Ex_user_new _ch = _mc.Ex_user_new.Find(exuser.USR_ID);
                    //exuser.PASS = Request.Form["OLDPASS"].ToString();
                    //exuser.REPASSWORD = Request.Form["OLDPASS"].ToString();

                    //var allteams = _mc.Team_User.Where(x => x.USER_ID == exuser.USR_ID);
                    //foreach (var item in allteams.ToList())
                    //{

                    //    try
                    //    {
                    //        _mc.Entry(item).State = System.Data.EntityState.Deleted;
                    //        _mc.Team_User.Remove(item);
                    //        _mc.SaveChanges();

                    //    }
                    //    catch (Exception err)
                    //    {

                    //        ModelState.AddModelError("", "Failed On Id " + item.ToString() + " : " + err.Message);

                    //    }
                    //}

                    //exuser.selectedTeam = selectedTeam;
                    _mc.Entry(exuser).State = System.Data.EntityState.Modified;
                    if (ModelState.IsValid)
                    {
                        _mc.SaveChanges();
                    }
                    //if (selectedTeam != null)
                    //{
                    //    string[] strWord = selectedTeam.Split(',');
                    //    for (int i = 0; i < strWord.Length; i++)
                    //    {
                    //        Team_User currTeamUser = new Team_User();
                    //        currTeamUser.USER_ID = exuser.USR_ID;
                    //        currTeamUser.Team_Id = int.Parse(strWord[i]);
                    //        _mc.Team_User.Add(currTeamUser);
                    //        _mc.SaveChanges();
                    //    }
                    //}
                            

                }
                else
                {
                    string eml = exuser.E_MAIL;
                    var EmailVal = (from EM in _mc.Ex_user_new.Where(em => em.E_MAIL == eml) select new { EM.E_MAIL }).ToList();
                    if (EmailVal.Count == 0)
                    {
                        var xx = new ExactllyEnc.ExactllyEncrypt();
                        string nowpass = "";
                        nowpass = exuser.PASS.ToString().Trim();
                        string dpwd = xx.E_CRYPT(nowpass, "E");
                        exuser.PASS = dpwd;
                        exuser.REPASSWORD = dpwd;
                        if (uploadFile != null && !string.IsNullOrEmpty(uploadFile.FileName))
                        {
                            string _ext = System.IO.Path.GetExtension(uploadFile.FileName);
                            string ext = _ext.ToLower();
                            if (ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".gif" || ext == "bmp")
                            {
                                _helper.LocalFolder = Server.MapPath("~/Images/");
                                var original = new Bitmap(uploadFile.InputStream);
                                _helper.FileFullPath(original, 80, uploadFile.FileName);
                                exuser.UserImg = uploadFile.FileName;
                                FileInfo f = new FileInfo(_helper.LocalFolder + uploadFile.FileName);
                                double fileinbyte = f.Length;
                                double sizeInMb = fileinbyte / (1024 * 1024);
                                double sizeInkb = fileinbyte / 1024;
                                if (sizeInkb > 50)
                                {
                                    throw new Exception("File Size More Than 50 KB");
                                }
                            }
                        }
                        else
                        {
                            exuser.UserImg = "profile_blank_thumb.gif";
                        }
                        //if (selectedTeam != null)
                        //{
                        //    exuser.selectedTeam = selectedTeam;
                        //}

                        if (exuser.OF_PH_EXT==null)
                        {
                            exuser.OF_PH_EXT = "";
                        }

                        if (exuser.HM_PH_EXT == null)
                        {
                            exuser.HM_PH_EXT = "";
                        }

                        _mc.Ex_user_new.Add(exuser);
                        var errors = ModelState.Values.SelectMany(v => v.Errors);
                        if (ModelState.IsValid)
                        {
                            _mc.SaveChanges();

                            //if (selectedTeam != null)
                            //{
                            //    string[] strWord = selectedTeam.Split(',');
                            //    for (int i = 0; i < strWord.Length; i++)
                            //    {
                            //        Team_User currTeamUser = new Team_User();
                            //        currTeamUser.USER_ID = exuser.USR_ID;
                            //        currTeamUser.Team_Id = int.Parse(strWord[i]);
                            //        _mc.Team_User.Add(currTeamUser);
                            //        _mc.SaveChanges();
                            //    }
                            //}
                            
                            //MyLayout currMylauout = new MyLayout();
                            //currMylauout.DateCreated = DateTime.Now;
                            //currMylauout.UserId = exuser.USR_ID;
                            //currMylauout.ProfileName = exuser.E_MAIL;
                            //currMylauout.Description = exuser.USER_FNAME;
                            //_mc.MyLayout.Add(currMylauout);
                            //_mc.SaveChanges();

                            //var query = _mc.Group.Select(c => new { c.ID, c.GroupTitle });
                            //ViewBag.groups = new SelectList(query.AsEnumerable(), "ID", "GroupTitle");
                            //var sql = _mc.RoleMaster.Select(p => new { p.Id, p.RoleName });
                            //ViewBag.role = new SelectList(sql.AsEnumerable(), "Id", "RoleName");
                            ViewBag.USR_ID = 0;
                        }
                    }
                    else
                    {
                        //var query = _mc.Group.Select(c => new { c.ID, c.GroupTitle });
                        //ViewBag.groups = new SelectList(query.AsEnumerable(), "ID", "GroupTitle");
                        //var sql = _mc.RoleMaster.Select(p => new { p.Id, p.RoleName });
                        //ViewBag.role = new SelectList(sql.AsEnumerable(), "Id", "RoleName");
                        ViewBag.USR_ID = 0;
                        ViewBag.Error = "Email Id Already exist";
                       // return View((Ex_user_new)exuser);
                    }
                }

            }
            catch (Exception _ex)
            {
                _ErrorMsg = _ex.Message;
                Response.Redirect("~/User/List");
            }
            finally
            {
                //_mc.Dispose();
                //_mc = null;
            }
            Response.Redirect("~/User/List");
        }


        //  [HttpPost]
        //public void Save(Ex_user_new exuser, HttpPostedFileBase uploadFile)
        //{
           
        //    string _ErrorMsg = "";
        //    MainContext _mc = new MainContext();
        //    //CompanyContext _CompContext = new CompanyContext();
        //    try
        //    {
        //        if (exuser.USR_ID > 0)
        //        {
        //            //Ex_user_new _ch = _mc.Ex_user_new.Find(exuser.USR_ID);
        //            //exuser.PASS = Request.Form["OLDPASS"].ToString();
        //            //exuser.REPASSWORD = Request.Form["OLDPASS"].ToString();
        //            _mc.Entry(exuser).State = System.Data.EntityState.Modified;

                    

        //            //if (_ch != null)
        //            //{
        //            //    exuser.PASS = _ch.PASS;
        //            //    exuser.REPASSWORD = _ch.REPASSWORD;
        //            //    _ch = null;
        //            //}

        //        }
        //        else
        //        {
        //            var xx = new ExactllyEnc.ExactllyEncrypt();
        //            string nowpass = "";
        //            nowpass=exuser.PASS.ToString().Trim();
        //            string dpwd = xx.E_CRYPT(nowpass, "E");
        //            exuser.PASS = dpwd;
        //            exuser.REPASSWORD = dpwd;
        //            if (uploadFile != null && !string.IsNullOrEmpty(uploadFile.FileName))
        //            {
        //                string _ext = System.IO.Path.GetExtension(uploadFile.FileName);
        //                string ext = _ext.ToLower();
        //                if (ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".gif" || ext == "bmp")
        //                {
        //                    _helper.LocalFolder = Server.MapPath("~/Images/");
        //                    var original = new Bitmap(uploadFile.InputStream);
        //                    _helper.FileFullPath(original, 80, uploadFile.FileName);
        //                    exuser.UserImg = uploadFile.FileName;
        //                    FileInfo f = new FileInfo(_helper.LocalFolder + uploadFile.FileName);
        //                    double fileinbyte = f.Length;
        //                    double sizeInMb = fileinbyte / (1024 * 1024);
        //                    double sizeInkb = fileinbyte / 1024;
        //                    if (sizeInkb > 50)
        //                    {
        //                        throw new Exception("File Size More Than 50 KB");
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                exuser.UserImg = "profile_blank_thumb.gif";
        //            }
        //            _mc.Ex_user_new.Add(exuser);
        //        }
        //        //}
        //        var errors = ModelState.Values.SelectMany(v => v.Errors);

        //        //if (exuser.USR_ID > 0)
        //        //{
        //        //    _mc.SaveChanges();
        //        //    Response.Redirect("~/User/List");
        //        //}
        //        //else
        //        //{

                
        //            if (ModelState.IsValid)
        //            {
        //                _mc.SaveChanges();

        //                MyLayout currMylauout = new MyLayout();
        //                currMylauout.DateCreated = DateTime.Now;
        //                currMylauout.UserId = exuser.USR_ID;
        //                currMylauout.ProfileName = exuser.E_MAIL;
        //                currMylauout.Description = exuser.USER_FNAME;
        //                _mc.MyLayout.Add(currMylauout);
        //                _mc.SaveChanges();

        //                Response.Redirect("~/User/List");

                       
        //            }

        //        //}
                
        //    }
        //    catch (Exception _ex)
        //    {
        //        _ErrorMsg = _ex.Message;
        //        //Response.Redirect("~/Ticket/List");
        //        RedirectToAction("List");
        //    }
        //    finally
        //    {
               
        //        _mc.Dispose();
        //        _mc = null;
        //    }
        //}

       [HttpPost]
        public ActionResult Modify(int USR_ID)
        {
            Initpage();
            MainContext _maindb = new MainContext();
            Ex_user_new _ch = _maindb.Ex_user_new.Find(USR_ID);
            if (_ch == null)
            {
                ViewBag.ErrorText = "This User does not exists.";
                return PartialView("Error");
            }
            //var TeamList = (from cl in _maindb.Team
            //                select new
            //                {
            //                    cl.Id,
            //                    cl.Name
            //                }).ToList();

            //ViewBag.TeamList = new SelectList(TeamList.AsEnumerable(), "Id", "Name");
            ViewBag.USR_ID = _ch.USR_ID;
            ViewBag.TicketAccess = _ch.TicketAccess;
            ViewBag.PASS = _ch.PASS.ToString();
            ViewBag.REPASSWORD = _ch.REPASSWORD;
            ViewBag.mode ="Edit";

            //var query = _maindb.Group.Select(c => new { c.ID, c.GroupTitle });
            ////ViewBag.group_id = new SelectList(query.AsEnumerable(), "ID", "GroupTitle", _ch.group_id);
            //ViewBag.groups = new SelectList(query.AsEnumerable(), "ID", "GroupTitle", _ch.group_id);
            //ViewBag.groupid = _ch.group_id;
            var TimeZoneList = (from cl in _maindb.tbTimeZoneInfo
                                select new
                                {
                                    cl.TimeZoneID,
                                    cl.Display
                                }).ToList();
            ViewBag.TimeZoneList = new SelectList(TimeZoneList.AsEnumerable(), "TimeZoneID", "Display");


            //var sql = _maindb.RoleMaster.Select(p => new { p.Id, p.RoleName });
            //ViewBag.role = new SelectList(sql.AsEnumerable(), "Id", "RoleName",_ch.rolemaster);
            //int[] teamstr = (from xx in _maindb.Team_User where xx.USER_ID == USR_ID select xx.Team_Id).ToArray();
            //if (teamstr.Count() > 0)
            //{
            //    ViewBag.teamstr = teamstr;
            //}
            //else
            //{
            //    ViewBag.teamstr = null;
            //}
            return PartialView("DefineUser", _ch);
        }


       public ActionResult List()
       {
           Initpage();
           string SiteRoot = System.Configuration.ConfigurationManager.AppSettings["SiteRoot"];
           ViewBag.SiteRoot = SiteRoot;
           //AuthSite();
           string query = "SELECT  extarnal=Case when L.IsInternalOrExternal=1 THEN 'Yes' ELSE 'No' END, RoleName=ISNULL((select RoleName from RoleMaster where Id=L.RoleMasterId),''),L.E_MAIL,L.WELCOM_MSG,USR_ID,USER_FNAME,USER_LNAME   FROM  (SELECT  ROW_NUMBER() OVER (ORDER BY   ##ID##   ##desc##) as row,* FROM EX_USER_NEW  WHERE ##filters## and userstatus=0) L   Where   ##paging##  ";
           ////SELECT  Count(*)  FROM Leads L WHERE isconverted=0 and OwnerID =" + CurrentUser.Id + "  ##filters##";
           ViewBag.query = query;
           //ViewData["query"] = query;

           return View();
       }


       [HttpPost]
       public void Delete(int USR_ID)
       {
           MainContext _maindb = new MainContext();
           Ex_user_new _ch = _maindb.Ex_user_new.Find(USR_ID);
           if (_ch == null)
           {
               ViewBag.ErrorText = "This User does not exists.";
           }
           else
           {
               _ch.UserStatus = UserStatus.Closed;
               _maindb.SaveChanges();
           }
           Response.Redirect("~/User/List");
       }

       [HttpPost]
       public void Block(int USR_ID)
       {
           MainContext _maindb = new MainContext();
           Ex_user_new _ch = _maindb.Ex_user_new.Find(USR_ID);
           if (_ch == null)
           {
               ViewBag.ErrorText = "This User does not exists.";
           }
           else
           {
               _ch.UserStatus = UserStatus.Inactive;
               _maindb.SaveChanges();
           }
           Response.Redirect("~/User/List");
       }




       //[HttpPost]
       // public void Delete(int USR_ID)
       // {
       //     MainContext _maindb = new MainContext();
       //     Ex_user_new _ch = _maindb.Ex_user_new.Find(USR_ID);
       //     if (_ch == null)
       //     {
       //         ViewBag.ErrorText = "This User does not exists.";
       //        // return PartialView("Error");
       //     }

       //     _maindb.Ex_user_new.Remove(_ch);
       //     _maindb.SaveChanges();

       //     Response.Redirect("~/User/List");
       //    // return View("List");
       // }


        [ValidateInput(false)]
        public ActionResult UserDetailsPartial()
        {
            MainContext _maindb = new MainContext();
            //var model = _maindb.Ex_user_new.ToList().OrderByDescending(x => x.USR_ID);
            var model=(from Usr in _maindb.Ex_user_new 
                       //join Grp in _maindb.Group on Usr.group_id equals Grp.ID into T
            //           from Rt in T.DefaultIfEmpty()
                       select new
                       {
                           role = Usr.rolemaster.RoleName,
                          // Rt.GroupTitle,
                           Usr.USR_ID,
                           Usr.USER_FNAME,
                           Usr.USER_LNAME,
                           Usr.E_MAIL,
                           Usr.WELCOM_MSG
                       }).ToList().OrderByDescending(x => x.USR_ID);
            return PartialView("_UserDetailsPartial", model);
        }

        
       
        [HttpPost, ValidateInput(false)]
        public ActionResult UserDetailsPartialDelete(System.Int32 USR_Id)
        {
            var model = new object[0];
            if (USR_Id >= 0)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_UserDetailsPartial", model);
        }

        #region Change Password
        public ActionResult ChangePassword()
        {
            Initpage();
            return View();
        }

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

        [HttpPost]
        public ActionResult SaveChangePassword(Ex_user_new exuser, string OLDPASS = "")
        {
            string _ErrorMsg = "";
            MainContext _mc = new MainContext();
            try
            {
                Ex_user_new _ch = _mc.Ex_user_new.Find(CurrentUser.USR_ID);
                var Oldpd = _mc.Ex_user_new.Find(CurrentUser.USR_ID).PASS;
                var xx = new ExactllyEnc.ExactllyEncrypt();
                string dpwd = xx.E_CRYPT(Oldpd.ToString().Trim(), "D");

                if (OLDPASS == dpwd)
                {
                    xx = new ExactllyEnc.ExactllyEncrypt();
                    var nowpass = exuser.REPASSWORD.ToString().Trim();
                    dpwd = xx.E_CRYPT(nowpass, "E");
                    _ch.PASS = dpwd;
                    _ch.REPASSWORD = dpwd;
                    _ch.USR_ID = CurrentUser.USR_ID;
                    _mc.Entry(_ch).State = System.Data.EntityState.Modified;
                    _mc.SaveChanges();
                    return View("ChangePassword");
                }
                else
                {
                    if (OLDPASS == "")
                    {
                        ViewBag.statusmsg = "Should not be Blank";

                    }
                    else
                    {
                        ViewBag.statusmsg = "Invalid Old Password";
                    }
                    return View("ChangePassword");
                }
            }
            catch (Exception _ex)
            {
                _ErrorMsg = _ex.Message;
                return View("ChangePassword");
            }
            finally
            {
                _mc.Dispose();
                _mc = null;
            }
        }


        //public ActionResult Profile()
        //{
        //    ViewBag.UserName = CurrentUser.FullName;
        //    ViewBag.CurrentUser = CurrentUser;
        //    ViewBag.Phone = CurrentUser.HM_PH_EXT;
        //    ViewBag.E_MAIL = CurrentUser.E_MAIL;
        //    ViewBag.USR_ID = CurrentUser.USR_ID;
        //    return View();
        //}


        [HttpPost]
        public void SaveUser(Ex_user_new exuser, HttpPostedFileBase uploadFile)
        {
            string SaveMod = Request.Form["SaveMod"];
            if (SaveMod != null && SaveMod == "No")
            {
                Response.Redirect("~/Dashboard/Dashboard");
            }
            else
            {
                MainContext _maindb = new MainContext();
                Ex_user_new _exusermodel = _maindb.Ex_user_new.Find(CurrentUser.USR_ID);
                _exusermodel.USER_FNAME = exuser.USER_FNAME;
                _exusermodel.USER_LNAME = exuser.USER_LNAME;

                _exusermodel.OF_PH_EXT = exuser.OF_PH_EXT;
                _exusermodel.HM_PH_EXT = exuser.HM_PH_EXT;
                _exusermodel.TimeZoneId = exuser.TimeZoneId;
                _maindb.Entry(_exusermodel).State = System.Data.EntityState.Modified;


                if (uploadFile != null && !string.IsNullOrEmpty(uploadFile.FileName))
                {
                    string _ext = System.IO.Path.GetExtension(uploadFile.FileName);
                    string ext = _ext.ToLower();
                    if (ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".gif" || ext == "bmp")
                    {
                        _helper.LocalFolder = Server.MapPath("~/Content/ProfilePics/");
                        var original = new Bitmap(uploadFile.InputStream);
                        _helper.FileFullPath(original, _exusermodel.USR_ID, uploadFile.FileName);
                        _exusermodel.UserImg = _exusermodel.USR_ID.ToString().Trim() + uploadFile.FileName;
                        FileInfo f = new FileInfo(_helper.LocalFolder + _exusermodel.USR_ID.ToString().Trim() + uploadFile.FileName);
                        double fileinbyte = f.Length;
                        double sizeInMb = fileinbyte / (1024 * 1024);
                        double sizeInkb = fileinbyte / 1024;
                        if (sizeInkb > 50)
                        {
                            throw new Exception("File Size More Than 50 KB");
                        }
                    }
                }
                //else
                //{
                //    _exusermodel.UserImg = "profile_blank_thumb.gif";
                //}





                _maindb.SaveChanges();

                Response.Redirect("~/User/ProfileEdit");
            }
        }



        public ActionResult ProfileEdit(int Userid=0)
        {
            MainContext _maindb = new MainContext();
            Ex_user_new _exusermodel = new Ex_user_new();
            ViewBag.NotEdit = "Yes";
            if (Userid > 0)
            {
                _exusermodel = _maindb.Ex_user_new.Find(Userid);
                ViewBag.NotEdit = "No";
            }
            else
            {
                _exusermodel = _maindb.Ex_user_new.Find(CurrentUser.USR_ID);
            }

            var TimeZoneList = (from cl in _maindb.tbTimeZoneInfo
                                select new
                                {
                                    cl.TimeZoneID,
                                    cl.Display
                                }).ToList();
            ViewBag.TimeZoneList = new SelectList(TimeZoneList.AsEnumerable(), "TimeZoneID", "Display");
            ViewBag.userimage = _exusermodel.UserImg;
            ViewBag.FullName = _exusermodel.FullName;
            return View("ProfileEdit", _exusermodel);
        }


        //public ActionResult ProfileEdit()
        //{
        //    MainContext _maindb = new MainContext();
        //    Ex_user_new _exusermodel = _maindb.Ex_user_new.Find(CurrentUser.USR_ID);

        //    var TimeZoneList = (from cl in _maindb.tbTimeZoneInfo
        //                        select new
        //                        {
        //                            cl.TimeZoneID,
        //                            cl.Display
        //                        }).ToList();
        //    ViewBag.TimeZoneList = new SelectList(TimeZoneList.AsEnumerable(), "TimeZoneID", "Display");

        //    return View("ProfileEdit", _exusermodel);
        //}

        //[HttpPost]
        //public void SaveUser(Ex_user_new exuser, HttpPostedFileBase uploadFile)
        //{
        //    MainContext _maindb = new MainContext();
        //    Ex_user_new _exusermodel = _maindb.Ex_user_new.Find(CurrentUser.USR_ID);
        //    _exusermodel.USER_FNAME = exuser.USER_FNAME;
        //    _exusermodel.USER_LNAME = exuser.USER_LNAME;

        //    _exusermodel.OF_PH_EXT = exuser.OF_PH_EXT;
        //    _exusermodel.HM_PH_EXT = exuser.HM_PH_EXT;
        //    _exusermodel.TimeZoneId = exuser.TimeZoneId;
        //    _maindb.Entry(_exusermodel).State = System.Data.EntityState.Modified;
        //    _maindb.SaveChanges();

        //    Response.Redirect("~/User/Profile");
        //}



        //public void SaveChangePassword(Ex_user_new exuser)
        //{
        //    string _ErrorMsg = "";
        //    MainContext _mc = new MainContext();
        //    try
        //    {
        //        Ex_user_new _ch = _mc.Ex_user_new.Find(CurrentUser.USR_ID);
        //        var Oldpd = _mc.Ex_user_new.Find(CurrentUser.USR_ID).PASS;
        //        var xx = new ExactllyEnc.ExactllyEncrypt();
        //        string dpwd = xx.E_CRYPT(Oldpd.ToString().Trim(), "D");
        //        if (exuser.PASS == dpwd)
        //        {
        //            xx = new ExactllyEnc.ExactllyEncrypt();
        //            var nowpass = exuser.REPASSWORD.ToString().Trim();
        //            dpwd = xx.E_CRYPT(nowpass, "E");
        //            _ch.PASS = dpwd;
        //            _ch.REPASSWORD = dpwd;
        //            _ch.USR_ID = CurrentUser.USR_ID;
        //            _mc.Entry(_ch).State = System.Data.EntityState.Modified;
        //            _mc.SaveChanges();
        //            Response.Redirect("~/User/List");

        //        }
        //        else
        //        {
        //            Response.Redirect("~/User/ChangePassword");
        //        }
        //    }
        //    catch (Exception _ex)
        //    {
        //        _ErrorMsg = _ex.Message;
        //        RedirectToAction("List");
        //    }
        //    finally
        //    {
        //        _mc.Dispose();
        //        _mc = null;
        //    }
        //}
        #endregion
    }

}
