using Microsoft.AspNetCore.Identity;

namespace WebDev_MiniProject.Models.Entities
{
    public class Account : IdentityUser
    {
        public ICollection<Post> Posts { get; set; } = [];

        public ICollection<JoinedAllPost> JoinAllPosts { get; set; } = [];
    }
}