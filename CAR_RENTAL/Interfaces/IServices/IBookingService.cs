using CAR_RENTAL.DTOS.RequestDto;
using CAR_RENTAL.DTOS.ResponseDto;

namespace CAR_RENTAL.Interfaces.IServices
{
    public interface IBookingService
    {
        Task<List<BookingResponseDto>> GetAllBookingsAsync();
        Task<BookingResponseDto> GetBookingByIdAsync(int id);
        Task<BookingResponseDto> CreateBookingAsync(BookingRequestDto bookingRequestDto);
        Task<BookingResponseDto> UpdateBookingAsync(int id, BookingRequestDto bookingRequestDto);
        Task DeleteBookingAsync(int id);
    }
}
