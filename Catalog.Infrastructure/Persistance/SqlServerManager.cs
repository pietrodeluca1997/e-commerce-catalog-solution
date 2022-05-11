using Catalog.Infrastructure.Contracts;
using Catalog.Infrastructure.Settings;
using System.Data.SqlClient;

namespace Catalog.Infrastructure.Persistance
{
    public class SqlServerManager : ISqlServerManager
    {
        private readonly SqlServerSettings _sqlServerSettings;

        public SqlServerManager(SqlServerSettings sqlServerSettings)
        {
            _sqlServerSettings = sqlServerSettings;
        }

        public async Task<SqlConnection> OpenConnection()
        {
            SqlConnection sqlConnection = new SqlConnection(_sqlServerSettings.ConnectionString);
            await sqlConnection.OpenAsync();

            return sqlConnection;
        }

        public async Task CloseConnection(SqlConnection sqlConnection)
        {
            await sqlConnection.CloseAsync();
        }
    }
}
