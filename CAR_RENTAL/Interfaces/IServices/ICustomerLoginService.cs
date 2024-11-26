using CAR_RENTAL.DTOS.RequestDto;
using CAR_RENTAL.DTOS.ResponseDto;

namespace CAR_RENTAL.Interfaces.IServices
{
    public interface ICustomerLoginService
    {
        Task<CustomerLoginResponseDto> LoginAsync(CustomerLoginRequestDto request);

    }
}
