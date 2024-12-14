namespace SignalR.Restaurant.Entities.Entities
{
    public class Notification
    {
        public int NotificationID { get; set; }
        public string NotificationType { get; set; }
        public string NotificationIcon { get; set; }
        public string NotificationDescription { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
