using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Extentions;
using ShopOnline.Api.Reposotories.Contracts;
using ShopOnline.Models.Dtos;
namespace ShopOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository productRepository) {
            this.productRepository = productRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
        {
            try
            {
                var products = await this.productRepository.GetItems();
                var productCategory = await this.productRepository.GetCategories();
                if (products == null || productCategory == null)
                {
                    return NotFound();
                }
                else
                {
                    var productDtos = products.convertToDto(productCategory);
                    return Ok(productDtos);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError," Error Retrieving Data from database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetItem(int id)
        {
            try
            {
                var product = await this.productRepository.GetItem(id);
                
                if (product == null)
                {
                    return BadRequest();
                }
                else
                {
                    var ProductCategory=await this.productRepository.GetCategory(product.Id);
                    return Ok(product.convertToDto(ProductCategory));
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, " Error Retrieving Data from database");
            }
        }
    }
}
