using CAR_RENTAL.DTOS.RequestDto;
using CAR_RENTAL.DTOS.ResponseDto;
using CAR_RENTAL.Entites;
using CAR_RENTAL.Interfaces.IRepositories;
using CAR_RENTAL.Interfaces.IServices;

namespace CAR_RENTAL.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly ICustomerRepository _customerRepository;

        public BookingService(IBookingRepository bookingRepository, ICustomerRepository customerRepository)
        {
            _bookingRepository = bookingRepository;
            _customerRepository = customerRepository;
        }

        public async Task<List<BookingResponseDto>> GetAllBookingsAsync()
        {
           
            var bookings = await _bookingRepository.GetAllBookingsAsync();
        
            var bookingDtos = new List<BookingResponseDto>();

            foreach (var booking in bookings)
            {
                var bookingDto = new BookingResponseDto
                {
                    BookingId = booking.BookingId,
                    CustomerId = booking.CustomerId,
                    CarId = booking.CarId,
                    StartDate = booking.StartDate,
                    EndDate = booking.EndDate,
                    Status = booking.Status,
                    CreatedDate = booking.CreatedDate
                };
                bookingDtos.Add(bookingDto);
            }

            return bookingDtos;
        }

        public async Task<BookingResponseDto> GetBookingByIdAsync(int id)
        {
            var booking = await _bookingRepository.GetBookingByIdAsync(id);

            if (booking == null)
            {
                return null;
            }

            var bookingDto = new BookingResponseDto
            {
                BookingId = booking.BookingId,
                CustomerId = booking.CustomerId,
                CarId = booking.CarId,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                Status = booking.Status,
                CreatedDate = booking.CreatedDate
            };

            return bookingDto;
        }

        //public async Task<BookingResponseDto> CreateBookingAsync(BookingRequestDto bookingRequestDto)
        //{
        //    var booking = new Booking
        //    {
        //        CustomerId = bookingRequestDto.CustomerId,
        //        CarId = bookingRequestDto.CarId,
        //        StartDate = bookingRequestDto.StartDate,
        //        EndDate = bookingRequestDto.EndDate,
        //        Status = bookingRequestDto.Status,
        //        CreatedDate = System.DateTime.UtcNow
        //    };

        //    await _bookingRepository.CreateBookingAsync(booking);

        //    var bookingDto = new BookingResponseDto
        //    {
        //        BookingId = booking.BookingId,
        //        CustomerId = booking.CustomerId,
        //        CarId = booking.CarId,
        //        StartDate = booking.StartDate,
        //        EndDate = booking.EndDate,
        //        Status = booking.Status,
        //        CreatedDate = booking.CreatedDate
        //    };

        //    return bookingDto;
        //}








        public async Task<BookingResponseDto> CreateBookingAsync(int CustomerId,BookingRequestDto bookingRequestDto)
        {
            var  customer = await _customerRepository.GetCustomerByIdAsync(CustomerId);
            var booking = new Booking
            {
                CustomerId = customer.Id,
                CarId = bookingRequestDto.CarId,
                StartDate = bookingRequestDto.StartDate,
                EndDate = bookingRequestDto.EndDate,
                Status = bookingRequestDto.Status,
                CreatedDate = System.DateTime.Now
            };

            await _bookingRepository.CreateBookingAsync(booking);

            var bookingDto = new BookingResponseDto
            {
                BookingId = booking.BookingId,
                CustomerId = booking.CustomerId,
                CarId = booking.CarId,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                Status = booking.Status,
                CreatedDate = booking.CreatedDate
            };

            return bookingDto;
        }




















        public async Task<BookingResponseDto> UpdateBookingAsync(int id, BookingRequestDto bookingRequestDto)
        {
            var existingBooking = await _bookingRepository.GetBookingByIdAsync(id);

            if (existingBooking != null)
            {
                existingBooking.CustomerId = bookingRequestDto.CustomerId;
                existingBooking.CarId = bookingRequestDto.CarId;
                existingBooking.StartDate = bookingRequestDto.StartDate;
                existingBooking.EndDate = bookingRequestDto.EndDate;
                existingBooking.Status = bookingRequestDto.Status;

                await _bookingRepository.UpdateBookingAsync(existingBooking);

                var bookingDto = new BookingResponseDto
                {
                    BookingId = existingBooking.BookingId,
                    CustomerId = existingBooking.CustomerId,
                    CarId = existingBooking.CarId,
                    StartDate = existingBooking.StartDate,
                    EndDate = existingBooking.EndDate,
                    Status = existingBooking.Status,
                    CreatedDate = existingBooking.CreatedDate
                };

                return bookingDto;
            }

            return null;
        }

        public async Task DeleteBookingAsync(int id)
        {
            await _bookingRepository.DeleteBookingAsync(id);
        }
    }
}