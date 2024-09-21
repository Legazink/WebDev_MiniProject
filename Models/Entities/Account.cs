namespace WebDev_MiniProject.Models
{
    public class Account
    {
        public Guid ID { get; set; }
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
    }
}