
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PDFTOXLS
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //System.Data.Entity.Database.SetInitializer<PDFTOXLS.Models.CompanyContext>(null);
           System.Data.Entity.Database.SetInitializer<PDFTOXLS.Models.MainContext>(null);
           // System.Data.Entity.Database.SetInitializer<PDFTOXLS.Models.LivedataContext>(null);

        }
        protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            //DevExpressHelper.Theme = "MetropolisBlue";
            //DevExpressHelper.Theme = "Mulberry";
           // DevExpressHelper.Theme = "Aqua";
            //DevExpressHelper.Theme = "Office2010Black"
            //DevExpressHelper.Theme = "Office2010Blue";
            //DevExpressHelper.Theme = "RedWine";
            //HttpCookie c = Request.Cookies["theme"];
            //DevExpressHelper.Theme = c == null ? "Aqua" : c.Value;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 40000;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }
        protected void Session_End(object sender, EventArgs e)
        {
        }
        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}