using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Extensions;
using ShopOnline.Api.Repositories;
using ShopOnline.Api.Repositories.Contract;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
        {
            try
            {
                var products = await _productRepository.GetItems();
                var productCategories = await _productRepository.GetCategories();

                if (!products.Any() && !productCategories.Any())
                {
                    return NotFound();
                }

                var productDtos = products.ConvertToDto(productCategories);

                return Ok(productDtos);
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
