using System;
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
        public ActionResult Index()
        {
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

        public ActionResult JellyBean()
        {

            List<FavoriteRecipe> favoriteList = ORM.FavoriteRecipes.ToList();

            return View(favoriteList);
            
        }


    }
}