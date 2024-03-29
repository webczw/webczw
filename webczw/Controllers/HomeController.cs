﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webczw.BLL;
using webczw.Models;
using webczw.Models.Query;

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
 /*
        public ActionResult Blog()
        {
           
            int currentPage = Convert.ToInt32(Request.QueryString["currentPage"]);
            UserManager userManager = new UserManager();
            //UserModels queryUserModels = new UserModels();
            //queryUserModels.Id = "028636db-f6b6-4640-9001-341931a799a2";
            //queryUserModels.UserName = "wwe56@163.com";
            //ViewBag.UserModelsList = userManager.findUserList(queryUserModels);
            ViewBag.UserModelsList = userManager.findAllUserList();
            ViewBag.Message = "在这里写下我的想法";
            return View();
            

            ArticlesModels articlesModels = new ArticlesModels();
            articlesModels.CurrentPage = 0;
            articlesModels.PageSize = 15;
            ArticlesManager articlesManager = new ArticlesManager();
            PageResultModels<ArticlesModels> pageResultModels = articlesManager.findListByPage(articlesModels);
            ViewBag.PageResultModels = pageResultModels;
            ViewBag.Message = "在这里写下我的想法";
            return View();
        }*/

        public ActionResult Blog(int? currentPage,int? articleTypesId) {
            ArticlesQueryModels articlesQueryModels = new ArticlesQueryModels();
            articlesQueryModels.CurrentPage = currentPage == null ? 1 : Convert.ToInt32(currentPage);
            
            articlesQueryModels.ArticleTypesId = articleTypesId == null ? 0 : Convert.ToInt32(articleTypesId);
            articlesQueryModels.PageSize = 15;
            ArticlesManager articlesManager = new ArticlesManager();
            PageResultModels<ArticlesModels> pageResultModels = articlesManager.findListByPage(articlesQueryModels);
            ViewBag.PageResultModels = pageResultModels;
            
            if (articlesQueryModels.ArticleTypesId == 0)
            {
                ActicleTypeModels acticleTypeModels = new ActicleTypeModels();
                acticleTypeModels.Name = "全部";
                acticleTypeModels.Id = 0;
                ViewBag.ActicleTypeModels = acticleTypeModels;
            }
            else {
                ActicleTypeManager acticleTypeManager = new ActicleTypeManager();
                ViewBag.ActicleTypeModels = acticleTypeManager.findById(articlesQueryModels.ArticleTypesId);
            }
            ViewBag.Message = "在这里写下我的想法";
            return View();
        }

        public ActionResult Detail(int? id)
        {
            if (id == null) {
                ViewBag.Message = "参数缺少ID";
                return View();
            }
            ArticlesManager articlesManager = new ArticlesManager();
            ArticlesModels articlesModels = articlesManager.findById(Convert.ToInt32(id));
            if (articlesModels == null)
            {
                ViewBag.Message = "系统找不到数据，入参ID为：" + id;
                return View();
            }
            ViewBag.ArticlesModels = articlesModels;
            ViewBag.Message = articlesModels.Title;
            return View();
        }

        public ActionResult _Layout()
        {
            ActicleTypeManager acticleTypeManager = new ActicleTypeManager();
            List<ActicleTypeModels> list = acticleTypeManager.findList();
            ViewBag.ActicleTypeModelsList = list;
            return PartialView();
        }

    }
}