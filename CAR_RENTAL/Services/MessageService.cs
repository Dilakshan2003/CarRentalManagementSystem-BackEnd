using CAR_RENTAL.DTOS.RequestDto;
using CAR_RENTAL.DTOS.ResponseDto;
using CAR_RENTAL.Entites;
using CAR_RENTAL.Interfaces.IRepositories;
using CAR_RENTAL.Interfaces.IServices;
using CAR_RENTAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAR_RENTAL.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
     

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<MessageResponseDto> SendMessageAsync(SendMessageRequestDto requestDto)
        {
            var message = new Message
            {
                CustomerId = requestDto.CustomerId,
                Content = requestDto.Content,
                Sender = requestDto.Sender,
                SentDate = DateTime.Now
            };

            var savedMessage = await _messageRepository.AddMessageAsync(message);

            return new MessageResponseDto
            {
                Id = savedMessage.Id,
                CustomerId = savedMessage.CustomerId,
                Content = savedMessage.Content,
                Sender = savedMessage.Sender,
                SentDate = savedMessage.SentDate
            };
        }

        public async Task<List<MessageResponseDto>> GetMessagesAsync()
        {
            var messages = await _messageRepository.GetMessagesAsync();

            return messages.Select(m => new MessageResponseDto
            {
                Id = m.Id,
                CustomerId = m.CustomerId,
                Content = m.Content,
                Sender = m.Sender,
                SentDate = m.SentDate
            }).ToList();
        }

        public async Task<List<MessageResponseDto>> GetMessagesByCustomerIdAsync(int customerId)
        {
            var messages = await _messageRepository.GetMessagesByCustomerIdAsync(customerId);

            return messages.Select(m => new MessageResponseDto
            {
                Id = m.Id,
                CustomerId = m.CustomerId,
                Content = m.Content,
                Sender = m.Sender,
                SentDate = m.SentDate
            }).ToList();
        }
    }
}
