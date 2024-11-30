using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.Restaurant.Business.Abstract;
using SignalR.Restaurant.Dtos.DiscountDtos;
using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;
        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListDiscount()
        {
            var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            _discountService.TAdd(new Discount()
            {
                DiscountTitle = createDiscountDto.DiscountTitle,
                DiscountDescription = createDiscountDto.DiscountDescription,
                DiscountAmount = createDiscountDto.DiscountAmount,
                DiscountImageUrl = createDiscountDto.DiscountImageUrl
            });
            return Ok("Discount Kısmı Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            _discountService.TDelete(value);
            return Ok("Discount Alanı Silindi");
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            _discountService.TUpdate(new Discount()
            {
                DiscountID = updateDiscountDto.DiscountID,
                DiscountTitle = updateDiscountDto.DiscountTitle,
                DiscountDescription = updateDiscountDto.DiscountDescription,
                DiscountAmount = updateDiscountDto.DiscountAmount,
                DiscountImageUrl = updateDiscountDto.DiscountImageUrl
            });
            return Ok("Discount Alanı güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var values = _discountService.TGetById(id);
            return Ok(values);
        }
    }
}
