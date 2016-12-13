using System.Web.Mvc;
using FilmWishlist.Models;
using FilmWishlist.Service;

namespace FilmWishlist.Controllers
{
    [RoutePrefix("Films")]
    public class FilmsController : Controller
    {
        private readonly IFilmService _filmService;

        public FilmsController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult Add(string title, int year) => Redirect(_filmService.AddFilm(title, year) == AddFilmResult.Successful ? "/" : "/?status=failedtoadd");
    }
}