using System;
using System.Net;
using FilmWishlist.Models;
using RestSharp;

namespace FilmWishlist.Repositories
{
    public class FilmDescriptionRepository : IFilmDescriptionRepository
    {
        private readonly string _url;

        public FilmDescriptionRepository(string url)
        {
            _url = url;
        }

        public GetDescriptionRepositoryResult GetDescriptionResult(string title, string year) => GetDescriptionRepositoryResult(Response(title, year));

        private static IRestRequest Request(string title, string year) => new RestRequest(Method.GET)
            .AddQueryParameter("t", title)
            .AddQueryParameter("y", year)
            .AddQueryParameter("plot", "full")
            .AddQueryParameter("r", "json");

        private static GetDescriptionRepositoryResult GetDescriptionRepositoryResult(IRestResponse<OmdbApiFilmResponse> response) =>
            response.Data.Plot == null
                ? FailedResult()
                : SuccessResult(response.Data.Plot);

        private RestClient Client() => new RestClient(_url);
        private IRestResponse<OmdbApiFilmResponse> Response(string title, string year) => Client().Execute<OmdbApiFilmResponse>(Request(title, year));
        private static GetDescriptionRepositoryResult SuccessResult(string plot) => new GetDescriptionRepositoryResult {Result = RepositoryResult.Successful, Value = plot};
        private static GetDescriptionRepositoryResult FailedResult() => new GetDescriptionRepositoryResult {Result = RepositoryResult.Failed};
    }
}