using Microsoft.AspNetCore.Mvc;
using SignalR.Restaurant.Business.Abstract;
using SignalR.Restaurant.DataAccess.Concrete;
using SignalR.Restaurant.Dtos.BasketDtos;
using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketsController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public IActionResult GetBasketByMenuTableID(int id)
        {
            var values = _basketService.TGetBasketByMenuTableNumber(id);
            return Ok(values);
        }

        [HttpGet("GetBasketListByMenuTableWithProductName")]
        public IActionResult GetBasketListByMenuTableWithProductName(int id)
        {
            var values = _basketService.TGetBasketListByMenuTableWithProductName(id);
            return Ok(values);
        }

        [HttpPost]
        public ActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context = new SignalRContext();
            _basketService.TAdd(new Basket
            {
                ProductID = createBasketDto.ProductID,
                Count = 1,
                MenuTableID = 4,
                Price = context.Products
                    .Where(x => x.ProductID == createBasketDto.ProductID)
                    .Select(y => y.Price)
                    .FirstOrDefault(),
                TotalPrice = 0
            });
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetById(id);
            _basketService.TDelete(value);
            return Ok("Sepetteki Seçilen Ürün Silindi");
        }
    }
}
