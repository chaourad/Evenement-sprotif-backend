namespace evenement.Dto.Message
{
    public class CreateMessageDto
    {
         public string Content { get; set; }
        public Guid UserId { get; set; }
    }
}