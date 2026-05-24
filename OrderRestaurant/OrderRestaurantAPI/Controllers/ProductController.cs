using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderRestaueant.EntityLayer.Entities;
using OrderRestaurant.BusinessLayer.Abstract;
using OrderRestaurant.DtoLayer.ProductDto;

namespace OrderRestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _productService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            Product product = new Product()
            {
                ProductName = createProductDto.ProductName,
                IsActive = true,
                ProductDescription = createProductDto.ProductDescription,
                ProductPrice = createProductDto.ProductPrice,
                ImageURL = createProductDto.ImageURL
            };
            _productService.TAdd(product);
            return Ok("Created successfully!");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Deleted successfully!");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            Product product = new Product()
            {
                ProductId = updateProductDto.ProductId,
                ProductName = updateProductDto.ProductName,
                ProductDescription = updateProductDto.ProductDescription,
                ProductPrice = updateProductDto.ProductPrice,
                IsActive = true,
                ImageURL = updateProductDto.ImageURL
            };
            _productService.TUpdate(product);
            return Ok("Updated successfully!");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(value);
        }
    }
}
