namespace SignalR.Restaurant.Web.UI.Dtos.NotificationDtos
{
    public class CreateNotificationDto
    {
        public string NotificationType { get; set; }
        public string NotificationIcon { get; set; }
        public string NotificationDescription { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
