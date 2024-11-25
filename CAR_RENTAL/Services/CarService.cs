using CAR_RENTAL.DTOS.RequestDto;
using CAR_RENTAL.DTOS.ResponseDto;
using CAR_RENTAL.Entites;
using CAR_RENTAL.Interfaces.IRepositories;
using CAR_RENTAL.Interfaces.IServices;

namespace CAR_RENTAL.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IEnumerable<CarResponseDto>> GetAllCarsAsync()
        {
            var cars = await _carRepository.GetAllCarsAsync();

            // Manually map Car to CarResponseDto
            var carResponseDtos = new List<CarResponseDto>();
            foreach (var car in cars)
            {
                carResponseDtos.Add(new CarResponseDto
                {
                    Id = car.Id,
                    Make = car.Make,
                    Model = car.Model,
                    Year = car.Year,
                    PricePerDay = car.PricePerDay,
                    Color = car.Color,
                    IsAvailable = car.IsAvailable,
                    ImageFilePath = car.ImageFilePath
                });
            }

            return carResponseDtos;
        }

        public async Task<CarResponseDto> GetCarByIdAsync(int id)
        {
            var car = await _carRepository.GetCarByIdAsync(id);
            if (car == null)
            {
                return null; // Or throw an exception if needed
            }

            // Manually map Car to CarResponseDto
            return new CarResponseDto
            {
                Id = car.Id,
                Make = car.Make,
                Model = car.Model,
                Year = car.Year,
                PricePerDay = car.PricePerDay,
                Color = car.Color,
                IsAvailable = car.IsAvailable,
                ImageFilePath = car.ImageFilePath
            };
        }

        public async Task AddCarAsync(CarRequestDto carRequest)
        {
            // Manually map CarRequestDto to Car
            var car = new Car
            {
                Make = carRequest.Make,
                Model = carRequest.Model,
                Year = carRequest.Year,
                PricePerDay = carRequest.PricePerDay,
                Color = carRequest.Color,
                IsAvailable = carRequest.IsAvailable,
                ImageFilePath = carRequest.ImageFilePath
            };

            await _carRepository.AddCarAsync(car);
        }

        public async Task UpdateCarAsync(int id, CarRequestDto carRequest)
        {
            var car = await _carRepository.GetCarByIdAsync(id);
            if (car != null)
            {
                // Manually update Car fields with CarRequestDto
                car.Make = carRequest.Make;
                car.Model = carRequest.Model;
                car.Year = carRequest.Year;
                car.PricePerDay = carRequest.PricePerDay;
                car.Color = carRequest.Color;
                car.IsAvailable = carRequest.IsAvailable;
                car.ImageFilePath = carRequest.ImageFilePath;

                await _carRepository.UpdateCarAsync(car);
            }
        }

        public async Task DeleteCarAsync(int id)
        {
            await _carRepository.DeleteCarAsync(id);
        }
    }
}
