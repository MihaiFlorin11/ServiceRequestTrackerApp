using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DatabaseContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<ServiceRequest> ServiceRequests { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}
