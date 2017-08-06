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
using TicketSystem.Models;

namespace TicketSystem.Controllers
{
    public class NewsController : BaseController
    {
        MainContext _mc = new MainContext();

        public void Initpage()
        {
            try
            {
                ViewBag.SetupCssClass = "active";
                ViewBag.UserName = CurrentUser.FullName;
                ViewBag.CurrentUser = CurrentUser;
                ViewBag.UserImagePath = CurrentUser.UserImg;

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

        public ActionResult Define(int Id=0)
        {
            Initpage();
            News _ch = new News();
            if (Id > 0)
            {
                 _ch = _mc.News.Find(Id);
                ViewBag.ID = Id;
                int[] teamstr = (from xx in _mc.Team_News where xx.News_ID == Id select xx.Team_Id).ToArray();
                if (teamstr.Count() > 0)
                {
                    ViewBag.teamstr = teamstr;
                }
                else
                {
                    ViewBag.teamstr = null;
                }
            }
            else
            {
                ViewBag.ID = 0;
            }
            var TeamList = (from cl in _mc.Team
                            select new
                            {
                                cl.Id,
                                cl.Name
                            }).ToList();

            ViewBag.TeamList = new SelectList(TeamList.AsEnumerable(), "Id", "Name");


            // var query = _mc.Group.Select(c => new { c.ID, c.GroupTitle });
            // ViewBag.groups = new SelectList(query.AsEnumerable(), "ID", "GroupTitle");
          
          
          
            return View(_ch);
        }


      
        public ActionResult List()
        {
            Initpage();
            string SiteRoot = System.Configuration.ConfigurationManager.AppSettings["SiteRoot"];
            ViewBag.SiteRoot = SiteRoot;

            string query = "SELECT L.Id,L.Title,L.Description  FROM  (SELECT  ROW_NUMBER() OVER (ORDER BY   ##ID##   ##desc##) as row,* FROM News  WHERE ##filters## ) L   Where   ##paging##  ";
            ViewBag.query = query;
            ViewBag.CurrentUser = CurrentUser;
            return View();
        }


        [HttpPost]
        public void Delete(int Id)
        {
            var allteams = _mc.Team_News.Where(x => x.News_ID == Id);
            foreach (var item in allteams.ToList())
            {

                try
                {
                    _mc.Entry(item).State = System.Data.EntityState.Deleted;
                    _mc.Team_News.Remove(item);
                    _mc.SaveChanges();

                }
                catch (Exception err)
                {

                    ModelState.AddModelError("", "Failed On Id " + item.ToString() + " : " + err.Message);

                }
            }
            News _ch = _mc.News.Find(Id);
            if (_ch == null)
            {
                ViewBag.ErrorText = "This User does not exists.";
                // return PartialView("Error");
            }

            _mc.News.Remove(_ch);
            _mc.SaveChanges();

            Response.Redirect("~/News/List");
            // return View("List");
        }



        [HttpPost]
        public void Save(News news)
        {
           
            string _ErrorMsg = "";
           // MainContext _mc = new MainContext();
            News currNews = news;
            string selectedTeam = Request.Form["selectedTeam"];
            try
            {

                if (news.ID > 0)
                {
                    //Ex_user_new _ch = _mc.Ex_user_new.Find(exuser.USR_ID);
                    //exuser.PASS = Request.Form["OLDPASS"].ToString();
                    //exuser.REPASSWORD = Request.Form["OLDPASS"].ToString();

                    var allteams = _mc.Team_News.Where(x => x.News_ID == news.ID);
                    foreach (var item in allteams.ToList())
                    {

                        try
                        {
                            _mc.Entry(item).State = System.Data.EntityState.Deleted;
                            _mc.Team_News.Remove(item);
                            _mc.SaveChanges();

                        }
                        catch (Exception err)
                        {

                            ModelState.AddModelError("", "Failed On Id " + item.ToString() + " : " + err.Message);

                        }
                    }
                    currNews.DateCreated = DateTime.Now;
                    //exuser.selectedTeam = selectedTeam;
                    _mc.Entry(currNews).State = System.Data.EntityState.Modified;
                    if (ModelState.IsValid)
                    {
                        _mc.SaveChanges();
                    }
                    if (selectedTeam != null)
                    {
                        string[] strWord = selectedTeam.Split(',');
                        for (int i = 0; i < strWord.Length; i++)
                        {
                            Team_News currTeamnews = new Team_News();
                            currTeamnews.News_ID = currNews.ID;
                            currTeamnews.Team_Id = int.Parse(strWord[i]);
                            _mc.Team_News.Add(currTeamnews);
                            _mc.SaveChanges();
                        }
                    }


                }
                else
                {
                    currNews.DateCreated = DateTime.Now;
                    _mc.News.Add(currNews);
                    _mc.SaveChanges();

                    if (selectedTeam != null)
                    {
                        string[] strWord = selectedTeam.Split(',');
                        for (int i = 0; i < strWord.Length; i++)
                        {
                            Team_News currTeamnews = new Team_News();
                            currTeamnews.News_ID = currNews.ID;
                            currTeamnews.Team_Id = int.Parse(strWord[i]);
                            _mc.Team_News.Add(currTeamnews);
                            _mc.SaveChanges();
                        }
                    }
                }
             
                
            }
            catch (Exception _ex)
            {
                _ErrorMsg = _ex.Message;
                RedirectToAction("DefineClient");
            }
            finally
            {
               
                _mc.Dispose();
                _mc = null;
            }
            Response.Redirect("~/News/List");
        }

    }
}
