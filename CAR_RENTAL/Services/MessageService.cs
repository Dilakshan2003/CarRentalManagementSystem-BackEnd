using CAR_RENTAL.DTOS.RequestDto;
using CAR_RENTAL.DTOS.ResponseDto;
using CAR_RENTAL.Entites;
using CAR_RENTAL.Interfaces.IRepositories;
using CAR_RENTAL.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAR_RENTAL.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        // Constructor injection of the repository
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        // Asynchronous method to send a message
        public async Task<MessageResponseDto> SendMessageAsync(SendMessageRequestDto requestDto)
        {
            
            var message = new Message
            {
                Content = requestDto.Content,
                Sender = requestDto.Sender,
                SentDate = DateTime.Now
            };
            var data = await _messageRepository.AddMessageAsync(message);
            var rseponce = new MessageResponseDto
            {
                Id = data.Id,
                Content = data.Content,
                Sender = data.Sender,
                SentDate = data.SentDate,
            };
            return rseponce;
        }

        // Asynchronous method to retrieve messages
        public async Task<List<MessageResponseDto>> GetMessagesAsync()
        {
            var messages = await _messageRepository.GetMessagesAsync();

            // Map the Message entities to MessageResponseDto
            return messages.Select(m => new MessageResponseDto
            {
                Id = m.Id,
                Content = m.Content,
                Sender = m.Sender,
                SentDate = m.SentDate
            }).ToList();
        }
    }
}
