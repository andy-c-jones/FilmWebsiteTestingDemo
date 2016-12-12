using System.Web.Mvc;
using FilmWishlist.Models;
using FilmWishlist.Service;

namespace FilmWishlist.Controllers
{
    public class FilmsController : Controller
    {
        private readonly IFilmService _filmService;

        public FilmsController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        [HttpPost]
        public ActionResult Add(string title, int year) => Redirect(_filmService.AddFilm(title, year) == RepositoryResult.Successful ? "/" : "/?failed=true");
    }
}