namespace Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public int RequestId { get; set; }

        public ServiceRequest Request { get; set; } = null!;

        public int AuthorId { get; set; }

        public User Author { get; set; } = null!;

        public string? Body { get; set; } = string.Empty;

        public DateTimeOffset CreatedAt { get; set; }
    }
}
