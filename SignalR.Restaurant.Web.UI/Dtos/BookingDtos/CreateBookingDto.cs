﻿namespace SignalR.Restaurant.Web.UI.Dtos.BookingDtos
{
    public class CreateBookingDto
    {        
        public string BookingName { get; set; }
        public string BookingPhone { get; set; }
        public string BookingMail { get; set; }
        public int BookingPersonCount { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
