using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using OrderRestaurantWebUI.Dtos.AboutDto;
using OrderRestaurantWebUI.Dtos.ProductDtos;
using System.Text;

namespace OrderRestaurantWebUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44382/api/About/GetLastAbout");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultAboutDto>(jsonData);
                if (values == null)
                {
                    return RedirectToAction("CreateAbout");
                }
                else
                {
                    return View(values);
                }

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutWithImage createAboutWithImage)
        {
            string imagePath = await UploadImage(createAboutWithImage.ImageURL);
            CreateAboutDto createAboutDto = new CreateAboutDto()
            {
                ImageURL = imagePath,
                Title = createAboutWithImage.Title,
                Description = createAboutWithImage.Description
            };
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createAboutDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44382/api/About", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44382/api/About/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var about = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
                var model = new UpdateAboutWithImageDto
                {
                    AboutID = about.AboutID,
                    Title = about.Title,
                    Description=about.Description,
                    ExistingImageUrl = about.ImageURL
                };
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutWithImageDto dto)
        {
            string imagePath = dto.ExistingImageUrl;

            if (dto.ImageURL != null)
            {
                imagePath = await UploadImage(dto.ImageURL);
            }

            UpdateAboutDto updateDto = new()
            {
                AboutID = dto.AboutID,
                Title = dto.Title,
                Description = dto.Description,
                ImageURL = imagePath,
            };

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(updateDto);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:44382/api/About/", content);

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
