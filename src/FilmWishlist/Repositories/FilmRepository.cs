using System;
using System.Data;
using System.Data.SqlClient;
using FilmWishlist.Models;

namespace IntegrationTestingAndMockingWorkshop
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
                    var cmd = new SqlCommand(cmdText, sqlConnection);
                    cmd.Parameters.Add("Title", SqlDbType.NVarChar, -1).Value = film.Title;
                    cmd.Parameters.Add("Year", SqlDbType.Int).Value = film.Year;
                    cmd.ExecuteNonQuery();
                    return RepositoryResult.Successful;
                }
            }
            catch (Exception)
            {
                return RepositoryResult.Failed;
            }
        }
    }

    public interface IFilmRepository
    {
        RepositoryResult Add(Film film);
    }
}
