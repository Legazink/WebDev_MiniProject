using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDev_MiniProject.Models.Entities
{
    public class JoinedAllPost
    {
        [Key]
        public int Id { get; set; }

        public string AccountID { get; set; }

        public Guid PostID { get; set; }
        [ForeignKey("PostID")]
        public virtual Post Post { get; set; }
    }
}
