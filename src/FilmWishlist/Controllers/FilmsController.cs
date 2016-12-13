using System.Web.Mvc;
using FilmWishlist.Models;
using FilmWishlist.Service;

namespace FilmWishlist.Controllers
{
    [RoutePrefix("Films")]
    public class FilmsController : Controller
    {
        private readonly IAddFilmService _addFilmService;
        private readonly IFilmDescriptionService _descriptionService;

        public FilmsController(IAddFilmService addFilmService, IFilmDescriptionService descriptionService)
        {
            _addFilmService = addFilmService;
            _descriptionService = descriptionService;
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult Add(string title, int year) => Redirect(_addFilmService.AddFilm(title, year) == AddFilmResult.Successful ? "/" : "/?status=failedtoadd");

        [Route("{name}-{year}/Details")]
        public ActionResult Details(string name, string year) => View("Details", new FilmDetailsViewModel
        {
            FilmName = $"{name} ({year})",
            FilmDescription = _descriptionService.Get(name, year)
        });
    }
}