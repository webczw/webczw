using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webczw.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "这是关于我的简介";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "这是我的联系方式，可以联系到我";

            return View();
        }

        public ActionResult Blog()
        {
            ViewBag.Message = "在这里写下我的想法";

            return View();
        }
    }
}