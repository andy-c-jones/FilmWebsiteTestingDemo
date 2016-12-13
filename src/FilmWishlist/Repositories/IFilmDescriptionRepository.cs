using FilmWishlist.Models;

namespace FilmWishlist.Repositories
{
    public interface IFilmDescriptionRepository
    {
        GetDescriptionRepositoryResult GetDescriptionResult(string title, string year);
    }
}