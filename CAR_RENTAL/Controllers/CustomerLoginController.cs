using CAR_RENTAL.DTOS.RequestDto;
using CAR_RENTAL.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CAR_RENTAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerLoginController : ControllerBase
    {
        private readonly ICustomerLoginService _service;

        public CustomerLoginController(ICustomerLoginService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] CustomerLoginRequestDto request)
        {
            if (request == null)
            {
                return BadRequest("Invalid login request.");
            }

            try
            {
                var response = await _service.LoginAsync(request);
                return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}
