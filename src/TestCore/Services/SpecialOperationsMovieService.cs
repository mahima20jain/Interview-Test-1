using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace TestCore.Services
{
    public class SpecialOperationsMovieService : ISpecialOperationsMovieService
    {
        private readonly string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=MovieContext-bc;Trusted_Connection=True;";

        public async Task ResetRating(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE Movie SET Rating = '' WHERE ID = 1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task ResetGenre(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("ResetGenre", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}