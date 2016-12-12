using System.Linq;
using FilmWishlist.Models;
using FilmWishlist.Repositories;
using FilmWishlist.Service;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class FilmServiceTests
    {
        [Test]
        public void GivenNoExistingFilmsWhenAddFilmCalledThenTheFilmIsAddedToTheDatabase()
        {
            var filmRepository = new Mock<IFilmRepository>();
            filmRepository
                .Setup(r => r.Add(It.Is<Film>(f => f.Title == "Shawshank Redemption" && f.Year == 1994)))
                .Returns(RepositoryResult.Successful);

            var filmService = new FilmService(filmRepository.Object);

            var result = filmService.AddFilm("Shawshank Redemption", 1994);

            Assert.That(result, Is.EqualTo(RepositoryResult.Successful));
        }

        [Test]
        public void GivenSomeFilmsWhenGetAllFilmsIsCalledThenAllTheFilmsShouldBeReturned()
        {
            var filmRepository = new Mock<IFilmRepository>();
            var films = new []{ new FilmEntity {Title = "Shawshank Redemption", Year = 1994} };
            filmRepository
                .Setup(r => r.GetAll())
                .Returns(new GetFilmsResult { Result = RepositoryResult.Successful, Value =  films});

            var filmService = new FilmService(filmRepository.Object);

            var shawshank = filmService.GetWishlist().First(f => f.Title == "Shawshank Redemption");
            Assert.That(shawshank.Title, Is.EqualTo("Shawshank Redemption"));
            Assert.That(shawshank.Year, Is.EqualTo(1994));
        }

        [Test]
        public void GivenFilmServiceWhenGetAllFilmsFailsToGetFilmsThenNoFilmsShouldBeReturned()
        {
            var filmRepository = new Mock<IFilmRepository>();
            filmRepository
                .Setup(r => r.GetAll())
                .Returns(new GetFilmsResult { Result = RepositoryResult.Failed});

            var filmService = new FilmService(filmRepository.Object);

            var result = filmService.GetWishlist();
            Assert.That(result.Count(), Is.EqualTo(0));
        }
    }
}