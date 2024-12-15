using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.Restaurant.Business.Abstract;
using SignalR.Restaurant.Dtos.MessageDtos;
using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;
        public MessagesController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _mapper.Map<List<ResultMessageDto>>(_messageService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            _messageService.TAdd(new Message()
            {
                MessageContent = createMessageDto.MessageContent,
                MessageMail = createMessageDto.MessageMail,
                MessageNameSurname = createMessageDto.MessageNameSurname,
                MessagePhone = createMessageDto.MessagePhone,
                MessageSendDate = DateTime.Now,
                MessageSubject = createMessageDto.MessageSubject,
                Status = false
            });
            return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var value = _messageService.TGetById(id);
            _messageService.TDelete(value);
            return Ok("Hakkımda Alanı Silindi");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            _messageService.TUpdate(new Message()
            {
                MessageID = updateMessageDto.MessageID,
                MessageContent = updateMessageDto.MessageContent,
                MessageMail = updateMessageDto.MessageMail,
                MessageNameSurname = updateMessageDto.MessageNameSurname,
                MessagePhone = updateMessageDto.MessagePhone,
                MessageSendDate = updateMessageDto.MessageSendDate,
                MessageSubject = updateMessageDto.MessageSubject,
                Status = updateMessageDto.Status
            });
            return Ok("Hakkımda Alanı güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var values = _messageService.TGetById(id);
            return Ok(values);
        }

        [HttpGet("ChangeMessageStatusToFalse/{id}")]
        public IActionResult ChangeMessageStatusToFalse(int id)
        {
            _messageService.TChangeMessageStatusToFalse(id);
            return Ok("Durmu Değiştirildi");
        }

        [HttpGet("ChangeMessageStatusToTrue/{id}")]
        public IActionResult ChangeMessageStatusToTrue(int id)
        {
            _messageService.TChangeMessageStatusToTrue(id);
            return Ok("Durmu Değiştirildi");
        }
    }
}
