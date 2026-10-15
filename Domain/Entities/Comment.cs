namespace Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public int RequestId { get; set; }

        public int AuthorId { get; set; }

        public string? Body { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
