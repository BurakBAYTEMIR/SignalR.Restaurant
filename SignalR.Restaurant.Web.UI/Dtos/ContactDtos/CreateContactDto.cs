namespace SignalR.Restaurant.Web.UI.Dtos.ContactDtos
{
    public class CreateContactDto
    {
        public string ContactLocation { get; set; }
        public string ContactPhone { get; set; }
        public string ContactMail { get; set; }
        public string ContactFooterTitle { get; set; }
        public string ContactFooterDescription { get; set; }
        public string ContactOpenDays { get; set; }
        public string ContactOpenDaysDescription { get; set; }
        public string ContactOpenHours { get; set; }
    }
}
