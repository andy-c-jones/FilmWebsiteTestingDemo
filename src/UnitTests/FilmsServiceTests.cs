using FilmWishlist.Models;
using FilmWishlist.Service;
using IntegrationTestingAndMockingWorkshop;
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
    }
}