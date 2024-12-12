namespace CAR_RENTAL.DTOS.ResponseDto
{
    public class RentResponseDto
    {
        public int RentId { get; set; }
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public DateTime RentedDate { get; set; }
    }
}
