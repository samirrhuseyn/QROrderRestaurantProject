using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OrderRestaurantWebUI.Dtos.DiscountDto;
using System.Text;
using X.PagedList.Extensions;

namespace OrderRestaurantWebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DiscountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44382/api/Discount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDiscountDto>>(jsonData);
                return View(values.ToPagedList(page, 4));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateDiscount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountWithImageDto createDiscountWithImageDto)
        {
            string imagePath = await UploadImage(createDiscountWithImageDto.ImageURL);
            CreateDiscountDto createDiscountDto = new CreateDiscountDto()
            {
                DiscountDescription = createDiscountWithImageDto.DiscountDescription,
                DiscountTitle = createDiscountWithImageDto.DiscountTitle,
                ImageURL = imagePath,
                Amount = createDiscountWithImageDto.Amount
            };
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createDiscountDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44382/api/Discount", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteDiscount(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44382/api/Discount/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDiscount(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44382/api/Discount/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage.Content.ReadAsStringAsync();
                var discount = JsonConvert.DeserializeObject<UpdateDiscountDto>(jsonData1);
                var model = new UpdateDiscountWithImageDto
                {
                    DiscountId = discount.DiscountId,
                    DiscountTitle = discount.DiscountTitle,
                    DiscountDescription = discount.DiscountDescription,
                    ExistingImageUrl = discount.ImageURL,
                    Amount = discount.Amount
                };
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscountWithImageDto dto)
        {
            string imagePath = dto.ExistingImageUrl;

            if (dto.ImageURL != null)
            {
                imagePath = await UploadImage(dto.ImageURL);
            }

            UpdateDiscountDto updateDto = new()
            {
                DiscountId = dto.DiscountId,
                DiscountTitle = dto.DiscountTitle,
                DiscountDescription = dto.DiscountDescription,
                Amount = dto.Amount,
                ImageURL = imagePath
            };

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(updateDto);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:44382/api/Discount/", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(dto);
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
