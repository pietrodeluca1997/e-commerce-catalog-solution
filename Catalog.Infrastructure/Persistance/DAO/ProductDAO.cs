using Catalog.Domain.Contracts.Persistance;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Contracts;
using Npgsql;
using System.Data;
using System.Data.SqlClient;

namespace Catalog.Infrastructure.Persistance.DAO
{
    public class ProductDAO : IProductDAO
    {
        private IPostgreSQLManager _postgreSQLManager;
        public ProductDAO(IPostgreSQLManager postgreSQLManager)
        {
            _postgreSQLManager = postgreSQLManager;
        }
        public async Task<bool> CreateAsync(Product product)
        {  
            using NpgsqlConnection sqlConnection = await _postgreSQLManager.OpenConnection();

            string query = "INSERT INTO Products(name, summary, description, image_file, price) VALUES (@name, @summary, @description, @image_file, @price) RETURNING product_id";

            using NpgsqlCommand command = new NpgsqlCommand(query, sqlConnection);

            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@summary", product.Summary);
            command.Parameters.AddWithValue("@description", product.Description);
            command.Parameters.AddWithValue("@image_file", product.ImageFile);
            command.Parameters.AddWithValue("@price", product.Price);

            int? productId =  (int?) await command.ExecuteScalarAsync();

            if(productId is not null)
            {
                product.Id = (int) productId;
            }

            return product.Id > 0;
        }

        public async Task<bool> DeleteAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetByIdAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
