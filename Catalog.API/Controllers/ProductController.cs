using Catalog.Application.Contracts.Services;
using Catalog.Application.DTOs.Base;
using Catalog.Application.DTOs.Products;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpPost]
        public async Task<ObjectResult> Create([FromBody] CreateProductDTO createProductDTO)
        {
            BaseResponseDTO responseDTO = await _productServices.CreateProduct(createProductDTO);

            return StatusCode((int)responseDTO.StatusCode, responseDTO);
        }
    }
}
