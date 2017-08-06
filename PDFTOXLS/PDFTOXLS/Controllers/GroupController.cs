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
using MvcApplication1.Models;
using DevExpress.Web.Mvc;


namespace MvcApplication1.Controllers
{
    public class GroupController : Controller
    {

       
      
        public ActionResult Index()
        {
          
            return View();
        }

        public ActionResult Dashboard()
        {
          
            return View();
        }
        //public ActionResult DefineUser()
        //{
        //  
        //    return View();
        //}
        //public ActionResult TicketDetails()
        //{
        //  
        //    return View();
        //}
        public ActionResult DefineGroup()
        {

            MainContext _mc = new MainContext();
            var query = _mc.Ex_user_new.Select(c => new { c.USR_ID, c.USER_FNAME });
            ViewBag.consultants = new SelectList(query.AsEnumerable(), "USR_ID", "USER_FNAME");

            //ViewBag.USR_ID = 0;
            //return View();


            ViewBag.ID = 0;
            return View();
        }

      
        public ActionResult List()
        {
            //AuthSite();
            //string query = "SELECT  TASK_NO,REQ_DATE,CLNT,UserName,Product,Category,Version,Modules,Priority   FROM  (SELECT  ROW_NUMBER() OVER (ORDER BY   ##ID##   ##desc##) as row,* FROM TASK_DETAIL  WHERE Id is not null  ##filters## ) L   Where   ##paging##  ";
            ////SELECT  Count(*)  FROM Leads L WHERE isconverted=0 and OwnerID =" + CurrentUser.Id + "  ##filters##";

            //ViewData["query"] = query;
            return View();
        }

        //public ActionResult AddTicket()
        //{
        //  
        //    ViewData["Category"] =
        //        new SelectList(new[] { "Bug", "Changes", "Query" }
        //        .Select(x => new { value = x, text = x }),
        //        "value", "text", "Bug");

        //    ViewData["Product"] =
        //        new SelectList(new[] { "Exactlly ERP", "CRM", "PMS", "HRMS" }
        //        .Select(x => new { value = x, text = x }),
        //        "value", "text", "Exactlly ERP");

        //    ViewData["Priority"] =
        //        new SelectList(new[] { "High", "Low", "Normal" }
        //        .Select(x => new { value = x, text = x }),
        //        "value", "text", "Normal");

        //    ViewData["UserName"] = Session["UserName"];
        //    ViewBag.Id = 0;
        //     ViewData["Userid"] = Convert.ToInt32(Session["Userid"].ToString());

        //    return View();
        //}

        [HttpPost]
        public void Save(Group Groupobj)
        {
          
            string _ErrorMsg = "";
            MainContext _mc = new MainContext();
            //CompanyContext _CompContext = new CompanyContext();

            try
            {

                if (Groupobj.ID > 0)
                {
                    _mc.Entry(Groupobj).State = System.Data.EntityState.Modified;
                }
                else
                {
                    _mc.Group.Add(Groupobj);
                }
                //}

                var errors = ModelState.Values.SelectMany(v => v.Errors);
              
                    _mc.SaveChanges();
                    Response.Redirect("~/Group/List");

            }
            catch (Exception _ex)
            {
                _ErrorMsg = _ex.Message;
                //Response.Redirect("~/Ticket/List");
                RedirectToAction("List");
            }
            finally
            {
               
                _mc.Dispose();
                _mc = null;
            }

        }


        [HttpGet]
        [ValidateInput(true)]
        public ActionResult Modify(int ID)
        {
            //MainContext _maindb = new MainContext();
            //Group _ch = _maindb.Group.Find(ID);
            //if (_ch == null)
            //{
            //    ViewBag.ErrorText = "This Group does not exists.";
            //    return PartialView("Error");
            //}

            //var query = _maindb.Ex_user_new.Select(c => new { c.USR_ID, c.USER_FNAME });
            //ViewBag.consultants = new SelectList(query.AsEnumerable(), "USR_ID", "USER_FNAME", _ch.PrimaryConsultant);
            //ViewBag.PrimaryConsultant = _ch.PrimaryConsultant;

            //ViewBag.ID = _ch.ID;

            //return View("DefineGroup", _ch);
        }

        [ValidateInput(false)]
        public ActionResult GroupDetailsPartial()
        {
            MainContext _maindb = new MainContext();
            //var model = _maindb.Group.ToList().OrderByDescending(x=>x.ID);
            var model=(from Grp in _maindb.Group join Usr in _maindb.Ex_user_new on Grp.PrimaryConsultant equals Usr.USR_ID
                        select new
                        {
                            Grp.ID,
                            Grp.GroupTitle,
                            Grp.Description,
                            Grp.PrimaryConsultant,
                            Usr.USR_ID,
                            Usr.USER_FNAME,
                            Usr.USER_LNAME,
                            Usr.E_MAIL
                        }).ToList().OrderByDescending(x=>x.ID);
            return PartialView("_GroupDetailsPartial", model);
        }

        //[HttpPost, ValidateInput(false)]
        //public ActionResult TicketDetailsPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] MvcApplication1.Models.TASK_DETAIL item)
        //{
        //    var model = new object[0];
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            // Insert here a code to insert the new item in your model
        //        }
        //        catch (Exception e)
        //        {
        //            ViewData["EditError"] = e.Message;
        //        }
        //    }
        //    else
        //        ViewData["EditError"] = "Please, correct all errors.";
        //    return PartialView("_TicketDetailsPartial", model);
        //}
      
        
        [HttpPost, ValidateInput(false)]
        public ActionResult GroupDetailsPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] MvcApplication1.Models.Group item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GroupDetailsPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GroupDetailsPartialDelete(System.Int32 Id)
        {
            var model = new object[0];
            if (Id >= 0)
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
            return PartialView("_GroupDetailsPartial", model);
        }

        [HttpGet]
        [ValidateInput(true)]
        public ActionResult Delete(System.Int32 Id)
        {


            MainContext _maindb = new MainContext();
            Group _ch = _maindb.Group.Find(Id);
            if (_ch == null)
            {
                ViewBag.ErrorText = "This Group does not exists.";
                return PartialView("Error");
            }
            else
            {
                _maindb.Group.Remove(_ch);
                _maindb.SaveChanges();
            } 

            return View("List");
          
        }



    }
}
