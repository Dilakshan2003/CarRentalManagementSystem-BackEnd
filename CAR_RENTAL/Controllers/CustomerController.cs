using CAR_RENTAL.DTOS.RequestDto;
using CAR_RENTAL.DTOS.ResponseDto;
using CAR_RENTAL.Entites;
using CAR_RENTAL.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CAR_RENTAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerResponseDto>> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(new CustomerResponseDto
            {
                Id = customer.Id,
                Name = customer.Name,
                NIC = customer.NIC,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address,
                LicenceNumber = customer.LicenceNumber,
                password = customer.password,



            });
        }

        [HttpGet("nic/{nic}")]
        public async Task<ActionResult<CustomerResponseDto>> GetCustomerByNIC(string nic)
        {
            var customer = await _customerService.GetCustomerByNICAsync(nic);
            if (customer == null)
            {
                return NotFound(new {Message = "user not insert"});
            }

            return Ok(new CustomerResponseDto
            {
                Id = customer.Id,
                Name = customer.Name,
                NIC = customer.NIC,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address,
                LicenceNumber = customer.LicenceNumber,
                password = customer.password,
            });
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerResponseDto>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            var customerDtos = new List<CustomerResponseDto>();

            foreach (var customer in customers)
            {
                customerDtos.Add(new CustomerResponseDto
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    NIC = customer.NIC,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                    Address = customer.Address,
                    LicenceNumber = customer.LicenceNumber,
                    password=customer.password,
                });
            }

            return Ok(customerDtos);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerResponseDto>> CreateCustomer(CustomerRequestDto customerRequest)
        {
            var customer = new Customer
            {
                Name = customerRequest.Name,
                NIC = customerRequest.NIC,
                Email = customerRequest.Email,
                PhoneNumber = customerRequest.PhoneNumber,
                Address = customerRequest.Address,
                LicenceNumber = customerRequest.LicenceNumber,
                password = customerRequest.password,
            };

            var createdCustomer = await _customerService.CreateCustomerAsync(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.Id }, new CustomerResponseDto
            {
                Id = createdCustomer.Id,
                Name = createdCustomer.Name,
                NIC = createdCustomer.NIC,
                Email = createdCustomer.Email,
                PhoneNumber = createdCustomer.PhoneNumber,
                Address = createdCustomer.Address,
                LicenceNumber = createdCustomer.LicenceNumber,
                password=createdCustomer.password,

            });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerResponseDto>> UpdateCustomer(int id, CustomerRequestDto customerRequest)
        {
            var existingCustomer = await _customerService.GetCustomerByIdAsync(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            existingCustomer.Name = customerRequest.Name;
            existingCustomer.NIC = customerRequest.NIC;
            existingCustomer.Email = customerRequest.Email;
            existingCustomer.PhoneNumber = customerRequest.PhoneNumber;
            existingCustomer.Address = customerRequest.Address;
            existingCustomer.LicenceNumber = customerRequest.LicenceNumber;
            existingCustomer.password=customerRequest.password;


            var updatedCustomer = await _customerService.UpdateCustomerAsync(existingCustomer);

            return Ok(new CustomerResponseDto
            {
                Id = updatedCustomer.Id,
                Name = updatedCustomer.Name,
                NIC = updatedCustomer.NIC,
                Email = updatedCustomer.Email,
                PhoneNumber = updatedCustomer.PhoneNumber,
                Address = updatedCustomer.Address,
                LicenceNumber = updatedCustomer.LicenceNumber,
                password = updatedCustomer.password,

            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var success = await _customerService.DeleteCustomerAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
