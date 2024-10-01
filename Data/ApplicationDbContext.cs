using Microsoft.EntityFrameworkCore;
using WebDev_MiniProject.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebDev_MiniProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<Account>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

        // Override the OnModelCreating method
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Add custom configurations or constraints here
            builder.Entity<Account>()
                .Property(u => u.AccountID)
                .ValueGeneratedOnAdd(); // Automatically increment AccountId when a new user is created

            // You can add other configurations for the entities here as well
        }
    }
}
