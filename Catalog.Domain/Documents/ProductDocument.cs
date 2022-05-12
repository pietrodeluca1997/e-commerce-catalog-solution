using Catalog.Domain.Attributes;
using Catalog.Domain.Contracts.Persistance;
using Catalog.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Domain.Documents
{
    [BsonCollection("Products")]
    public class ProductDocument : IEntityDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BsonId { get; set; }
        public Guid ProductId  { get; set; }
        public int RelationalId { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }

        public ProductDocument(Product product)
        {
            Name = product.Name;
            Summary = product.Summary;
            Description = product.Description;
            ImageFile = product.ImageFile;
            Price = product.Price;
            ProductId = Guid.NewGuid();
            RelationalId = product.Id;
        }
    }
}
