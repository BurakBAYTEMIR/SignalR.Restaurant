using Microsoft.AspNetCore.Mvc;
using SignalR.Restaurant.Business.Abstract;

namespace SignalR.Restaurant.SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly ISliderService _sliderService;

        public SlidersController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            return Ok(_sliderService.TGetListAll());
        }
    }
}
