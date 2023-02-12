using CSharp_Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IMSSKD_WebService
{
    public class RouteConfig
    { 
    public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Polaris

            StringBuilder strCopyRight = new StringBuilder();
            strCopyRight.AppendFormat(Constants.STRING_COPYRIGHT, Utils.GetCurrentYear());
            var ddddd = strCopyRight.ToString();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
