using System.Web.Mvc;
using FilmWishlist.Models;
using FilmWishlist.Service;

namespace FilmWishlist.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAddFilmService _addFilmService;

        public HomeController(IAddFilmService addFilmService)
        {
            _addFilmService = addFilmService;
        }

        [Route("~/")]
        public ActionResult Index(string status) => View(new HomePageViewModel
        {
            FilmListViewModel = new FilmListViewModel
            {
                Films = _addFilmService.GetWishlist()
            },
            AddFilmViewModel = new AddFilmViewModel
            {
                StatusViewName = AddFilmStatus(status)
            }
        });

        private static string AddFilmStatus(string status) => status == "failedtoadd" ? "DuplicateFilmWarning" : string.Empty;
    }
}