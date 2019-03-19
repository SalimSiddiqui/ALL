using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;
using Data;

namespace HesiAcrh.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Exam()
        {
            ExamData Obj = new ExamData();
            List<Exam> ListExam = new List<Exam>();
            ListExam = Obj.DisplayExamData();
            ViewBag.Message = "Your contact page.";

            return View(ListExam);
        }
        public ActionResult ShowExam()
        {
            ExamData Obj = new ExamData();
            List<Exam> ListExam = new List<Exam>();
            ListExam = Obj.DisplayExamData();
            ViewBag.Message = "Your contact page.";

            return View(ListExam);
        }
        public ActionResult Create()
        {
         
            return View();
        }

    }
}