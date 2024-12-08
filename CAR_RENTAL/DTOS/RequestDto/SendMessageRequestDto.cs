using CAR_RENTAL.Entites;

namespace CAR_RENTAL.DTOS.RequestDto
{
    public class SendMessageRequestDto
    {
        public int CustomerId { get; set; }
        public string Content { get; set; }
        public string Sender { get; set; }
       

    }
}
