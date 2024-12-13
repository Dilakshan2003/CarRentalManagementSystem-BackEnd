using CAR_RENTAL.DTOS.RequestDto;
using CAR_RENTAL.DTOS.ResponseDto;

namespace CAR_RENTAL.Interfaces.IServices
{
    public interface IRentService
    {
        Task<RentResponseDto> GetRentByIdAsync(int rentId);
        Task<RentResponseDto> CreateRentAsync(int BookingId,RentRequestDto rentRequestDto);

        Task<RentResponseDto> GetRentByBookingId(int BookingId);
        Task<IEnumerable<RentResponseDto>> GetAllRentsAsync();
        Task<bool> DeleteRentAsync(int rentId);
    }
}
