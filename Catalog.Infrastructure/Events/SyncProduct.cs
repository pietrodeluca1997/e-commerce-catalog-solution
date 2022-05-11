using Catalog.Domain.Contracts.Event;
using Catalog.Domain.Modules.Products.Events;

namespace Catalog.Infrastructure.Events
{
    public class SyncProduct : IEventHandler<ProductCreatedEvent>
    {
        public async Task Handle(ProductCreatedEvent @event)
        {
            //Guardar a informação do produto no MongoDB
        }
    }
}
