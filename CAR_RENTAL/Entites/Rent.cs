namespace CAR_RENTAL.Entites
{
    public class Rent
    {
        public int RentId { get; set; }
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public DateTime RentedDate { get; set; }

        public Booking Booking { get; set; }
        public Customer Customer { get; set; }
        public Car car { get; set; }
    }
}
