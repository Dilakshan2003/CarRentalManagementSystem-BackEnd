namespace CAR_RENTAL.Entites
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } // E.g., "Confirmed", "Pending", "Cancelled"
        public DateTime CreatedDate { get; set; }
    }
}
