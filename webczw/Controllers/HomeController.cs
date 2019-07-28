using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webczw.BLL;
using webczw.Models;

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
            UserManager userManager = new UserManager();
            //UserModels queryUserModels = new UserModels();
            //queryUserModels.Id = "028636db-f6b6-4640-9001-341931a799a2";
            //queryUserModels.UserName = "wwe56@163.com";
            //ViewBag.UserModelsList = userManager.findUserList(queryUserModels);
            ViewBag.UserModelsList = userManager.findAllUserList();
            ViewBag.Message = "在这里写下我的想法";
            return View();
        }
    }
}