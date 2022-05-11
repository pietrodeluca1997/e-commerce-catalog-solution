using Catalog.Domain.Contracts.Commands;
using Catalog.Domain.Contracts.Event;
using Catalog.Domain.Contracts.Mediator;
using Catalog.Domain.Contracts.Persistance;
using Catalog.Domain.Entities;
using Catalog.Domain.Modules.Products.Events;

namespace Catalog.Domain.Modules.Products.Commands.CreateNewProduct
{
    public class CreateNewProductHandler : ICommandHandler<CreateNewProductCommand, CreateNewProductCommandResponse>
    {
        private readonly IEventMediator _eventMediator;
        private readonly IProductDAO _productDAO;

        public CreateNewProductHandler(IEventMediator eventMediator, IProductDAO productDAO)
        {
            _eventMediator = eventMediator;
            _productDAO = productDAO;            
        }
        public async Task<CreateNewProductCommandResponse> Handle(CreateNewProductCommand command)
        {
            Product product = new Product(command.Name, command.Summary, command.Description, command.ImageFile, command.Price);

            await _productDAO.CreateAsync(product);

            ProductCreatedEvent productCreatedEvent = new ProductCreatedEvent(product, DateTime.Now);

            await _eventMediator.Publish<ProductCreatedEvent>(productCreatedEvent);

            return new CreateNewProductCommandResponse();
        }
    }
}
