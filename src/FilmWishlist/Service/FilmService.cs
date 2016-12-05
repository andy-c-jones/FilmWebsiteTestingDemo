using FilmWishlist.Models;
using IntegrationTestingAndMockingWorkshop;

namespace FilmWishlist.Service
{
    public class FilmService
    {
        private readonly IFilmRepository _filmRepository;

        public FilmService(IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        public RepositoryResult AddFilm(string title, int year)
        {
            return _filmRepository.Add(new Film(title, year));
        }
    }
}