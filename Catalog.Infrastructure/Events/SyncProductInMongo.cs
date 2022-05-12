using Catalog.Domain.Contracts.Event;
using Catalog.Domain.Contracts.Persistance;
using Catalog.Domain.Documents;
using Catalog.Domain.Entities;
using Catalog.Domain.Modules.Products.Events;
using Catalog.Infrastructure.Persistance;
using Catalog.Infrastructure.Settings;

namespace Catalog.Infrastructure.Events
{
    public class SyncProductInMongo : IEventHandler<ProductCreatedEvent>
    {
        private readonly IAsyncBaseRepository<ProductDocument> _productRepository;
         
        public SyncProductInMongo(IAsyncBaseRepository<ProductDocument> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(ProductCreatedEvent @event)
        {
            //Guardar a informação do produto no MongoDB
            ProductDocument productDocument = new ProductDocument(@event.Product);

            await _productRepository.CreateAsync(productDocument);
        }
    }
}
