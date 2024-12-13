using CAR_RENTAL.DTOS.ResponseDto;
using CAR_RENTAL.Entites;

namespace CAR_RENTAL.Interfaces.IRepositories
{
    public interface IRentRepository
    {
        Task<Rent> GetRentByIdAsync(int rentId);
        Task CreateRentAsync(Rent rent);
        Task<Rent> GetRentByBookingId(int BookingId);
        Task<IEnumerable<Rent>> GetAllRentsAsync();
        Task DeleteRentAsync(Rent rent);
    }
}
