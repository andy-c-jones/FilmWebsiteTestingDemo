using System.Web.Mvc;
using FilmWishlist.Models;
using FilmWishlist.Service;

namespace FilmWishlist.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFilmService _filmService;

        public HomeController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        public ActionResult Index() => View(new HomePageViewModel
        {
            FilmListViewModel = new FilmListViewModel
            {
                Films = _filmService.GetWishlist()
            }
        });
    }
}