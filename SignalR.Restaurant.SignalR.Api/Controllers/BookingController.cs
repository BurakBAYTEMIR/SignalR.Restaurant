using AutoMapper;
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
        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
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
            _bookingService.TAdd(new Booking()
            {
                BookingDate = createBookingDto.BookingDate,
                BookingMail = createBookingDto.BookingMail,
                BookingName = createBookingDto.BookingName,
                BookingPersonCount = createBookingDto.BookingPersonCount,
                BookingPhone = createBookingDto.BookingPhone
            });
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
    }
}
