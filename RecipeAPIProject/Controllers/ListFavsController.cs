using Microsoft.AspNet.Identity;
using RecipeAPIProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeAPIProject.Controllers
{
    public class ListFavsController : Controller
    {


        RecipeDbEntities ORM = new RecipeDbEntities();


        public ActionResult GetFavorites(string recipe)
        {
            string userId = User.Identity.GetUserId();
            List<Favorites> favoriteList = ORM.Favorites.ToList();

            return RedirectToAction("Contact", new {favoriteList});
        }




        // GET: ListFavs
        public ActionResult Index()
        {
            return View();
        }
    }
}