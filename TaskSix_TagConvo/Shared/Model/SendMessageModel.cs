namespace TaskSix_TagConvo.Shared.Model
{
    public class SendMessageModel
    {
        public SendMessageModel(string content, string[] tags)
        {
            Content=content;
            Tags=tags;
        }

        public string Content { get; set; }
        public string[] Tags { get; set; }
    }
}
