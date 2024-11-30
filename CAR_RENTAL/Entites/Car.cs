namespace CAR_RENTAL.Entites
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal PricePerDay { get; set; }
        public string Color { get; set; }
        public bool IsAvailable { get; set; }
        public string ImageFilePath { get; set; }  
    }
}
