using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.Restaurant.Business.Abstract;
using SignalR.Restaurant.Dtos.TestimonialDtos;
using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialService.TAdd(new Testimonial()
            {
                TestimonialComment = createTestimonialDto.TestimonialComment,
                TestimonialImageUrl = createTestimonialDto.TestimonialImageUrl,
                TestimonialName = createTestimonialDto.TestimonialName,
                TestimonialStatus = createTestimonialDto.TestimonialStatus,
                TestimonialTitle = createTestimonialDto.TestimonialTitle
            });
            return Ok("Testimonial Kısmı Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok("Testimonial Alanı Silindi");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialService.TUpdate(new Testimonial()
            {
                TestimonialID = updateTestimonialDto.TestimonialID,
                TestimonialComment = updateTestimonialDto.TestimonialComment,
                TestimonialImageUrl = updateTestimonialDto.TestimonialImageUrl,
                TestimonialName = updateTestimonialDto.TestimonialName,
                TestimonialStatus = updateTestimonialDto.TestimonialStatus,
                TestimonialTitle = updateTestimonialDto.TestimonialTitle
            });
            return Ok("Testimonial Alanı güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var values = _testimonialService.TGetById(id);
            return Ok(values);
        }
    }
}
