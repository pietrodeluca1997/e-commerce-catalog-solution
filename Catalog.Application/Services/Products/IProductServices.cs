using Catalog.Application.DTOs.Base;
using Catalog.Application.DTOs.Products;

namespace Catalog.Application.Contracts.Services
{
    public interface IProductServices
    {
        Task<BaseResponseDTO> CreateProduct(CreateProductDTO createProductDTO);
    }
}
