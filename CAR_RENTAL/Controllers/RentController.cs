using CAR_RENTAL.DTOS.RequestDto;
using CAR_RENTAL.DTOS.ResponseDto;
using CAR_RENTAL.Entites;
using CAR_RENTAL.Interfaces.IServices;
using CAR_RENTAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace CAR_RENTAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly IRentService _rentService;

        public RentController(IRentService rentService)
        {
            _rentService = rentService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RentResponseDto>> GetRentById(int id)
        {
            var rent = await _rentService.GetRentByIdAsync(id);
            if (rent == null)
                return NotFound();
            return Ok(rent);
        }

        [HttpPost]
        public async Task<ActionResult<RentResponseDto>> CreateRent(int BookingId, [FromBody] RentRequestDto rentRequestDto)
        {
            var rent = await _rentService.CreateRentAsync(BookingId,rentRequestDto);
            return CreatedAtAction(nameof(GetRentById), new { id = rent.RentId }, rent);
        }

        [HttpGet("Get-Rent{id}")]
        public async Task<ActionResult<BookingResponseDto>> GetRentByBookingId(int id)
        {
            var booking = await _rentService.GetRentByBookingId(id);
            if (booking == null)
                return NotFound();
            return Ok(booking);
        }


        [HttpGet]  
        public async Task<ActionResult<IEnumerable<RentResponseDto>>> GetAllRents()
        {
            var rents = await _rentService.GetAllRentsAsync();
            return Ok(rents);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRent(int id)
        {
            var result = await _rentService.DeleteRentAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

    }
}


