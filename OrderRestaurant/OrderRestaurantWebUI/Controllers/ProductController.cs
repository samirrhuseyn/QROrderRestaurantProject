using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OrderRestaurantWebUI.Dtos.CategoryDtos;
using OrderRestaurantWebUI.Dtos.ProductDtos;
using System.Text;
using X.PagedList.Extensions;

namespace OrderRestaurantWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44382/api/Product/ProductListWithCategory\r\n");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategory>>(jsonData);
                return View(values.ToPagedList(page, 5));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44382/api/Category");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> dropvalue = (from x in values
                                              select new SelectListItem
                                              {
                                                  Text = x.CategoryName,
                                                  Value = x.CategoryID.ToString()
                                              }).ToList();
            ViewBag.dropvalue = dropvalue;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductWithImageDto createProductWithImageDto)
        {
            string imagePath = await UploadImage(createProductWithImageDto.ImageURL);
            CreateProductDto createProductDto = new CreateProductDto()
            {
                CategoryId = createProductWithImageDto.CategoryId,
                ImageURL = imagePath,
                IsActive = true,
                ProductDescription = createProductWithImageDto.ProductDescription,
                ProductName = createProductWithImageDto.ProductName,
                ProductPrice = createProductWithImageDto.ProductPrice
            };
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44382/api/Product", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44382/api/Product/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44382/api/Category");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> dropvalue = (from x in values
                                              select new SelectListItem
                                              {
                                                  Text = x.CategoryName,
                                                  Value = x.CategoryID.ToString()
                                              }).ToList();
            ViewBag.dropvalue = dropvalue;
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync($"https://localhost:44382/api/Product/{id}");

            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData1);
                var model = new UpdateProductWithImageDto
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    ProductPrice = product.ProductPrice,
                    ExistingImageUrl = product.ImageURL,
                    IsActive = product.IsActive,
                    CategoryId = product.CategoryId
                };
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductWithImageDto dto)
        {
            string imagePath = dto.ExistingImageUrl;

            if (dto.ImageURL != null)
            {
                imagePath = await UploadImage(dto.ImageURL);
            }

            UpdateProductDto updateDto = new()
            {
                ProductId = dto.ProductId,
                ProductName = dto.ProductName,
                ProductDescription = dto.ProductDescription,
                ProductPrice = dto.ProductPrice,
                ImageURL = imagePath,
                CategoryId = dto.CategoryId,
                IsActive = dto.IsActive
            };

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(updateDto);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:44382/api/Product/", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetails(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44382/api/Product/GetProductWithCategory?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<ResultProductWithCategory>(jsonData);

                return View(values);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeIsPassive(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.PutAsync($"https://localhost:44382/api/Product/Passive{id}", null);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeIsActive(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.PutAsync($"https://localhost:44382/api/Product/Active{id}", null);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        private async Task<string> UploadImage(IFormFile image)
        {
            if (image == null || image.Length == 0)
                return null;

            string uploadsFolder = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                "images");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string fileName = Guid.NewGuid().ToString() +
                              Path.GetExtension(image.FileName);

            string filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            return "/images/" + fileName;
        }
    }
}
