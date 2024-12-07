namespace CAR_RENTAL.DTOS.ResponseDto
{
    public class MessageResponseDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Content { get; set; }
        public string Sender { get; set; }
        public DateTime SentDate { get; set; } = DateTime.Now;
    }
}
