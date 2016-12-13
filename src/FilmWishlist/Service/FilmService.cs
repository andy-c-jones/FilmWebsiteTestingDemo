using System.Collections.Generic;
using System.Linq;
using FilmWishlist.Models;
using FilmWishlist.Repositories;

namespace FilmWishlist.Service
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository _filmRepository;

        public FilmService(IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        public AddFilmResult AddFilm(string title, int year) => AddFilmUnlessFilmsCannotBeRetrieved(title, year, _filmRepository.GetAll());
        public IEnumerable<Film> GetWishlist() => Wishlist(_filmRepository.GetAll());


        private AddFilmResult AddFilmUnlessFilmsCannotBeRetrieved(string title, int year, GetFilmsResult getFilmsResult) =>
            getFilmsResult.Result == RepositoryResult.Failed
                ? AddFilmResult.Failed
                : AddFilmUnlessDuplicate(title, year, getFilmsResult.Value);

        private AddFilmResult AddFilmUnlessDuplicate(string title, int year, IEnumerable<FilmEntity> films) =>
            films.Any(f => f.Title == title && f.Year == year)
                ? AddFilmResult.Duplicate
                : Add(title, year);

        private AddFilmResult Add(string title, int year) =>
            _filmRepository.Add(new Film(title, year)) == RepositoryResult.Successful
            ? AddFilmResult.Successful
            : AddFilmResult.Failed;

        private static IEnumerable<Film> Wishlist(GetFilmsResult result) => result.Result == RepositoryResult.Failed ? EmptyFilmsList() : FilmsFromEntities(result.Value);
        private static IEnumerable<Film> FilmsFromEntities(IEnumerable<FilmEntity> filmEntities) => filmEntities.Select(filmEntity => new Film(filmEntity.Title, filmEntity.Year));
        private static IEnumerable<Film> EmptyFilmsList() => new Film[0];
    }
}