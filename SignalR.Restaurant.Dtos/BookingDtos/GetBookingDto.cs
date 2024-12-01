﻿namespace SignalR.Restaurant.Dtos.BookingDtos
{
    public class GetBookingDto
    {
        public int BookingID { get; set; }
        public string BookingName { get; set; }
        public string BookingPhone { get; set; }
        public string BookingMail { get; set; }
        public int BookingPersonCount { get; set; }
        public DateTime BookingDate { get; set; }
    }
}