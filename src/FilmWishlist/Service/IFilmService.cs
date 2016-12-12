using System.Collections.Generic;
using FilmWishlist.Models;

namespace FilmWishlist.Service
{
    public interface IFilmService
    {
        RepositoryResult AddFilm(string title, int year);
        IEnumerable<Film> GetWishlist();
    }
}