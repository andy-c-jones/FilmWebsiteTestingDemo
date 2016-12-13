using FilmWishlist.Models;
using FilmWishlist.Repositories;
using FilmWishlist.Service;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class FilmDescriptionServiceTests
    {
        [Test]
        public void GivenADescriptionServiceWhenThereIsADescriptionInTheRepoThenTheDescriptionIsReturned()
        {
            var repository = new Mock<IFilmDescriptionRepository>();
            repository
                .Setup(r => r.GetDescriptionResult("Title", "2012"))
                .Returns(new GetDescriptionRepositoryResult {Result = RepositoryResult.Successful, Value = "Description"});

            var service = new FilmDescriptionService(repository.Object);

            Assert.That(service.Get("Title", "2012"), Is.EqualTo("Description"));
        }

        [Test]
        public void GivenADescriptionServiceWhenThereIsNoDescriptionInTheRepoThenAMessageIndicatingNoDescriptionIsReturned()
        {
            var repository = new Mock<IFilmDescriptionRepository>();
            repository
                .Setup(r => r.GetDescriptionResult("Title", "2012"))
                .Returns(new GetDescriptionRepositoryResult {Result = RepositoryResult.Failed});

            var service = new FilmDescriptionService(repository.Object);

            Assert.That(service.Get("Title", "2012"), Is.EqualTo("No description found."));
        }
    }
}