using Catalog.Application.Contracts.Services;
using Catalog.Application.DTOs.Base;
using Catalog.Application.DTOs.Products;
using Catalog.Domain.Contracts.Mediator;
using Catalog.Domain.Modules.Products.Commands.CreateNewProduct;

namespace Catalog.Application.Services.Products
{
    public class ProductServices : IProductServices
    {
        private readonly ICommandMediator _commandMediator;
        public ProductServices(ICommandMediator commandMediator) => _commandMediator = commandMediator;
        public async Task<BaseResponseDTO> CreateProduct(CreateProductDTO createProductDTO)
        {
            CreateNewProductCommand command = new CreateNewProductCommand
            {
                Name = createProductDTO.Name,
                Description = createProductDTO.Description,
                Summary = createProductDTO.Summary,
                ImageFile = createProductDTO.ImageFile,
                Price = createProductDTO.Price
            };

            CreateNewProductCommandResponse commandResponse = await _commandMediator.Send<CreateNewProductCommand, CreateNewProductCommandResponse>(command);

            return new SucessResponseDTO();
        }
    }
}
