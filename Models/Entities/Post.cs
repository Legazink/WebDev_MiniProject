using System.ComponentModel.DataAnnotations.Schema;

namespace WebDev_MiniProject.Models.Entities
{
    public class Post
    {
        public Guid PostId { get; set; }
        public string GameName { get; set; } = "";
        public int JoinedNumber { get; set; }
        public int Number { get; set; }
        public string Place { get; set; } = "";
        public string Date { get; set; } = "";
        public string Time { get; set; } = "";
        public string AccountID { get; set; }
 
        [ForeignKey("AccountID")]
        public virtual Account Account { get; set; }
        

    }
}