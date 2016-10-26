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

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "PasteBookAccount", action = "LogIn", id = UrlParameter.Optional }
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


