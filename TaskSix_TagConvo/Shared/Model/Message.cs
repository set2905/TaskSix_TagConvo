namespace TaskSix_TagConvo.Shared.Model
{
    public class Message
    {
        public Message()
        {   
            Content=string.Empty;
        }

        public Guid Id { get; set; }
        public string Content { get; set; }
    }
}
