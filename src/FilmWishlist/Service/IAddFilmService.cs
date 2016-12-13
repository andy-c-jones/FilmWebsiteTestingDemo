using System.Collections.Generic;
using FilmWishlist.Models;

namespace FilmWishlist.Service
{
    public interface IAddFilmService
    {
        AddFilmResult AddFilm(string title, int year);
        IEnumerable<Film> GetWishlist();
    }
}