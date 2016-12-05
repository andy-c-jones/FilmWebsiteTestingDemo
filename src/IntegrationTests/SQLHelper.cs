using System;
using System.Data.SqlClient;

namespace IntegrationTests
{
    public class SqlHelper
    {
        private const string ConnectionString = "Data Source=.;Initial Catalog=Films;Integrated Security=True";

        public static void TruncateFilmsTable()
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                string cmdText = "TRUNCATE TABLE Films";
                var cmd = new SqlCommand(cmdText, sqlConnection);
                cmd.ExecuteNonQuery();
            }
        }

        public static string GetFirstRowsFilmName()
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                const string CmdText = "SELECT TOP 1 * FROM Films";
                var cmd = new SqlCommand(CmdText, sqlConnection);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetString(0);
                    }
                    throw new Exception("No data present");
                }
            }
        }

        public static int GetFirstRowsFilmYear()
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                const string CmdText = "SELECT TOP 1 * FROM Films";
                var cmd = new SqlCommand(CmdText, sqlConnection);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetInt32(1);
                    }
                    throw new Exception("No data present");
                }
            }
        }
    }
}