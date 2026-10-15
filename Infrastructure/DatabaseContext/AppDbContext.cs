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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ServiceRequest -> User who submitted it
            modelBuilder.Entity<ServiceRequest>()
                .HasOne(request => request.Requester)
                .WithMany()
                .HasForeignKey(request => request.RequesterId)
                .OnDelete(DeleteBehavior.Restrict);

            // ServiceRequest -> optional assigned User
            modelBuilder.Entity<ServiceRequest>()
                .HasOne(request => request.AssignedTo)
                .WithMany()
                .HasForeignKey(request => request.AssignedToId)
                .OnDelete(DeleteBehavior.SetNull);

            // Comment -> ServiceRequest
            modelBuilder.Entity<Comment>()
                .HasOne(comment => comment.Request)
                .WithMany(request => request.Comments)
                .HasForeignKey(comment => comment.RequestId)
                .OnDelete(DeleteBehavior.Restrict);

            // Comment -> User who wrote it
            modelBuilder.Entity<Comment>()
                .HasOne(comment => comment.Author)
                .WithMany()
                .HasForeignKey(comment => comment.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Example column constraints
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(user => user.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(user => user.Email)
                    .HasMaxLength(256)
                    .IsRequired();

                // Keep this only if each email must belong to one user.
                entity.HasIndex(user => user.Email)
                    .IsUnique();
            });

            modelBuilder.Entity<Comment>()
                .Property(comment => comment.Body)
                .HasMaxLength(2000)
                .IsRequired();
        }
    }
}
