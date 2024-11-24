using CAR_RENTAL.Entites;

namespace CAR_RENTAL.Interfaces.IRepositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<Customer> GetCustomerByNICAsync(string nic);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> AddCustomerAsync(Customer customer);
        Task<Customer> UpdateCustomerAsync(Customer customer);
        Task<bool> DeleteCustomerAsync(int id);
    }
}
