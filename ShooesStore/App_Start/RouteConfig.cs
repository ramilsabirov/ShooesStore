using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShooesStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                null, "",
                  new { controller = "Home", action = "Index", shoesType = (string)null, page = 1 });


            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new  {controller = "Home", action = "Index", shoesType = (string)null },
                constraints: new { page = @"\d+"});

            routes.MapRoute(
                null,  "{shoesType}",
                  new { controller = "Home", action = "Index", page = 1 }  );

            routes.MapRoute(
                null,  "{shoesType}/Page{page}",
                new { controller = "Home", action = "Index" },
                 new { page = @"\d+"}
                 );

            routes.MapRoute(
                null, url: "{controller}/{action}");
        }
    }
}
