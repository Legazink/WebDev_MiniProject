using System.ComponentModel.DataAnnotations.Schema;

namespace WebDev_MiniProject.Models.Entities
{
    public class Post
    {
        public Guid PostId { get; set; }
        public string GameName { get; set; } = "";
        public int JoinedNumber { get; set; } = 1;
        public int Number { get; set; }
        public string Place { get; set; } = "";
        public string Date { get; set; }
        public string Time { get; set; } = "";
        public bool IsClosed { get; set; } = false;
        public Account Account { get; set; } = null!;
        
        public ICollection<JoinedAllPost> JoinedAllPosts { get; set; } = [];
    }
}