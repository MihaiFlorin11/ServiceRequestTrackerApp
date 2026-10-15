using Domain.Enums;

namespace Domain.Entities
{
    public class ServiceRequest
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public ServiceRequestStatus Status { get; set; }

        public ServiceRequestPriority Priority { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public int RequesterId { get; set; }

        public User Requester { get; set; } = null!;

        public int? AssignedToId { get; set; }

        public User? AssignedTo { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
