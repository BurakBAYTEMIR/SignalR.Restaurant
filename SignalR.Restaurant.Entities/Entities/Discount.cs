﻿namespace SignalR.Restaurant.Entities.Entities
{
    public class Discount
    {
        public int DiscountID { get; set; }
        public string DiscountTitle { get; set; }
        public string DiscountAmount { get; set; }
        public string DiscountDescription { get; set; }
        public string DiscountImageUrl { get; set; }
        public bool DiscountStatus { get; set; }
    }
}
