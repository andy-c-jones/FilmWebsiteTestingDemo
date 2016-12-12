using FilmWishlist.Models;

namespace FilmWishlist.Repositories
{
    public interface IFilmRepository
    {
        RepositoryResult Add(Film film);
        GetFilmsResult GetAll();
    }
}