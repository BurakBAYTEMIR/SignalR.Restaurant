using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SignalR.Restaurant.Business.Abstract;
using SignalR.Restaurant.Dtos.BookingDtos;
using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateBookingDto> _validator;
        public BookingController(IBookingService bookingService, IMapper mapper, IValidator<CreateBookingDto> validator)
        {
            _bookingService = bookingService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult ListBooking()
        {
            var values = _mapper.Map<List<ResultBookingDto>>(_bookingService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            createBookingDto.BookingDescription = "Rezervasyon Alındı";
            var validationResult = _validator.Validate(createBookingDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var value = _mapper.Map<Booking>(createBookingDto);
            _bookingService.TAdd(value);
            return Ok("Booking Kısmı Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok("Booking Alanı Silindi");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            _bookingService.TUpdate(new Booking()
            {
                BookingID = updateBookingDto.BookingID,
                BookingDate = updateBookingDto.BookingDate,
                BookingDescription = updateBookingDto.BookingDescription,
                BookingMail = updateBookingDto.BookingMail,
                BookingName = updateBookingDto.BookingName,
                BookingPersonCount = updateBookingDto.BookingPersonCount,
                BookingPhone = updateBookingDto.BookingPhone
            });
            return Ok("Booking Alanı güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var values = _bookingService.TGetById(id);
            return Ok(values);
        }

        [HttpGet("BookingStatusCancelled/{id}")]
        public IActionResult BookingStatusCancelled(int id)
        {
            _bookingService.TBookingStatusCancelled(id);
            return Ok("Rezervayon Açıklaması Değiştirildi");
        }

        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            _bookingService.TBookingStatusApproved(id);
            return Ok("Rezervayon Açıklaması Değiştirildi");
        }
    }
}
