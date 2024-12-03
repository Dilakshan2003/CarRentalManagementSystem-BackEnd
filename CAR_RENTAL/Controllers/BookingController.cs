using CAR_RENTAL.DTOS.RequestDto;
using CAR_RENTAL.DTOS.ResponseDto;
using CAR_RENTAL.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CAR_RENTAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookingResponseDto>>> GetBookings()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingResponseDto>> GetBookingById(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
                return NotFound();
            return Ok(booking);
        }

        [HttpPost]
        public async Task<ActionResult<BookingResponseDto>> CreateBooking(int CustomerId,[FromBody] BookingRequestDto bookingRequestDto)
        {
            var booking = await _bookingService.CreateBookingAsync(CustomerId, bookingRequestDto);
            return CreatedAtAction(nameof(GetBookingById), new { id = booking.BookingId }, booking);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookingResponseDto>> UpdateBooking(int id, [FromBody] BookingRequestDto bookingRequestDto)
        {
            var updatedBooking = await _bookingService.UpdateBookingAsync(id, bookingRequestDto);
            if (updatedBooking == null)
                return NotFound();
            return Ok(updatedBooking);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            await _bookingService.DeleteBookingAsync(id);
            return NoContent();
        }
    }
}
