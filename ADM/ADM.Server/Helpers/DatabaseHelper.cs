using Npgsql;
using System.Data.Common;

namespace ADM.Server.Helpers
{
    public class DatabaseHelper
    {
        private readonly IConfiguration _configuration;
        public NpgsqlConnection _dbConnection;

        public DatabaseHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            _dbConnection = new NpgsqlConnection(connectionString);
        }

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }
    }
}
