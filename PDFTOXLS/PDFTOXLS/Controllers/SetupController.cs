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
    public class SetupController : BaseController
    {
        MainContext _mc = new MainContext();

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

                Response.Redirect("~/Home/Index");
            }
          
        }

        public ActionResult Define()
        {
            Initpage();

            return PartialView();
        }

        public ActionResult LayoutDefine()
        {
            Initpage();
            var MyLayouts = (from cl in _mc.MyLayout

                             select new
                             {
                                 cl.ID,
                                 cl.ProfileName
                             }).ToList();

            ViewBag.Mylayout = new SelectList(MyLayouts.AsEnumerable(), "Id", "ProfileName");

            //var ProfileUser = CRM_User.Find(Convert.ToInt32(CurrentUser.Id.ToString()));
            //PropertyBag["ProfileUser"] = ProfileUser;

            //var profileid = Designation.FindOne(Restrictions.Eq("Id", CurrentUser.role.Id));
            //var secgrp = SectionGRP.Find(profileid.secgrp.Id);
            // string authCookie = Request.ReadCookie("HerculesCRMAuthHash");

            //PropertyBag["ModuleSections"] = moduleSections;
            ////----------------------------------------------------------------------
            //DetachedCriteria query = DetachedCriteria.For(typeof(CRM_ModuleFields));
            //query.Add(Restrictions.Eq("module", module));
            //query.Add(Restrictions.Eq("user", CurrentProfile));
            //query.Add(Restrictions.Eq("IsExtraField", false));
            //var moduleFields = CRM_ModuleFields.FindAll(query).OrderBy(x => x.SerialNo);
            ////----------------------------------------------------------------------------------------------------
            ////   var moduleFields = ModuleFields.FindAll(Restrictions.And(Restrictions.Eq("module", module), Restrictions.Eq("user", CurrentUser))).OrderBy(x => x.SerialNo);
            //PropertyBag["ModuleFields"] = moduleFields;
            //PropertyBag["PageMainTitle"] = "Create Layout";
            //PropertyBag["title"] = "Create Layout";
            //PropertyBag["TotalItem"] = moduleFields.Count();
            //PropertyBag["currentList"] = "DEF_LEAD";
            //PropertyBag["ModuleName"] = "Leads";
            //// ------------------------------------------------------------------- add xtra select box

            //PropertyBag["ModuleObjName"] = "DEF_LEAD";


            return View();
        }


        public void updateFieldApps()
        {

            // string[] sortlist, int[] fieldid, bool[] rmvfld, bool[] mnadatory, bool[] isremovedFromList, bool[] isquickleadfld, bool[] isShowingInGridList
            //try
            //{

            var isShowingInGridList = Request.Form["isShowingInGridList"];
            string[] splitstr = isShowingInGridList.Split(',');

            var sortlist = Request.Form["sortlist[]"];
            string[] sortlistArr = sortlist.Split(',');
           string[] actualsortarray= sortlistArr.Where(x => !string.IsNullOrEmpty(x)).ToArray();

           //var xStr = sortlist;
           //int XCount = 1;
           //if (xStr.Length == 3 || xStr.Length == 2)
           //{
           //    for (int i = 0; i < xStr.Length; i++)
           //    {
           //        string[] strSplit = xStr[i].Split(',');
           //        for (int j = 1; j < strSplit.Length; j++)
           //        {
           //            string[] fldidSplit = strSplit[j].Split(' ');
           //            var appfld = ModuleFields.Find(Int32.Parse(fldidSplit[1]));
           //            appfld.SerialNo = j;
           //            appfld.Save();

           //        }

           //    }
           //}

            var fieldid = Request.Form["fieldid[]"];
            string[] fieldids = fieldid.Split(',');

            var columnWidth = Request.Form["nm_columnWidth[]"];
            string[] splitcolumnWidth = columnWidth.Split(',');

            var Masterfieldid = Request.Form["Masterfieldid[]"];
            string[] Masterfieldids = Masterfieldid.Split(',');

            var layoutid = (from _d in _mc.MyLayout where _d.UserId == CurrentUser.USR_ID select new { _d.ID }).FirstOrDefault();
            int i = 0;
            ModuleFields currentModuleFields = new ModuleFields();
            if (splitstr.Length > 0)
            {
                foreach (var fid in Masterfieldids)
                {
                    if (int.Parse(fieldids[i]) == 0)
                    {

                        var appfld = _mc.MasterFields.Find(int.Parse(fid));

                        currentModuleFields.DateCreated = DateTime.Now;
                        currentModuleFields.ModuleSectionID = appfld.ModuleSectionID;
                        currentModuleFields.ModuleID = appfld.ModuleID;
                        //currentModuleFields.profileID = layoutid.ID;
                        currentModuleFields.MasterFieldId = appfld.ID;
                        currentModuleFields.Name = appfld.Name;
                        currentModuleFields.Caption = appfld.Caption;
                        currentModuleFields.SerialNo = appfld.SerialNo;
                        currentModuleFields.Type = appfld.Type;
                        currentModuleFields.Length = appfld.Length;
                        currentModuleFields.Decimal = appfld.Decimal;
                        currentModuleFields.RoundOption = appfld.RoundOption;
                        currentModuleFields.Precision = appfld.Precision;
                        currentModuleFields.PickList = appfld.PickList;
                        currentModuleFields.isFirstDefaultValue = appfld.isFirstDefaultValue;
                        currentModuleFields.CheckBox = appfld.CheckBox;
                        currentModuleFields.Prefix = appfld.Prefix;
                        currentModuleFields.StartNo = appfld.StartNo;
                        currentModuleFields.Body = appfld.Body;
                        currentModuleFields.EndNo = appfld.EndNo;
                        currentModuleFields.Suffix = appfld.Suffix;
                        currentModuleFields.IsExisting = appfld.IsExisting;
                        currentModuleFields.IsMandatory = appfld.IsMandatory;
                        currentModuleFields.IsCustom = appfld.IsCustom;
                        if (splitstr.Where(x => !string.IsNullOrEmpty(x)).ToArray().Length > 0)
                        {
                            if (bool.Parse(splitstr[i]) == false)
                            {
                                appfld.IsRemovable = true;
                            }
                            else
                            {
                                appfld.IsRemovable = false;
                                appfld.columnWidth = Convert.ToInt32(splitcolumnWidth[i]);
                            }
                        }
                        currentModuleFields.DefaultValue = appfld.DefaultValue;
                        currentModuleFields.IsHelpPop = appfld.IsHelpPop;
                        currentModuleFields.HelpPopUrl = appfld.HelpPopUrl;
                        currentModuleFields.IsReadonly = appfld.IsReadonly;
                        currentModuleFields.SpecialFieldID = appfld.SpecialFieldID;
                        currentModuleFields.SpecialCSSClass = appfld.SpecialCSSClass;
                        currentModuleFields.IsUniqueCheck = appfld.IsUniqueCheck;
                        currentModuleFields.IsBlankCheck = appfld.IsBlankCheck;
                        currentModuleFields.IsAppeareMultipleCountry = appfld.IsAppeareMultipleCountry;
                        currentModuleFields.IsAppeareMultipleState = appfld.IsAppeareMultipleState;
                        currentModuleFields.IsAppeareMultipleCity = appfld.IsAppeareMultipleCity;
                        currentModuleFields.IsExtraField = appfld.IsExtraField;
                        currentModuleFields.ExtraField = appfld.ExtraField;
                        currentModuleFields.isQuickLead = appfld.isQuickLead;
                        currentModuleFields.isCopyField = appfld.isCopyField;
                        currentModuleFields.DataSourceName = appfld.DataSourceName;
                        currentModuleFields.isShowingListingPage = appfld.isShowingListingPage;
                        currentModuleFields.RoleID = appfld.RoleID;
                        currentModuleFields.profileID = CurrentUser.USR_ID;
                        if (splitcolumnWidth[i] != null && splitcolumnWidth[i] != "")
                        {
                            currentModuleFields.columnWidth = Convert.ToInt32(splitcolumnWidth[i]);//appfld.columnWidth;
                        }
                        else
                        {
                            currentModuleFields.columnWidth = 0;
                        }

                        //currentModuleFields.isInPickList = appfld.isInPickList;
                        //currentModuleFields.isAdminVisible = appfld.isAdminVisible;
                        //currentModuleFields.isManagerVisible = appfld.isManagerVisible;
                        //currentModuleFields.isMemberVisible = appfld.isMemberVisible;
                        //currentModuleFields.isClientVisible = appfld.isClientVisible;
                        _mc.ModuleFields.Add(currentModuleFields);
                        _mc.SaveChanges();
                    }
                    else
                    {
                        var appfld = _mc.ModuleFields.Find(int.Parse(fieldids[i]));
                        if (splitstr.Where(x => !string.IsNullOrEmpty(x)).ToArray().Length > 0)
                        {
                            if (bool.Parse(splitstr[i]) == false)
                            {
                                appfld.IsRemovable = true;
                            }
                            else
                            {
                                appfld.IsRemovable = false;
                                appfld.columnWidth = Convert.ToInt32(splitcolumnWidth[i]);
                            }
                        }

                        // appfld.isAdminVisible = false;
                        _mc.Entry(appfld).State = System.Data.EntityState.Modified;
                        _mc.SaveChanges();
                    }
                    i++;
                }

            }

            for (int j = 1; j < actualsortarray.Length; j++)
            {
                if (fieldids.Length > 0)
                {
                    string[] fldidSplit = actualsortarray[j].Split(' ');
                    var appfld = _mc.ModuleFields.Find(Int32.Parse(fldidSplit[1]));
                    appfld.SerialNo = j;
                    _mc.Entry(appfld).State = System.Data.EntityState.Modified;
                    _mc.SaveChanges();

                }
                else
                {

                    string[] fldidSplit = actualsortarray[j].Split(' ');
                    var appfld = _mc.MasterFields.Find(Int32.Parse(fldidSplit[1]));
                    appfld.SerialNo = j;
                    _mc.Entry(appfld).State = System.Data.EntityState.Modified;
                    _mc.SaveChanges();
                }
            }


            Response.Redirect("~/Ticket/List");
        }

        //public void updateFieldApps()
        //{

        //   // string[] sortlist, int[] fieldid, bool[] rmvfld, bool[] mnadatory, bool[] isremovedFromList, bool[] isquickleadfld, bool[] isShowingInGridList
        //    //try
        //    //{

        //  var isShowingInGridList = Request.Form["isShowingInGridList"];
        //  string[] splitstr = isShowingInGridList.Split(',');
        //  var fieldid = Request.Form["fieldid[]"];
        //  string[] fieldids = fieldid.Split(',');

        //  var Masterfieldid = Request.Form["Masterfieldid[]"];
        //  string[] Masterfieldids = Masterfieldid.Split(','); 

        //  var layoutid = (from _d in _mc.MyLayout where _d.UserId == CurrentUser.USR_ID select new { _d.ID }).FirstOrDefault();
        //  int i = 0;
        //    if(splitstr.Length>0)
        //    {
        //        foreach (var fid in Masterfieldids)
        //  {
        //      if (int.Parse(fieldids[i]) == 0)
        //      {
        //          ModuleFields currentModuleFields = new ModuleFields();
        //          var appfld = _mc.MasterFields.Find(int.Parse(fid));

        //          currentModuleFields.DateCreated = DateTime.Now;
        //          currentModuleFields.ModuleSectionID = appfld.ModuleSectionID;
        //          currentModuleFields.ModuleID = appfld.ModuleID;
        //          currentModuleFields.profileID = layoutid.ID;
        //          currentModuleFields.MasterFieldId = appfld.ID;
        //          currentModuleFields.Name = appfld.Name;
        //          currentModuleFields.Caption = appfld.Caption;
        //          currentModuleFields.SerialNo = appfld.SerialNo;
        //          currentModuleFields.Type = appfld.Type;
        //          currentModuleFields.Length = appfld.Length;
        //          currentModuleFields.Decimal = appfld.Decimal;
        //          currentModuleFields.RoundOption = appfld.RoundOption;
        //          currentModuleFields.Precision = appfld.Precision;
        //          currentModuleFields.PickList = appfld.PickList;
        //          currentModuleFields.isFirstDefaultValue = appfld.isFirstDefaultValue;
        //          currentModuleFields.CheckBox = appfld.CheckBox;
        //          currentModuleFields.Prefix = appfld.Prefix;
        //          currentModuleFields.StartNo = appfld.StartNo;
        //          currentModuleFields.Body = appfld.Body;
        //          currentModuleFields.EndNo = appfld.EndNo;
        //          currentModuleFields.Suffix = appfld.Suffix;
        //          currentModuleFields.IsExisting = appfld.IsExisting;
        //          currentModuleFields.IsMandatory = appfld.IsMandatory;
        //          currentModuleFields.IsCustom = appfld.IsCustom;
        //          currentModuleFields.IsRemovable = appfld.IsRemovable;
        //          currentModuleFields.DefaultValue = appfld.DefaultValue;
        //          currentModuleFields.IsHelpPop = appfld.IsHelpPop;
        //          currentModuleFields.HelpPopUrl = appfld.HelpPopUrl;
        //          currentModuleFields.IsReadonly = appfld.IsReadonly;
        //          currentModuleFields.SpecialFieldID = appfld.SpecialFieldID;
        //          currentModuleFields.SpecialCSSClass = appfld.SpecialCSSClass;
        //          currentModuleFields.IsUniqueCheck = appfld.IsUniqueCheck;
        //          currentModuleFields.IsBlankCheck = appfld.IsBlankCheck;
        //          currentModuleFields.IsAppeareMultipleCountry = appfld.IsAppeareMultipleCountry;
        //          currentModuleFields.IsAppeareMultipleState = appfld.IsAppeareMultipleState;
        //          currentModuleFields.IsAppeareMultipleCity = appfld.IsAppeareMultipleCity;
        //          currentModuleFields.IsExtraField = appfld.IsExtraField;
        //          currentModuleFields.ExtraField = appfld.ExtraField;
        //          currentModuleFields.isQuickLead = appfld.isQuickLead;
        //          currentModuleFields.isCopyField = appfld.isCopyField;
        //          currentModuleFields.DataSourceName = appfld.DataSourceName;
        //          currentModuleFields.isShowingListingPage = appfld.isShowingListingPage;
        //          currentModuleFields.columnWidth = appfld.columnWidth;
        //          currentModuleFields.isInPickList = appfld.isInPickList;
        //          currentModuleFields.isAdminVisible = appfld.isAdminVisible;
        //          currentModuleFields.isManagerVisible = appfld.isManagerVisible;
        //          currentModuleFields.isMemberVisible = appfld.isMemberVisible;
        //          currentModuleFields.isClientVisible = appfld.isClientVisible;
        //          _mc.ModuleFields.Add(currentModuleFields);
        //          _mc.SaveChanges();
        //      }
        //      else
        //      {
        //          ModuleFields currentModuleFields = new ModuleFields();
        //          var appfld = _mc.ModuleFields.Find(int.Parse(fieldids[i]));
        //          appfld.isAdminVisible = false;
        //          _mc.Entry(appfld).State = System.Data.EntityState.Modified;
        //            _mc.SaveChanges();
        //      }

        //        //if (bool.Parse(splitstr[i]) == true)
        //        //{
        //        //    appfld.IsRemovable = false;
        //        //    _mc.Entry(appfld).State = System.Data.EntityState.Modified;
        //        //    _mc.SaveChanges();
        //        //}
        //        //else
        //        //{
        //        //    appfld.IsRemovable = true;
        //        //    _mc.Entry(appfld).State = System.Data.EntityState.Modified;
        //        //    _mc.SaveChanges();
        //        //}
        //        i++;
        //  }

        //    }

        //       // var y = rmvfld;
        //        //var xStr = sortlist;
        //       // int XCount = 1;
        //        //if (xStr.Length == 3 || xStr.Length == 2)
        //        //{
        //        //    for (int i = 0; i < xStr.Length; i++)
        //        //    {
        //        //        string[] strSplit = xStr[i].Split(',');
        //        //        for (int j = 1; j < strSplit.Length; j++)
        //        //        {
        //        //            string[] fldidSplit = strSplit[j].Split(' ');
        //        //            //var appfld = CRM_ModuleFields.Find(Int32.Parse(fldidSplit[1]));
        //        //            //appfld.SerialNo = j;
        //        //           // appfld.Save();

        //        //        }

        //        //    }
        //        //}
        //        //else
        //        //{
        //        //    for (int i = 0; i < xStr.Length; i++)
        //        //    {
        //        //        string[] strSplit = xStr[i].Split(',');
        //        //        for (int j = 1; j < strSplit.Length; j++)
        //        //        {
        //        //            string[] fldidSplit = strSplit[j].Split(' ');
        //        //            //var appfld = CRM_ModuleFields.Find(Int32.Parse(fldidSplit[1]));
        //        //           // appfld.SerialNo = j;
        //        //           // appfld.Save();

        //        //        }

        //        //    }

        //        //}

        //        //else
        //        //{
        //        //    string[] strSplit = xStr[0].Split(',');
        //        //    for (int j = 1; j < strSplit.Length; j++)
        //        //    {
        //        //        string[] fldidSplit = strSplit[j].Split(' ');
        //        //        var appfld = ModuleFields.Find(Int32.Parse(fldidSplit[1]));
        //        //        appfld.SerialNo = j;
        //        //        appfld.Save();

        //        //    }

        //        //}



        //    //    int p = 0;
        //    //    foreach (var fid in fieldid)
        //    //    {
        //    //       // var appfld = CRM_ModuleFields.Find(fid);

        //    //        if (appfld != null)
        //    //        {
        //    //            if (rmvfld.Length > 0)
        //    //            {
        //    //                if (rmvfld[p] == true)
        //    //                {
        //    //                    appfld.IsRemovable = false;
        //    //                    appfld.Save();
        //    //                }
        //    //                else
        //    //                {
        //    //                    appfld.IsRemovable = true;
        //    //                    appfld.Save();
        //    //                }
        //    //            }
        //    //            if (mnadatory.Length > 0)
        //    //            {
        //    //                appfld.IsMandatory = mnadatory[p];
        //    //                appfld.isQuickLead = mnadatory[p];
        //    //                appfld.Save();
        //    //            }
        //    //            if (isremovedFromList.Length > 0)
        //    //            {
        //    //                appfld.IsExtraField = isremovedFromList[p];
        //    //                appfld.Save();
        //    //            }

        //    //            if (isShowingInGridList.Length > 0)
        //    //            {
        //    //                appfld.isShowingListingPage = isShowingInGridList[p];
        //    //                appfld.Save();
        //    //            }

        //    //            //------------------------------------------------------isquickleadfld 
        //    //            if (isquickleadfld.Length > 0)
        //    //            {
        //    //                appfld.isQuickLead = isquickleadfld[p];
        //    //                appfld.Save();
        //    //            }




        //    //        }
        //    //        p++;
        //    //    }
        //    //    Flash["delete"] = "Update Succesfully .";

        //    //    CancelLayout();
        //    //    ShowAlertAndNavigate("", "/CreateLayout/Define.html");
        //    //    return;
        //    //}
        //    //catch
        //    //{
        //    //    CancelLayout();
        //    //    ShowAlertAndNavigate("", "/Error/Define.html");
        //    //    // Redirect("", "Error", "Define");
        //    //}

        //    Response.Redirect("~/Ticket/List");

        //}


        public ActionResult CreateLayout()
        {
            Initpage();

            return View();
        }

      
      

        [HttpPost]
        public void updateMasterFieldApps()
        {
            var RoleId = Request.Form["RoleId"];
            //var isShowingInGridList = Request.Form["isShowingInGridList"];
            //string[] splitstr = isShowingInGridList.Split(',');

            var fieldid = Request.Form["fieldid[]"];
            string[] fieldids = fieldid.Split(',');

            var visisblity = Request.Form["isClientVisible"];
            string[] splitvisisblity = visisblity.Split(',');

            var Masterfieldid = Request.Form["Masterfieldid[]"];
            string[] Masterfieldids = Masterfieldid.Split(',');

            var layoutid = (from _d in _mc.MyLayout where _d.UserId == CurrentUser.USR_ID select new { _d.ID }).FirstOrDefault();
            int i = 0;

            if (splitvisisblity.Length > 0)
            {
                foreach (var fid in Masterfieldids)
                {
                    if (int.Parse(fieldids[i]) == 0)
                    {
                        MasterFields currentMasterFields = new MasterFields();

                        var appfld = _mc.FieldList1.Find(int.Parse(fid));

                        currentMasterFields.DateCreated = DateTime.Now;
                        currentMasterFields.ModuleSectionID = appfld.ModuleSectionID;
                        currentMasterFields.ModuleID = appfld.ModuleID;
                        currentMasterFields.FieldListId = appfld.ID;
                        //currentMasterFields.profileID = layoutid.ID;
                        currentMasterFields.Name = appfld.Name;
                        currentMasterFields.Caption = appfld.Caption;
                        currentMasterFields.SerialNo = appfld.SerialNo;
                        currentMasterFields.Type = appfld.Type;
                        currentMasterFields.Length = appfld.Length;
                        currentMasterFields.Decimal = appfld.Decimal;
                        currentMasterFields.RoundOption = appfld.RoundOption;
                        currentMasterFields.Precision = appfld.Precision;
                        currentMasterFields.PickList = appfld.PickList;
                        currentMasterFields.isFirstDefaultValue = appfld.isFirstDefaultValue;
                        currentMasterFields.CheckBox = appfld.CheckBox;
                        currentMasterFields.Prefix = appfld.Prefix;
                        currentMasterFields.StartNo = appfld.StartNo;
                        currentMasterFields.Body = appfld.Body;
                        currentMasterFields.EndNo = appfld.EndNo;
                        currentMasterFields.Suffix = appfld.Suffix;
                        currentMasterFields.IsExisting = appfld.IsExisting;
                        currentMasterFields.IsMandatory = appfld.IsMandatory;
                        currentMasterFields.IsCustom = appfld.IsCustom;
                        if (bool.Parse(splitvisisblity[i]) == true)
                        {
                            currentMasterFields.IsRemovable = false;
                        }
                        else
                        {
                            currentMasterFields.IsRemovable = true;
                        }
                        currentMasterFields.DefaultValue = appfld.DefaultValue;
                        currentMasterFields.IsHelpPop = appfld.IsHelpPop;
                        currentMasterFields.HelpPopUrl = appfld.HelpPopUrl;
                        currentMasterFields.IsReadonly = appfld.IsReadonly;
                        currentMasterFields.SpecialFieldID = appfld.SpecialFieldID;
                        currentMasterFields.SpecialCSSClass = appfld.SpecialCSSClass;
                        currentMasterFields.IsUniqueCheck = appfld.IsUniqueCheck;
                        currentMasterFields.IsBlankCheck = appfld.IsBlankCheck;
                        currentMasterFields.IsAppeareMultipleCountry = appfld.IsAppeareMultipleCountry;
                        currentMasterFields.IsAppeareMultipleState = appfld.IsAppeareMultipleState;
                        currentMasterFields.IsAppeareMultipleCity = appfld.IsAppeareMultipleCity;
                        currentMasterFields.IsExtraField = appfld.IsExtraField;
                        currentMasterFields.ExtraField = appfld.ExtraField;
                        currentMasterFields.isQuickLead = appfld.isQuickLead;
                        currentMasterFields.isCopyField = appfld.isCopyField;
                        currentMasterFields.DataSourceName = appfld.DataSourceName;
                        currentMasterFields.isShowingListingPage = appfld.isShowingListingPage;

                        //currentModuleFields.columnWidth = Convert.ToInt32(splitcolumnWidth[i]);//appfld.columnWidth;
                        currentMasterFields.RoleID = int.Parse(RoleId);
                        //currentModuleFields.isInPickList = appfld.isInPickList;
                        //currentModuleFields.isAdminVisible = appfld.isAdminVisible;
                        //currentModuleFields.isManagerVisible = appfld.isManagerVisible;
                        //currentModuleFields.isMemberVisible = appfld.isMemberVisible;
                        //currentModuleFields.isClientVisible = appfld.isClientVisible;
                        _mc.MasterFields.Add(currentMasterFields);
                        _mc.SaveChanges();
                    }
                    else
                    {
                        var appfld = _mc.MasterFields.Find(int.Parse(fieldids[i]));
                        if (splitvisisblity.Where(x => !string.IsNullOrEmpty(x)).ToArray().Length > 0)
                        {
                            if (bool.Parse(splitvisisblity[i]) == false)
                            {
                                appfld.IsRemovable = true;
                            }
                            else
                            {
                                appfld.IsRemovable = false;
                                // appfld.columnWidth = Convert.ToInt32(splitcolumnWidth[i]);
                            }
                        }
                        //appfld.isAdminVisible = false;
                        _mc.Entry(appfld).State = System.Data.EntityState.Modified;
                        _mc.SaveChanges();
                    }
                    i++;
                }

            }


            //var isClientVisible = Request.Form["isClientVisible"];
            //string[] splitClientVisible = isClientVisible.Split(',');

            //var isAdminVisible = Request.Form["isAdminVisible"];
            //string[] splitAdminVisible = isAdminVisible.Split(',');

            //var isManagerVisible = Request.Form["isManagerVisible"];
            //string[] splitManagerVisible = isManagerVisible.Split(',');

            //var isMemberVisible = Request.Form["isMemberVisible"];
            //string[] splitMemberVisible = isMemberVisible.Split(',');

            //var fieldid = Request.Form["fieldid[]"];
            //string[] fieldids = fieldid.Split(',');
            //MasterFields appfld = new MasterFields();
            //int i = 0;
            //foreach (var fid in fieldids)
            //{

            //    appfld = _mc.MasterFields.Find(int.Parse(fid));
            //    #region ClientVisible
            //    if (splitClientVisible.Where(x => !string.IsNullOrEmpty(x)).ToArray().Length > 0)
            //    {
            //        if (bool.Parse(splitClientVisible[i]) == true)
            //        {
            //            appfld.isClientVisible = true;
            //            _mc.Entry(appfld).State = System.Data.EntityState.Modified;
            //            _mc.SaveChanges();
            //        }
            //        else
            //        {
            //            appfld.isClientVisible = false;
            //            _mc.Entry(appfld).State = System.Data.EntityState.Modified;
            //            _mc.SaveChanges();
            //        }
            //    }
            //    #endregion
            //    #region AdminVisible
            //    if (splitAdminVisible.Where(x => !string.IsNullOrEmpty(x)).ToArray().Length > 0)
            //    {
            //        if (bool.Parse(splitAdminVisible[i]) == true)
            //        {
            //            appfld.isAdminVisible = true;
            //            _mc.Entry(appfld).State = System.Data.EntityState.Modified;
            //            _mc.SaveChanges();
            //        }
            //        else
            //        {
            //            appfld.isAdminVisible = false;
            //            _mc.Entry(appfld).State = System.Data.EntityState.Modified;
            //            _mc.SaveChanges();
            //        }
            //    }
            //    #endregion
            //    #region ManagerVisible
            //    if (splitManagerVisible.Where(x => !string.IsNullOrEmpty(x)).ToArray().Length > 0)
            //    {
            //        if (bool.Parse(splitManagerVisible[i]) == true)
            //        {
            //            appfld.isManagerVisible = true;
            //            _mc.Entry(appfld).State = System.Data.EntityState.Modified;
            //            _mc.SaveChanges();
            //        }
            //        else
            //        {
            //            appfld.isManagerVisible = false;
            //            _mc.Entry(appfld).State = System.Data.EntityState.Modified;
            //            _mc.SaveChanges();
            //        }
            //    }
            //    #endregion
            //    #region MemberVisible
            //    if (splitMemberVisible.Where(x => !string.IsNullOrEmpty(x)).ToArray().Length > 0)
            //    {
            //        if (bool.Parse(splitMemberVisible[i]) == true)
            //        {
            //            appfld.isMemberVisible = true;
            //            _mc.Entry(appfld).State = System.Data.EntityState.Modified;
            //            _mc.SaveChanges();
            //        }
            //        else
            //        {
            //            appfld.isMemberVisible = false;
            //            _mc.Entry(appfld).State = System.Data.EntityState.Modified;
            //            _mc.SaveChanges();
            //        }
            //    }
            //    #endregion
            //    i++;
            //}
            Response.Redirect("~/Setup/MasterField");
        }

        [HttpPost]
        public ActionResult getMyMasterFieldList()
        {
            int RoleId = int.Parse(Request.Form["RoleId"]);
            string moduleList = Request.Form["moduleList"];
                        //bool stype = CurrentUser.IsClient;

            var mymodule = (from _d in _mc.Module where _d.Name == "DEF_TICKET" select _d).FirstOrDefault();
            //var moduleSections = (from _d in _mc.ModuleSection where _d.module.ID == mymodule.ID && _d.ProfileID == layoutid.ID select _d);
            //ViewBag.moduleSection = moduleSections.ToList();

            var moduleFields = (from _d in _mc.FieldList1
                                join x in _mc.MasterFields on _d.ID equals x.FieldListId into t
                                from rt in t.Where(f => f.RoleID == RoleId).DefaultIfEmpty()
                                where _d.ModuleID == mymodule.ID
                                //&& ((_d.isAdminVisible == CurrentUser.IsAdministration && CurrentUser.IsAdministration == true)
                                //      || (_d.isManagerVisible == CurrentUser.IsManager && CurrentUser.IsManager == true)
                                //      || (_d.isMemberVisible == CurrentUser.IsMember && CurrentUser.IsMember == true)
                                //      || (_d.isClientVisible == CurrentUser.IsClient && CurrentUser.IsClient == true))
                                select new ModuleFieldsView
                                {
                                    Caption = (rt.Caption == null ? _d.Caption : rt.Caption),
                                    ID = (rt.ID == null ? 0 : rt.ID),
                                    FieldListId = _d.ID,
                                    Name = _d.Name,
                                    Type = _d.Type,
                                    ModuleID = _d.ModuleID,
                                    ModuleSectionID = _d.ModuleSectionID,
                                    IsRemovable = (rt.IsRemovable == null ? _d.IsRemovable : rt.IsRemovable)

                                });



            //).DefaultIfEmpty()
            //Caption = (rt.Caption == null ? _d.Caption : rt.Caption),
            // _d.ID,
            //_d.Name,
            //_d.Type,
            //_d.ModuleID,
            //_d.ModuleSectionID,
            //IsRemovable = (rt.IsRemovable == null ? _d.IsRemovable : rt.IsRemovable)



            //.where(_d.module.ID == mymodule.ID && _d.IsExtraField == false ).DefaultIfEmpty());

            //where 
            //((_d.isAdminVisible == CurrentUser.IsAdministration && CurrentUser.IsAdministration == true) || (_d.isManagerVisible == CurrentUser.IsManager && CurrentUser.IsManager == true) || (_d.isMemberVisible == CurrentUser.IsMember && CurrentUser.IsMember == true) || (_d.isClientVisible == CurrentUser.IsClient && CurrentUser.IsClient == true))
            //select _d);
            // ViewBag.moduleField = moduleFields.ToList();

            return PartialView("getMyMasterFieldList", moduleFields.ToList());

        }

        [HttpPost]
        public ActionResult PreviewMoudulePartial(string ShowingInList, string columnwidth, string ID)
        {
            //DataTable _model = new DataTable();
            string[] ShowInList = ShowingInList.Split(',');
            string[] colwidth = columnwidth.Split(',');
            string[] tblId = ID.Split(',');
            int finalfieldId;
            List<GetPreview> PreviewList = new List<GetPreview>();
            if (ShowInList.Where(x => !string.IsNullOrEmpty(x)).ToArray().Length > 0)
            {
                for (int i = 0; i < ShowInList.Length; i++)
                {
                    if (!string.IsNullOrEmpty(ShowInList[i]))
                    {
                        if (bool.Parse(ShowInList[i].ToString()) == true)
                        {
                            finalfieldId = int.Parse(tblId[i]);
                            var listfield = (from x in _mc.ModuleFields.Where(k => k.ID == finalfieldId) select new { x.Caption, x.Name }).ToList();
                            //_model.Columns.Add(listfield[0].Name,typeof(System.String));
                            PreviewList.Add(new GetPreview
                            {
                                ColName = listfield[0].Name,
                                ColCaption = listfield[0].Caption,
                                Colwidth = colwidth[i],
                                IsActive = ShowInList[i]

                            });
                        }
                    }

                }
                ViewBag.ActiveField = PreviewList;
            }

            return PartialView("PreviewMoudulePartial");
        }

        public ActionResult RoleDefine()
        {
            Initpage();
            ViewBag.Id = 0;
            return View();
        }
        [HttpPost]
        public ActionResult ModifyRole(int ID)
        {
            Initpage();
            RoleMaster _rm = _mc.RoleMaster.Find(ID);
            if (_rm == null)
            {
                ViewBag.ErrorText = "This Client does not exists.";
                return PartialView("Error");
            }
            ViewBag.Id = _rm.Id;
            ViewBag.mode = "Edit";
             string sreportlist = _rm.reportlist;
            var SourceLists = new List<ReportmenuShow>();
            foreach (var mcreportmenu in _mc.Reportmenu)
            {
              

                SourceLists.Add(new ReportmenuShow
            {

                ID = mcreportmenu.ID,
                Name = mcreportmenu.Name,
                Show = ((sreportlist.Contains(mcreportmenu.ID.ToString()) == true ) ? "Y" :"N")

            });
            }


            //ViewBag.ReportModel = _mc.Reportmenu;
            ViewBag.ReportModel = SourceLists.ToList();
           

            return View("RoleDefine", _rm);
        }
        public void SaveRole(RoleMaster roleMaster)
        {
            string _ErrorMsg = "";
            //string selectedReport = Request.Form["reportlist"];
            //string[] splitstr = selectedReport.Split(',');

            try
            {
                if (roleMaster.Id > 0)
                {
                    // var appfld = _mc.RoleMaster.Find(roleMaster.Id);
                    RoleMaster currentRoleMater = roleMaster;
                    currentRoleMater.DateCreated = DateTime.Now;
                    _mc.Entry(currentRoleMater).State = System.Data.EntityState.Modified;
                    _mc.SaveChanges();
                }
                else
                {
                    RoleMaster currentRoleMater = roleMaster;
                    currentRoleMater.DateCreated = DateTime.Now;
                    _mc.RoleMaster.Add(currentRoleMater);
                    if (ModelState.IsValid)
                    {
                        _mc.SaveChanges();
                    }
                }
            }
            catch (Exception _ex)
            {
                _ErrorMsg = _ex.Message;
                RedirectToAction("RoleDefine");
            }
            finally
            {
                _mc.Dispose();
                _mc = null;
            }

            Response.Redirect("~/Setup/RoleList");
        }
       [HttpPost]
        public void DeleteRole(int ID)
        {
            RoleMaster _rm = _mc.RoleMaster.Find(ID);
            if (_rm != null)
            {
                _mc.RoleMaster.Remove(_rm);
                _mc.SaveChanges();
            }
            else
            {
                ViewBag.ErrorText = "This Client does not exists.";
               // return PartialView("Error");
               
            }
            Response.Redirect("~/Setup/RoleList");
        }




        public ActionResult RoleList()
        {
            Initpage();
            string SiteRoot = System.Configuration.ConfigurationManager.AppSettings["SiteRoot"];
            ViewBag.SiteRoot = SiteRoot;
            string query = "SELECT RL.Id,RL.DateCreated,RL.RoleName,RL.Description,RL.IsCategory, ";

            query += "RL.IsFieldAccess,RL.IsUserAccess,RL.IsChangeStatus FROM  (SELECT ROW_NUMBER() OVER (ORDER BY   ##ID##   ##desc##) as row,* FROM RoleMaster where    ##filters## ) RL   Where   ##paging##  ";
            ViewBag.query = query;


            return PartialView();
        }


        

        [ValidateInput(false)]
        public ActionResult RoleDetailsPartial()
        {
            var model = (from RL in _mc.RoleMaster
                         select new
                         {
                             RL.Id,
                             RL.DateCreated,
                             RL.RoleName,
                             RL.Description,
                             RL.IsCategory,
                             RL.IsNewTicket,
                             RL.IsGrouopClientMapping,
                             RL.IsFieldAccess,
                             RL.IsUserAccess,
                             RL.IsChangeStatus,
                             RL.IsViewInternalDiscussion,
                             RL.IsAssignTo,
                             RL.IsApproval,
                             RL.IsPriority,
                             RL.IsCreateUser,
                             RL.IsCreateUserGroup,
                             RL.IsCreateCustomer,
                             RL.IsViewGroupTicket,
                            
                             RL.IsShowLayOut
                         }).ToList().OrderByDescending(k => k.Id);
            return PartialView("_RoleDetailsPartial", model);
        }
        //===================================================
        public class GetPreview
        {
            public string ColName { get; set; }
            public string ColCaption { get; set; }
            public string Colwidth { get; set; }
            public string IsActive { get; set; }
        }
        //============================================

    }
}
