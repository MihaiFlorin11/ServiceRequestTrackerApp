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

        public int AssignedToId { get; set; }
    }
}
