using System.Linq;
using FilmWishlist.Models;
using IntegrationTestingAndMockingWorkshop;
using NUnit.Framework;

namespace IntegrationTests
{
    [TestFixture]
    public class FilmRepositoryGetAllTests
    {
        private FilmRepository _repository;

        [SetUp]
        public void GivenAFilmRepository()
        {
            SqlHelper.TruncateFilmsTable();

            _repository = new FilmRepository("Data Source=.;Initial Catalog=Films;Integrated Security=True");
        }

        [Test]
        public void WhenFilmsArePresentThenTheyShouldBeInTheResultingList()
        {
            SqlHelper.AddFilm("Allied", 2016);
            SqlHelper.AddFilm("Spirited Away", 2001);
            SqlHelper.AddFilm("Back to the Future", 1985);
            var result = _repository.GetAll();

            Assert.That(result.Result, Is.EqualTo(RepositoryResult.Successful));

            Assert.That(result.Value.First(f => f.Title == "Allied").Year, Is.EqualTo(2016));
            Assert.That(result.Value.First(f => f.Title == "Spirited Away").Year, Is.EqualTo(2001));
            Assert.That(result.Value.First(f => f.Title == "Back to the Future").Year, Is.EqualTo(1985));
        }
    }

    [TestFixture]
    public class FilmRepositoryGetAllFailsTests
    {
        private FilmRepository _repository;

        [SetUp]
        public void GivenAFilmRepository()
        {
            SqlHelper.TruncateFilmsTable();

            _repository = new FilmRepository("notarealconnectionstring");
        }

        [Test]
        public void WhenFilmsArePresentThenTheyShouldBeInTheResultingList()
        {
            Assert.That(_repository.GetAll().Result, Is.EqualTo(RepositoryResult.Failed));
        }
    }
}