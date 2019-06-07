using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using RecipeAPIProject.Models;

namespace RecipeAPIProject.Controllers
{
    public class HomeController : Controller
    {
        private RecipeDbEntities ORM = new RecipeDbEntities();

        public ActionResult Index()
        {
           ViewBag.results = RecipeDAL.GetRecipes(null)["results"];
           return View();
        }

        public ActionResult About()
        {
            
            return View(RecipeDAL.GetRecipes(null)["results"][0]);
        }

        public ActionResult Contact()
        {
            

            return View();
        }

        public ActionResult SaveNewFavorite(string title)
        {
            string userId = User.Identity.GetUserId();
            Favorites newFav = new Favorites();
            newFav.UserID = userId;
            newFav.RecipeTitle = title;
            ORM.Favorites.Add(newFav);
            ORM.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}