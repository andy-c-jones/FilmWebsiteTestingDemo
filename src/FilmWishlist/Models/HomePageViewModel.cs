using FilmWishlist.Controllers;

namespace FilmWishlist.Models
{
    public class HomePageViewModel
    {
        public FilmListViewModel FilmListViewModel { get; set; }
        public AddFilmViewModel AddFilmViewModel { get; set; }
    }
}