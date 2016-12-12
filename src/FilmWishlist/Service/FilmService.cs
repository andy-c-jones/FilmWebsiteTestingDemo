using System.Collections.Generic;
using System.Linq;
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

        public RepositoryResult AddFilm(string title, int year) => _filmRepository.Add(new Film(title, year));
        public IEnumerable<Film> GetWishlist() => Wishlist(_filmRepository.GetAll());

        private static IEnumerable<Film> Wishlist(GetFilmsResult result) => result.Result == RepositoryResult.Failed ? EmptyFilmsList() : FilmsFromEntities(result.Value);
        private static IEnumerable<Film> FilmsFromEntities(IEnumerable<FilmEntity> filmEntities) => filmEntities.Select(filmEntity => new Film(filmEntity.Title, filmEntity.Year));
        private static IEnumerable<Film> EmptyFilmsList() => new Film[0];
    }
}