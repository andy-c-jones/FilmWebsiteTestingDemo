using System;
using System.Data.SqlClient;
using Dapper;
using FilmWishlist.Models;

namespace FilmWishlist.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly string _connectionString;

        public FilmRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public RepositoryResult Add(Film film)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    const string cmdText = "INSERT INTO Films (Title, Year) VALUES (@Title, @Year)";
                    sqlConnection.Execute(cmdText, film);
                    return RepositoryResult.Successful;
                }
            }
            catch (Exception)
            {
                return RepositoryResult.Failed;
            }
        }

        public GetFilmsResult GetAll()
        {
            try
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    var films = sqlConnection.Query<FilmEntity>("SELECT [Title],[Year] FROM [dbo].[Films]");
                    return GetFilmsResult.Success(films);
                }
            }
            catch (Exception)
            {
                return GetFilmsResult.Unsuccessful();
            }
        }
    }
}
