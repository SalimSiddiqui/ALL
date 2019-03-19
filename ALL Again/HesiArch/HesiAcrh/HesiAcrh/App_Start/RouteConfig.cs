using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Core;
using Data;
using HesiAcrh.Models;
using AutoMapper;
namespace HesiAcrh
{
    public class RouteConfig
    {
        public RouteConfig()
        {
          


         //   var mappeddata = AutoMapper.Mapper.Map<Exam, ExamData>(uobj);
        }
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
