using System.Collections.Generic;
using System.Web.Mvc;
using FilmWishlist.Models;

namespace FilmWishlist.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var listOfFilms = new List<Film> {new Film("x", 2015), new Film("Y", 2001), new Film("z", 2023)};

            var model = new HomePageViewModel
            {
                FilmListViewModel = new FilmListViewModel
                {
                    Films = listOfFilms
                }
            };
            return View(model);
        }
    }
}