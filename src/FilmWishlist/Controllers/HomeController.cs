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

        [Route("~/")]
        public ActionResult Index(string status) => View(new HomePageViewModel
        {
            FilmListViewModel = new FilmListViewModel
            {
                Films = _filmService.GetWishlist()
            },
            AddFilmViewModel = new AddFilmViewModel
            {
                StatusViewName = AddFilmStatus(status)
            }
        });

        private static string AddFilmStatus(string status)
        {
            return status == "failedtoadd" ? "DuplicateFilmWarning" : string.Empty;
        }
    }
}