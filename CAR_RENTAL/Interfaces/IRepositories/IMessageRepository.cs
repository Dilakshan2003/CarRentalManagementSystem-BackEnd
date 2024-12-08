using CAR_RENTAL.Entites;

namespace CAR_RENTAL.Interfaces.IRepositories
{
    public interface IMessageRepository
    {
        Task<Message> AddMessageAsync(Message message);
        Task<List<Message>> GetMessagesAsync();
        Task<List<Message>> GetMessagesByCustomerIdAsync(int customerId);
        Task<bool> DeleteMessageByIdAsync(int id);
    }
}
