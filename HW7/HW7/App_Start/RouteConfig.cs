using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HW7
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "User profile",
               url: "api/user",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Repos List",
               url: "api/repositories",
               defaults: new { controller = "Home", action = "Repos", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Commits List",
                url: "api/Commits/{id}",
                defaults: new { controller = "Home", action = "Commits", id = UrlParameter.Optional }
            );
           
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
