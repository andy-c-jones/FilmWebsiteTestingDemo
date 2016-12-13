using System.Collections.Generic;
using FilmWishlist.Models;
using FilmWishlist.Repositories;
using NUnit.Framework;
using PactNet;
using PactNet.Mocks.MockHttpService;
using PactNet.Mocks.MockHttpService.Models;

namespace ContractTests
{
    [TestFixture]
    public class FilmDescriptionRepositoryTests
    {
        private const string _inceptionPlot = "Dom Cobb is a skilled thief, the absolute best in the dangerous art of extraction, stealing valuable secrets from deep within the subconscious during the dream state, when the mind is at its most vulnerable. Cobb's rare ability has made him a coveted player in this treacherous new world of corporate espionage, but it has also made him an international fugitive and cost him everything he has ever loved. Now Cobb is being offered a chance at redemption. One last job could give him his life back but only if he can accomplish the impossible - inception. Instead of the perfect heist, Cobb and his team of specialists have to pull off the reverse: their task is not to steal an idea but to plant one. If they succeed, it could be the perfect crime. But no amount of careful planning or expertise can prepare the team for the dangerous enemy that seems to predict their every move. An enemy that only Cobb could have seen coming.";
        private IMockProviderService _fakeOmdbService;

        [SetUp]
        public void SetUp()
        {
            _fakeOmdbService = new PactBuilder().MockService(5842);
            _fakeOmdbService.Start();
        }

        [TestCaseSource(typeof(OmdbApiUrlProvider))]
        public void GivenAFilmThatDoesExistWhenGettingTheDescriptionThenTheDescriptionIsReturned(string url)
        {
            _fakeOmdbService.Given("The film Inception") .UponReceiving("A request for it")
                .With(OmdbRequest("inception", "2010")).WillRespondWith(OmdbResponse(_inceptionPlot));

            var repository = new FilmDescriptionRepository(url);
            var result = repository.GetDescriptionResult("inception", "2010");

            Assert.That(result.Result, Is.EqualTo(RepositoryResult.Successful));
            Assert.That(result.Value, Is.EqualTo(_inceptionPlot));
        }

        [TestCaseSource(typeof(OmdbApiUrlProvider))]
        public void GivenAFilmThatDoesNotExistWhenGettingTheDescriptionThenAFailedResponseIsReturned(string url)
        {
            _fakeOmdbService.Given("A film that does not exist") .UponReceiving("A request for it")
                .With(OmdbRequest("NotAFilm", "1923")).WillRespondWith(OmdbErrorResponse);

            var repository = new FilmDescriptionRepository(url);
            var result = repository.GetDescriptionResult("NotAFilm", "1923");

            Assert.That(result.Result, Is.EqualTo(RepositoryResult.Failed));
        }

        [TearDown]
        public void TearDown()
        {
            _fakeOmdbService.Stop();
        }

        private static ProviderServiceRequest OmdbRequest(string title, string year) => new ProviderServiceRequest
        {
            Method = HttpVerb.Get,
            Path = "/",
            Query = $"t={title}&y={year}&plot=full&r=json"
        };

        private static ProviderServiceResponse OmdbResponse(string plot) => new ProviderServiceResponse
        {
            Status = 200,
            Headers = new Dictionary<string, string> {{ "Content-Type", "application/json; charset=utf-8" }},
            Body = new { Plot = plot }
        };

        private static ProviderServiceResponse OmdbErrorResponse => new ProviderServiceResponse
        {
            Status = 200,
            Headers = new Dictionary<string, string>{{ "Content-Type", "application/json; charset=utf-8" }},
            Body = new{ Error = "Movie not found!" }
        };
    }
}