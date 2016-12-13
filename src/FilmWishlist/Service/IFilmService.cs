using System.Collections.Generic;
using FilmWishlist.Models;

namespace FilmWishlist.Service
{
    public interface IFilmService
    {
        AddFilmResult AddFilm(string title, int year);
        IEnumerable<Film> GetWishlist();
    }
}