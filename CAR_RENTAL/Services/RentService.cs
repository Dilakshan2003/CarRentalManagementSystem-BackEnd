using CAR_RENTAL.DTOS.RequestDto;
using CAR_RENTAL.DTOS.ResponseDto;
using CAR_RENTAL.Entites;
using CAR_RENTAL.Interfaces.IRepositories;
using CAR_RENTAL.Interfaces.IServices;
using Microsoft.Extensions.Logging;

namespace CAR_RENTAL.Services
{
    public class RentService : IRentService
    {
        private readonly IRentRepository _rentRepository;
        private readonly ICarRepository _carRepository;
        private readonly IBookingRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;

        public RentService(IRentRepository rentRepository, ICarRepository carRepository, IBookingRepository bookRepository, ICustomerRepository customerRepository)
        {
            _rentRepository = rentRepository;
            _carRepository = carRepository;
            _bookRepository = bookRepository;
            _customerRepository = customerRepository;
        }

        public async Task<RentResponseDto> GetRentByIdAsync(int rentId)
        {
            var rent = await _rentRepository.GetRentByIdAsync(rentId);
            if (rent == null) return null;

            return new RentResponseDto
            {
                RentId = rent.RentId,
                BookingId = rent.BookingId,
                CustomerId = rent.CustomerId,
                CarId = rent.CarId,
                StartDate = rent.StartDate,
                EndDate = rent.EndDate,
                Status = rent.Status,
                RentedDate = rent.RentedDate
            };
        }

        public async Task<RentResponseDto> CreateRentAsync(int BookingId,RentRequestDto rentRequestDto)
        {
           
            var booking = await _bookRepository.GetBookingByIdAsync(BookingId);
            var rent = new Rent
            {
                BookingId = BookingId,
                CustomerId = booking.CustomerId,
                CarId = booking.CarId,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                Status = rentRequestDto.Status,
                RentedDate = DateTime.Now
            };

            await _rentRepository.CreateRentAsync(rent);

            return new RentResponseDto
            {
                RentId = rent.RentId,
                BookingId = rent.BookingId,
                CustomerId = rent.CustomerId,
                CarId = rent.CarId,
                StartDate = rent.StartDate,
                EndDate = rent.EndDate,
                Status = rent.Status,
                RentedDate = rent.RentedDate
            };
        }

        public async Task<RentResponseDto> GetRentByBookingId(int BookingId)
        {
            var rent = await _rentRepository.GetRentByBookingId(BookingId);
            if (rent == null) return null;

            return new RentResponseDto
            {
                RentId = rent.RentId,
                BookingId = rent.BookingId,
                CustomerId = rent.CustomerId,
                CarId = rent.CarId,
                StartDate = rent.StartDate,
                EndDate = rent.EndDate,
                Status = rent.Status,
                RentedDate = rent.RentedDate
            };
        }

        public async Task<IEnumerable<RentResponseDto>> GetAllRentsAsync() 
        {
            var rents = await _rentRepository.GetAllRentsAsync();  
            return rents.Select(rent => new RentResponseDto
            {
                RentId = rent.RentId,
                BookingId = rent.BookingId,
                CustomerId = rent.CustomerId,
                CarId = rent.CarId,
                StartDate = rent.StartDate,
                EndDate = rent.EndDate,
                Status = rent.Status,
                RentedDate = rent.RentedDate
            });
        }



    }

}



