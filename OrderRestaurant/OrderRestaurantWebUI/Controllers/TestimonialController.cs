using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using OrderRestaurantWebUI.Dtos.ProductDtos;
using OrderRestaurantWebUI.Dtos.TestimonialDto;
using System.Text;
using X.PagedList.Extensions;

namespace OrderRestaurantWebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44382/api/Testimonial");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                return View(values.ToPagedList(page, 4));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialWithImageDto createTestimonial)
        {
            
            string imagePath = await UploadImage(createTestimonial.ImageURL);
            CreateTestimonialDto createTestimonialDto = new CreateTestimonialDto()
            {
                ImageURL = string.IsNullOrWhiteSpace(imagePath) ? "null" : imagePath,
                IsActive = true,
                Comment = createTestimonial.Comment,
                Name = createTestimonial.Name,
            };
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createTestimonialDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44382/api/Testimonial", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = " ";
                return RedirectToAction("CreateTestimonial");
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
