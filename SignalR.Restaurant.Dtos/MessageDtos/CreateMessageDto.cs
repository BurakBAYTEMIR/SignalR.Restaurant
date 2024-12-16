﻿namespace SignalR.Restaurant.Dtos.MessageDtos
{
    public class CreateMessageDto
    {
        public string MessageNameSurname { get; set; }
        public string MessageMail { get; set; }
        public string MessagePhone { get; set; }
        public string MessageSubject { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageSendDate { get; set; }
        public bool Status { get; set; }
    }
}