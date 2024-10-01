using Microsoft.AspNetCore.Identity;

namespace WebDev_MiniProject.Models.Entities
{
    public class Account : IdentityUser
    {
        public int AccountID { get; set; }
    }
}