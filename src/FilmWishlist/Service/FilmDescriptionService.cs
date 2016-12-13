using FilmWishlist.Models;
using FilmWishlist.Repositories;

namespace FilmWishlist.Service
{
    public class FilmDescriptionService : IFilmDescriptionService
    {
        private readonly IFilmDescriptionRepository _repository;

        public FilmDescriptionService(IFilmDescriptionRepository repository)
        {
            _repository = repository;
        }

        public string Get(string title, string year) => Description(_repository.GetDescriptionResult(title, year));

        private static string Description(GetDescriptionRepositoryResult result) =>
            result.Result == RepositoryResult.Failed
                ? "No description found."
                : result.Value;
    }
}