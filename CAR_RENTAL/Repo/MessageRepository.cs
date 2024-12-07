using CAR_RENTAL.context;
using CAR_RENTAL.Entites;
using CAR_RENTAL.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CAR_RENTAL.Repo
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbContext _context;

        public MessageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Message> AddMessageAsync(Message message)
        {
            var data = await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<List<Message>> GetMessagesAsync()
        {
            return await _context.Messages.OrderBy(m => m.SentDate).ToListAsync();
        }

        public async Task<List<Message>> GetMessagesByCustomerIdAsync(int customerId)
        {
            return await _context.Messages
                .Where(m => m.CustomerId == customerId)
                .OrderBy(m => m.SentDate)
                .ToListAsync();
        }
    }
}
