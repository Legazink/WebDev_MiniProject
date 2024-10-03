using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDev_MiniProject.Models.Entities
{
    public class JoinedAllPost
    {
        [Key]
        public int Id { get; set; }

        public Account Account { get; set; } = null!;

        public Post Post { get; set; } = null!;
    }
}
