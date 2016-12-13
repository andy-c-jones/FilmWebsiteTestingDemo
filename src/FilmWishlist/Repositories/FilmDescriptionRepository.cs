using FilmWishlist.Models;

namespace FilmWishlist.Repositories
{
    public class FilmDescriptionRepository : IFilmDescriptionRepository
    {
        public GetDescriptionRepositoryResult GetDescriptionResult(string title, string year) => new GetDescriptionRepositoryResult();
    }
}