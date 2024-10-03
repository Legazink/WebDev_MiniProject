using Microsoft.EntityFrameworkCore;
using WebDev_MiniProject.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebDev_MiniProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<Account>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<JoinedAllPost> JoinedAllPosts { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    // กำหนดความสัมพันธ์ระหว่าง Account กับ Post
        //    builder.Entity<Post>()
        //        .HasOne(p => p.Account) // A Post has one Account
        //        .WithMany() // Account can have many Posts
        //        .HasForeignKey(p => p.AccountID) // ใช้ AccountID เป็น foreign key
        //        .OnDelete(DeleteBehavior.Cascade); // หากลบ Account จะลบ Posts ด้วย

        //    builder.Entity<JoinedAllPost>()
        //        .HasOne(j => j.Post)
        //        .WithMany()
        //        .HasForeignKey(j => j.PostID)
        //        .OnDelete(DeleteBehavior.Cascade);

        //}
    }
}
