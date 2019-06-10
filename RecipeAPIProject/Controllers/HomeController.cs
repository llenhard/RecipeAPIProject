using System;
using System.Collections.Generic;
using System.IO;
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

        public ActionResult Index(string type = null, string input = null)
        {
           ViewBag.results = RecipeDAL.GetRecipes($"?{type}{input}")["results"];
           return View();
        }

        public ActionResult About(string item)
        {
            JObject parsed = JObject.Parse(item);
            return View(parsed);
        }

        public ActionResult Contact(List<Favorites> faves)
        {
            List<JObject> favorites = new List<JObject>();
            string userId = User.Identity.GetUserId();

            foreach(var item in ORM.Favorites.Where(f => f.UserID == userId).ToList())//lol
            {
                JObject favorite = JObject.Parse(item.RecipeTitle);
                favorites.Add(favorite);
            }

            return View(favorites);
        }

        public ActionResult SaveNewFavorite(string item)
        {
            string userId = User.Identity.GetUserId();

            if(userId == null)
            {
                return RedirectToAction("../Account/Login");
            }

            Favorites newFav = new Favorites();
            newFav.UserID = userId;
            newFav.RecipeTitle = item;
            ORM.Favorites.Add(newFav);
            ORM.SaveChanges();
            return RedirectToAction("../Home/Contact");
        }

        public ActionResult RemoveFavorite(string item)
        {
            string userId = User.Identity.GetUserId();

            if (userId == null)
            {
                return RedirectToAction("../Account/Login");
            }

            Favorites favorite = ORM.Favorites.Where(f => f.UserID == userId && f.RecipeTitle == item).First();
            ORM.Favorites.Attach(favorite);
            ORM.Favorites.Remove(favorite);
            ORM.SaveChanges();
            
            return RedirectToAction("../Home/Contact");
        }
    }
}