using CAR_RENTAL.DTOS.RequestDto;
using CAR_RENTAL.DTOS.ResponseDto;
using CAR_RENTAL.Services;

namespace CAR_RENTAL.Interfaces.IServices
{
    public interface IMessageService
    {
        Task<MessageResponseDto> SendMessageAsync(SendMessageRequestDto requestDto);
        Task<List<MessageResponseDto>> GetMessagesAsync();
        Task<List<MessageResponseDto>> GetMessagesByCustomerIdAsync(int customerId);
        Task<bool> DeleteMessageByIdAsync(int id);
    }
}
