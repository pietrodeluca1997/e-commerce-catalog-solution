using Npgsql;

namespace Catalog.Infrastructure.Contracts
{
    public interface IPostgreSQLManager
    {
        Task<NpgsqlConnection> OpenConnection();
        Task CloseConnection(NpgsqlConnection sqlConnection);
    }
}
