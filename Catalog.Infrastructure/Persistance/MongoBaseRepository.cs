using Catalog.Domain.Contracts.Persistance;
using Catalog.Infrastructure.Attributes;
using Catalog.Infrastructure.Settings;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Catalog.Infrastructure.Persistance
{
    public class MongoBaseRepository<TMongoDocument> : IAsyncBaseRepository<TMongoDocument> where TMongoDocument : IEntityDocument
    {
        private readonly IMongoCollection<TMongoDocument> _collection;

        public MongoBaseRepository(MongoSettings mongoSettings)
        {
            MongoClient mongoClient = new MongoClient(mongoSettings.ConnectionString);
            IMongoDatabase database = mongoClient.GetDatabase(mongoSettings.DatabaseName);
            _collection = database.GetCollection<TMongoDocument>(GetCollectionName(typeof(TMongoDocument)));
        }

        private string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(typeof(BsonCollectionAttribute), inherit: true).First()).CollectionName;
        }

        public async Task<IList<TMongoDocument>> ListAllAsync()
        {
            return await _collection.Find(document => true).ToListAsync();
        }

        public async Task<TMongoDocument> GetByIdAsync(string id)
        {
            return await _collection.Find(document => document.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<IList<TMongoDocument>> FilterByAsync(Expression<Func<TMongoDocument, bool>> filterExpression)
        {
            return await _collection.Find(filterExpression).ToListAsync();
        }

        public async Task CreateAsync(TMongoDocument document)
        {
            await _collection.InsertOneAsync(document);
        }

        public async Task<bool> UpdateAsync(TMongoDocument document)
        {
            ReplaceOneResult updateResult = await _collection.ReplaceOneAsync(filter: document => document.Id.Equals(document.Id), replacement: document);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            DeleteResult deleteResult = await _collection.DeleteOneAsync(filter: document => document.Id.Equals(id));

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}
