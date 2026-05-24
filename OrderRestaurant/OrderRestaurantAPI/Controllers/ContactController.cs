using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderRestaurant.BusinessLayer.Abstract;
using OrderRestaurant.DtoLayer.ContactDto;
using OrderRestaurant.EntityLayer.Entities;

namespace OrderRestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _contactService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            Contact contact = new Contact()
            {
                Email = createContactDto.Email,
                PhoneNumber = createContactDto.PhoneNumber,
                FooterDescription = createContactDto.FooterDescription,
                Location = createContactDto.Location
            };
            _contactService.TAdd(contact);
            return Ok("Created successfully!");
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok("Deleted successfully!");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            Contact contact = new Contact()
            {
                ContactId = updateContactDto.ContactId,
                Email = updateContactDto.Email,
                PhoneNumber = updateContactDto.PhoneNumber,
                FooterDescription = updateContactDto.FooterDescription,
                Location = updateContactDto.Location
            };
            _contactService.TUpdate(contact);
            return Ok("Updated successfully!");
        }

        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(value);
        }
    }
}
