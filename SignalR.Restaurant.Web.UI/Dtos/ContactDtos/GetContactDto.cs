﻿namespace SignalR.Restaurant.Web.UI.Dtos.ContactDtos
{
    public class GetContactDto
    {
        public int ContactID { get; set; }
        public string ContactLocation { get; set; }
        public string ContactPhone { get; set; }
        public string ContactMail { get; set; }
        public string ContactFooterDescription { get; set; }
    }
}
