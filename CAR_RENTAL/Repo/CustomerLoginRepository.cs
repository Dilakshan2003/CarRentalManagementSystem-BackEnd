using CAR_RENTAL.context;
using CAR_RENTAL.Entites;
using CAR_RENTAL.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CAR_RENTAL.Repo
{
    public class CustomerLoginRepository: ICustomerLoginRepository
    {
        
    private readonly AppDbContext _context;

        public CustomerLoginRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task AddCustomerAsync(CustomerLogin customerLogin)
        {
            await _context.CustomerLogins.AddAsync(customerLogin);
            await _context.SaveChangesAsync();
        }
    }
}
