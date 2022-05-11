using Catalog.Domain.Contracts.Event;
using Catalog.Domain.Entities;

namespace Catalog.Domain.Modules.Products.Events
{
    public class ProductCreatedEvent : IEvent
    {
        public Product Product { get; set; }
        public DateTime CreatedAt { get; set; }
        public ProductCreatedEvent(Product product, DateTime createdAt)
        {
            Product = product;
            CreatedAt = createdAt;
        }
    }
}
