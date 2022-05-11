using Catalog.Domain.Contracts.Commands;

namespace Catalog.Domain.Modules.Products.Commands.CreateNewProduct
{
    public class CreateNewProductCommand : ICommand
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
    }
}
