using BusinessLogicLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PasteBook_FinalProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //// reference: https://www.asp.net/mvc/overview/older-versions-1/controllers-and-routing/creating-a-route-constraint-cs

            //routes.MapRoute(
            //    name: "Post",
            //    url: "posts/{id}",
            //    defaults: new { controller = "Post", action = "Get" },
            //    constraints: new { id = @"\d+" } // regular expression \d+ matches one or more integers
            //                                     //constraints: new { id = @"s/0*(\d+)/$1/" }
            //);

            //// reference: http://stackoverflow.com/a/37359345
            //routes.MapRoute(
            //    name: "PasteBook",
            //    url: "PasteBook/{username}",
            //    defaults: new { controller = "PasteBook", action = "Timeline" },
            //    constraints: new { username = new UserNameConstraint() }
            //);
            routes.MapRoute(
                "sample",
                "PasteBook/{action}",
                new { controller = "Pastebook", action = "index", username = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }

    //public class UserNameConstraint : IRouteConstraint
    //{
    //    BusinessLogic businessLogic = new BusinessLogic();
    //    Mapper mapper = new Mapper();
    //    public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
    //    {
    //        // Get the userName from the url
    //        var userName = values["userName"].ToString();
    //        var user = businessLogic.GetSpecificUser(mapper.UserMapper(null, userName));
    //        if (string.IsNullOrEmpty(user.USER_NAME))
    //        {
    //            return false;
    //        }
    //        else
    //        {
    //            return true;
    //        }
    //    }
    //}
}


