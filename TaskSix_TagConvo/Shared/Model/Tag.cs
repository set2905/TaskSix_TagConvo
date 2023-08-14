namespace TaskSix_TagConvo.Shared.Model
{
    public class Tag
    {
        public Tag()
        {
            Name=string.Empty;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
