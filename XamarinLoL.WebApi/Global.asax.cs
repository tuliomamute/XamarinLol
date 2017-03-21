using RiotSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Configuration;

namespace XamarinLoL.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static RiotApi api = RiotApi.GetInstance(ConfigurationManager.AppSettings["ApiKey"]);
        public static StaticRiotApi staticapi = StaticRiotApi.GetInstance(ConfigurationManager.AppSettings["ApiKey"]);

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
