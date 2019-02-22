using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using VIAD.App_Start;

namespace CentManagerment
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.MapRoute(
            //    name: "InsertClass",
            //    url: "them-lop-hoc",
            //    defaults: new { controller = "ClassManagerment", action = "InsertView", id = UrlParameter.Optional }
            //);

            //Chi tiết bài viết tin tức
            routes.Add("DetailsNew", new SeoFriendlyRoute("tin-tuc/{id}",
                new RouteValueDictionary(new { controller = "Home", action = "DetailsNew" }),
                new MvcRouteHandler()));


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
