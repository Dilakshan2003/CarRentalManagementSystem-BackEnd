namespace CAR_RENTAL.Entites
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Sender { get; set; } 
        public DateTime SentDate { get; set; } = DateTime.Now;
    }
}
