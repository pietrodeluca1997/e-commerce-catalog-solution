namespace Catalog.Application.DTOs.Products
{
    public class CreateProductDTO
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }

        public CreateProductDTO(string name, string summary, string description, string imageFile, decimal price)
        {
            Name = name;
            Summary = summary;
            Description = description;
            ImageFile = imageFile;
            Price = price;
        }
    }
}
