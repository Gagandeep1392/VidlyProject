﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VidlyNew
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            //Using Old Method of Routing,Not to be used as Function name does not change here

            //routes.MapRoute(
            //    "MoviesByReleaseDate", 
            //    "{controller}/{action}/{year}/{month}",
            //    new {controller = "Movies",action = "ByReleaseDate"},
            //    new {year = @"\d{4}",month = @"\d{2}"}
            //    );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
