using Microsoft.AspNetCore.Mvc;
using SignalR.Restaurant.Business.Abstract;
using SignalR.Restaurant.Dtos.NotificationDtos;
using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            return Ok(_notificationService.TGetListAll());
        }

        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(_notificationService.TNotificationCountByStatusFalse());
        }

        [HttpGet("GetAllNotificationByFalse")]
        public IActionResult GetAllNotificationByFalse()
        {
            return Ok(_notificationService.TGetAllNotificationByFalse());
        }

        [HttpGet("NotificationStatusChangeToTrue/{id}")]
        public IActionResult NotificationStatusChangeToTrue(int id)
        {
            _notificationService.TNotificationStatusChangeToTrue(id);
            return Ok("Güncelleme yapıldı");
        }

        [HttpGet("NotificationStatusChangeToFalse/{id}")]
        public IActionResult NotificationStatusChangeToFalse(int id)
        {
            _notificationService.TNotificationStatusChangeToFalse(id);
             return Ok("Güncelleme yapıldı");
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            Notification notification = new Notification()
            {
                NotificationDescription = createNotificationDto.NotificationDescription,
                NotificationIcon = createNotificationDto.NotificationIcon,
                NotificationType = createNotificationDto.NotificationType,
                Status = false,
                Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
            };
            _notificationService.TAdd(notification);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            _notificationService.TDelete(value);
            return Ok("Bildirim silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            _notificationService.TUpdate(new Notification()
            {
                NotificationID = updateNotificationDto.NotificationID,
                NotificationDescription = updateNotificationDto.NotificationDescription,
                NotificationIcon = updateNotificationDto.NotificationIcon,
                NotificationType = updateNotificationDto.NotificationType,
                Status = updateNotificationDto.Status,
                Date = updateNotificationDto.Date
            });
            return Ok("Bildirim güncellendi");
        }
    }
}