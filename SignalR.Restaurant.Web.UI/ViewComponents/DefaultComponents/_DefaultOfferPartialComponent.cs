using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.Restaurant.Web.UI.Dtos.DiscountDtos;

namespace SignalR.Restaurant.Web.UI.ViewComponents.DefaultComponents
{
    public class _DefaultOfferPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultOfferPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7195/api/Discount/GetStatusTrue");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultDiscountDto>>(jsonData);
            return View(values);
        }
    }
}
