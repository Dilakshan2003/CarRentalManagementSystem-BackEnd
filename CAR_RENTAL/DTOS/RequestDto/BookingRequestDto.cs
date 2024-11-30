namespace CAR_RENTAL.DTOS.RequestDto
{
    public class BookingRequestDto
    {   
         public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
         public DateTime CreatedDate { get; set; }
    }
}
