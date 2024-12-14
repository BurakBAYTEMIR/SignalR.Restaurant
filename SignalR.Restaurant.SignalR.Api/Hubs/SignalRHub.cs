using Microsoft.AspNetCore.SignalR;
using SignalR.Restaurant.Business.Abstract;

namespace SignalR.Restaurant.SignalR.Api.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }
        public static int clientCount { get; set; } = 0;
        public async Task SendStatistic()
        {
            var categoryCount = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);

            var productCount = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", productCount);

            var activeCategoryCount = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", activeCategoryCount);

            var passiveCategoryCount = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", passiveCategoryCount);

            var productCountByCategoryNameHamburger = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", productCountByCategoryNameHamburger);

            var productCountByCategoryNameDrink = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", productCountByCategoryNameDrink);

            var productPriceAvg = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", productPriceAvg.ToString("0.00" + "₺"));

            var productNameByMaxPrice = _productService.TProductNameByMaxPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", productNameByMaxPrice);

            var productNameByMinPrice = _productService.TProductNameByMinPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMinPrice", productNameByMinPrice);

            var productAvgPriceByHamburger = _productService.TProductAvgPriceByHamburger();
            await Clients.All.SendAsync("ReceiveProductAvgPriceByHamburger", productAvgPriceByHamburger.ToString("0.00" + "₺"));

            var totalOrderCount = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", totalOrderCount);

            var activeOrderCount = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrderCount);

            var lastOrderPrice = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", lastOrderPrice.ToString("0.00" + "₺"));

            var totalMoneyCaseAmount = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", totalMoneyCaseAmount.ToString("0.00" + "₺"));

            var menuTableCount = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", menuTableCount);
        }

        public async Task SendProgress()
        {
            var totalMoneyCaseAmount = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", totalMoneyCaseAmount.ToString("0.00" + "₺"));
        }

        public async Task GetBookingList()
        {
            var value = _bookingService.TGetListAll();
            await Clients.All.SendAsync("ReceiveBookingList", value);
        }

        public async Task SendNotification()
        {
            var notificationCountByStatusFalse = _notificationService.TNotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationCountByStatusFalse", notificationCountByStatusFalse);

            var getAllNotificationByFalse = _notificationService.TGetAllNotificationByFalse();
            await Clients.All.SendAsync("ReceiveGetAllNotificationByFalse", getAllNotificationByFalse);
        }

        public async Task GetMenuTableStatus()
        {
            var value = _menuTableService.TGetListAll();
            await Clients.All.SendAsync("ReceiveMenuTableStatus", value);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            clientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
