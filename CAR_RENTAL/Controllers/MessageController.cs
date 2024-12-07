using CAR_RENTAL.DTOS.RequestDto;
using CAR_RENTAL.DTOS.ResponseDto;
using CAR_RENTAL.Entites;
using CAR_RENTAL.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CAR_RENTAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(SendMessageRequestDto requestDto)
        {
            var response = await _messageService.SendMessageAsync(requestDto);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            var messages = await _messageService.GetMessagesAsync();
            return Ok(messages);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetMessagesByCustomerId(int customerId)
        {
            var messages = await _messageService.GetMessagesByCustomerIdAsync(customerId);
            return Ok(messages);
        }
    }
}
