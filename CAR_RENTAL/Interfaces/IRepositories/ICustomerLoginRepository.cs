using CAR_RENTAL.Entites;

namespace CAR_RENTAL.Interfaces.IRepositories
{
    public interface ICustomerLoginRepository
    {
        Task<Customer> GetCustomerByEmailAsync(string email);
        Task AddCustomerAsync(CustomerLogin customerLogin);
    }
}
