﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using RecipeAPIProject.Models;

namespace RecipeAPIProject.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext ORM = new ApplicationDbContext();

        public ActionResult Index()
        {
           ViewBag.results = RecipeDAL.GetRecipes(null)["results"];
           return View();
        }

        public ActionResult About()
        {
            
            return View(RecipeDAL.GetRecipes(null)["results"]);
        }

        public ActionResult Contact(List<Favorites> faves)
        {
            

            return View(faves);
        }

       


    }
}