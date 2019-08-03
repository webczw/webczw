using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace webczw
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Detail",
               url: "Home/Detail/{id}",
               defaults: new { controller = "Home", action = "Detail", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Blog1",
               url: "Home/Blog/{currentPage}",
               defaults: new { controller = "Home", action = "Blog", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Blog2",
                url: "Home/Blog/{currentPage}/{articleTypesId}",
                defaults: new { controller = "Home", action = "Blog", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
