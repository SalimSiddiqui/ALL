using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using System.Data.SqlClient;
using TestingP.Models;
namespace TestingP.Controllers
{
    public class HomeController : Controller
    {
        UsersContext db = new UsersContext();
        public ActionResult Index()
        {
           List<UserProfile> ab= db.UserProfiles.ToList();

           //UserProfile A = new UserProfile { UserId = 1, UserName = "sa" };
           //UserProfile B = new UserProfile { UserId = 2, UserName = "aa" };
           //UserProfile C = new UserProfile { UserId = 3, UserName = "ba" };
           //db.UserProfiles.Add(A);
           //db.UserProfiles.Add(B);
           //db.UserProfiles.Add(C);
           //db.SaveChanges();



           return View(ab);
        }
        public ActionResult List()
        {
            List<UserProfile> ab = db.UserProfiles.ToList();

            //UserProfile A = new UserProfile { UserId = 1, UserName = "sa" };
            //UserProfile B = new UserProfile { UserId = 2, UserName = "aa" };
            //UserProfile C = new UserProfile { UserId = 3, UserName = "ba" };
            //db.UserProfiles.Add(A);
            //db.UserProfiles.Add(B);
            //db.UserProfiles.Add(C);
            //db.SaveChanges();



            return View(ab);
        }
    }

}
