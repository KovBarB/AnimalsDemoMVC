using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NewAnimalSearch
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");            

            routes.MapRoute(
            "AnimalsDetailsRoute",
            "Animals/{slug}/{animalId}",
            new { controller = "Animals", action = "Details", slug = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //"AnimalsRoute",
            //"Animals/{slug}/{animalId}",
            //new { controller = "Animals", action = "Edit", slug = UrlParameter.Optional }
            //);

            routes.MapRoute(
            "OrgsDetailsRoute",
            "Organisations/{slug}/{orgId}",
            new { controller = "Organisations", action = "Details", slug = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
