using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderRestaueant.EntityLayer.Entities;
using OrderRestaurant.BusinessLayer.Abstract;
using OrderRestaurant.DataAccessLayer.Concrete;
using OrderRestaurant.DtoLayer.ProductDto;

namespace OrderRestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var context = new OrderRestaurantContext();
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory
            {
                ProductId = y.ProductId,
                ProductName = y.ProductName,
                ImageURL = y.ImageURL,
                IsActive = y.IsActive,
                CategoryName = y.Category.CategoryName,
                ProductDescription = y.ProductDescription,
                ProductPrice = y.ProductPrice
            });
            return Ok(values.ToList());
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

        [HttpDelete("{id}")]
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

        [HttpPut("Passive{id}")]
        public IActionResult ChangeIsPassive(int id)
        {
            var value = _productService.TGetById(id);
            value.IsActive = false;
            _productService.TUpdate(value);
            return Ok("The situation has changed: Passive!");
        }

        [HttpPut("Active{id}")]
        public IActionResult ChangeIsActive(int id)
        {
            var value = _productService.TGetById(id);
            value.IsActive = true;
            _productService.TUpdate(value);
            return Ok("The situation has changed: Active!");
        }
    }
}
