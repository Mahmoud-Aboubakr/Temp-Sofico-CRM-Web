using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SofiForce.Sync.Dapper
{
    public class DapperTempContext
    {
        private readonly IConfiguration _configuration;
        public DapperTempContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_configuration["SqlConnectionTemp"]);
    }
}
