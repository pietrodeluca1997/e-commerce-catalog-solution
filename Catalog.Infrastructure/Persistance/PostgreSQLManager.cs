using Catalog.Infrastructure.Contracts;
using Catalog.Infrastructure.Settings;
using Npgsql;
using System.Data.SqlClient;

namespace Catalog.Infrastructure.Persistance
{
    public class PostgreSQLManager : IPostgreSQLManager
    {
        private readonly PostgreSQLSettings _postgreSQLSettings;

        public PostgreSQLManager(PostgreSQLSettings postgreSQLSettings)
        {
            _postgreSQLSettings = postgreSQLSettings;
        }

        public async Task<NpgsqlConnection> OpenConnection()
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection(_postgreSQLSettings.ConnectionString);

            await sqlConnection.OpenAsync();

            return sqlConnection;
        }

        public async Task CloseConnection(NpgsqlConnection sqlConnection)
        {
            await sqlConnection.CloseAsync();
        }
    }
}
