using CAR_RENTAL.Entites;

namespace CAR_RENTAL.Interfaces.IRepositories
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllBookingsAsync();
        Task<Booking> GetBookingByIdAsync(int id);
        Task CreateBookingAsync(Booking booking);
        Task<Booking> UpdateBookingAsync(Booking booking);
        Task DeleteBookingAsync(int id);
    }
}
