using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.Restaurant.Business.Abstract;
using SignalR.Restaurant.Dtos.ContactDto;
using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListContact()
        {
            var values = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            _contactService.TAdd(new Contact()
            {
                ContactMail = createContactDto.ContactMail,
                ContactLocation = createContactDto.ContactLocation,
                ContactPhone = createContactDto.ContactPhone,
                ContactFooterDescription = createContactDto.ContactFooterDescription
            });
            return Ok("Contact Kısmı Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok("Contact Alanı Silindi");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            _contactService.TUpdate(new Contact()
            {
                ContactID = updateContactDto.ContactID,
                ContactMail = updateContactDto.ContactMail,
                ContactLocation = updateContactDto.ContactLocation,
                ContactPhone = updateContactDto.ContactPhone,
                ContactFooterDescription = updateContactDto.ContactFooterDescription
            });
            return Ok("Contact Alanı güncellendi");
        }

        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var values = _contactService.TGetById(id);
            return Ok(values);
        }
    }
}
