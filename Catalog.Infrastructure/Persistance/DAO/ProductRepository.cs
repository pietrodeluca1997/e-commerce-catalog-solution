using Catalog.Domain.Contracts.Persistance;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Contracts;
using System.Data;
using System.Data.SqlClient;

namespace Catalog.Infrastructure.Persistance.DAO
{
    public class ProductDAO : IProductDAO
    {
        private ISqlServerManager _sqlServerManager;
        public ProductDAO(ISqlServerManager sqlServerManager)
        {
            _sqlServerManager = sqlServerManager;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            SqlConnection sqlConnection = await _sqlServerManager.OpenConnection();

            string query = "INSERT INTO Products(name, summary, description, image_file, price) VALUES (@name, @summary, @description, @imageFile, @price)";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = product.Name;
            command.Parameters.Add("@summary", SqlDbType.VarChar).Value = product.Summary;
            command.Parameters.Add("@description", SqlDbType.VarChar).Value = product.Description;
            command.Parameters.Add("@imageFile", SqlDbType.VarChar).Value = product.ImageFile;
            command.Parameters.Add("@price", SqlDbType.Decimal).Value = product.Price;

            product.Id = (uint)await command.ExecuteNonQueryAsync();

            await _sqlServerManager.CloseConnection(sqlConnection);

            return product;
        }

        public Task DeleteAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
