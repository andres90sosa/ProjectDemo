﻿using ProjectDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectDemo.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
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

        public ActionResult MostrarTodos()
        {
            var videoJuegos = db.VideoJuegos.ToList();
            return PartialView("_MostrarTodos", videoJuegos);
        }

        public ActionResult MostrarVideoJuego(int id)
        {
            VideoJuego videoJuego = db.VideoJuegos.Find(id);

            if(videoJuego == null)
            {
                return HttpNotFound();
            }
            return PartialView("_MostrarVideoJuego", videoJuego);
        }
    }
}