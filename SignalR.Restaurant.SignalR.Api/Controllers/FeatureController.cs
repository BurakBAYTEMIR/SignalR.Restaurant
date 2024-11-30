using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.Restaurant.Business.Abstract;
using SignalR.Restaurant.Dtos.FeatureDtos;
using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;
        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListFeature()
        {
            var values = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            _featureService.TAdd(new Feature()
            {
                FeatureTitle1 = createFeatureDto.FeatureTitle1,
                FeatureTitle2 = createFeatureDto.FeatureTitle2,
                FeatureTitle3 = createFeatureDto.FeatureTitle3,
                FeatureDescription1 = createFeatureDto.FeatureDescription1,
                FeatureDescription2 = createFeatureDto.FeatureDescription2,
                FeatureDescription3 = createFeatureDto.FeatureDescription3
            });
            return Ok("Feature Kısmı Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.TGetById(id);
            _featureService.TDelete(value);
            return Ok("Feature Alanı Silindi");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            _featureService.TUpdate(new Feature()
            {
                FeatureID = updateFeatureDto.FeatureID,
                FeatureTitle1 = updateFeatureDto.FeatureTitle1,
                FeatureTitle2 = updateFeatureDto.FeatureTitle2,
                FeatureTitle3 = updateFeatureDto.FeatureTitle3,
                FeatureDescription1 = updateFeatureDto.FeatureDescription1,
                FeatureDescription2 = updateFeatureDto.FeatureDescription2,
                FeatureDescription3 = updateFeatureDto.FeatureDescription3
            });
            return Ok("Feature Alanı güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetFeature(int id)
        {
            var values = _featureService.TGetById(id);
            return Ok(values);
        }
    }
}
