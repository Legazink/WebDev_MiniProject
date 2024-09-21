using Microsoft.EntityFrameworkCore;
using WebDev_MiniProject.Models;

namespace WebDev_MiniProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
    }
}