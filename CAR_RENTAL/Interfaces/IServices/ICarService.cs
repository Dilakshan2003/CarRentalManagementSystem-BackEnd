using CAR_RENTAL.DTOS.RequestDto;
using CAR_RENTAL.DTOS.ResponseDto;

namespace CAR_RENTAL.Interfaces.IServices
{
    public interface ICarService
    {
        Task<IEnumerable<CarResponseDto>> GetAllCarsAsync();
        Task<CarResponseDto> GetCarByIdAsync(int id);
        Task AddCarAsync(CarRequestDto carRequest);
        Task UpdateCarAsync(int id, CarRequestDto carRequest);
        Task DeleteCarAsync(int id);
    }
}
