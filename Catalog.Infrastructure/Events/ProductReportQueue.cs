using Catalog.Domain.Contracts.Event;
using Catalog.Domain.Modules.Products.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Events
{
    public class ProductReportQueue : IEventHandler<ProductCreatedEvent>
    {
        public async Task Handle(ProductCreatedEvent @event)
        {
            //Envia informação de que um produto foi criado a fila de relatório
        }
    }
}
