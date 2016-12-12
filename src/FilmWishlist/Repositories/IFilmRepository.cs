using FilmWishlist.Models;

namespace IntegrationTestingAndMockingWorkshop
{
    public interface IFilmRepository
    {
        RepositoryResult Add(Film film);
        GetFilmsResult GetAll();
    }
}