using System.Data.SqlClient;

namespace Catalog.Infrastructure.Contracts
{
    public interface ISqlServerManager
    {
        Task<SqlConnection> OpenConnection();
        Task CloseConnection(SqlConnection sqlConnection);
    }
}
