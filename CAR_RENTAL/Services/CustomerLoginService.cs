using CAR_RENTAL.DTOS.RequestDto;
using CAR_RENTAL.DTOS.ResponseDto;
using CAR_RENTAL.Entites;
using CAR_RENTAL.Interfaces.IRepositories;
using CAR_RENTAL.Interfaces.IServices;

namespace CAR_RENTAL.Services
{
    public class CustomerLoginService  : ICustomerLoginService
    {
        private readonly ICustomerLoginRepository _repository;
        private readonly IConfiguration _configuration;

        public CustomerLoginService(ICustomerLoginRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public async Task<CustomerLoginResponseDto> LoginAsync(CustomerLoginRequestDto request)
        {
            var customer = await _repository.GetCustomerByEmailAsync(request.Email);

            

            var token = GenerateJwtToken(customer); // Implement JWT Token generation here

            return new CustomerLoginResponseDto
            {
                Id = customer.Id,
                Email = customer.Email,
                Token = token
            };
        }

        private bool VerifyPassword(string inputPassword, string storedPassword)
        {
            // This is where you would verify the hashed password in a real application
            return inputPassword == storedPassword; // Simple comparison for illustration
        }

        private string GenerateJwtToken(Customer customer)
        {
            // Implement JWT generation here, for now just a simple token placeholder
            return $"{customer.Id}-{Guid.NewGuid()}";
        }
    }
}
