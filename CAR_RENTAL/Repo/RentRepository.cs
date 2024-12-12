using CAR_RENTAL.context;
using CAR_RENTAL.Entites;
using CAR_RENTAL.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CAR_RENTAL.Repo
{
    public class RentRepository : IRentRepository
    {
        private readonly AppDbContext _context;

        public RentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Rent> GetRentByIdAsync(int rentId)
        {
            return await _context.Rents.FindAsync(rentId);
        }

        public async Task CreateRentAsync(Rent rent)
        {
            await _context.Rents.AddAsync(rent);
            await _context.SaveChangesAsync();
        }

        public async Task<Rent> GetRentByBookingId(int BookingId)
        {
            var data =await _context.Rents.Where(r => r.BookingId == BookingId).FirstOrDefaultAsync();
            return data;
        }

        public async Task<IEnumerable<Rent>> GetAllRentsAsync()  
        {
            return await _context.Rents.ToListAsync();
        }

    }
}

