namespace SignalR.Restaurant.Web.UI.Dtos.NotificationDtos
{
    public class GetNotificationDto
    {
        public int NotificationID { get; set; }
        public string NotificationType { get; set; }
        public string NotificationIcon { get; set; }
        public string NotificationDescription { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
