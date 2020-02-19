using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatingApp.API.Models
{
    [Table("tbl_users_likes")]
    public class Like
    {
         [Column ("like_id")]
         [Key]
        public int LikerId { get; set; }
         [Column ("likee_id")]
        public int LikeeId { get; set; }
        public virtual User Liker { get; set; }
        public virtual User Likee { get; set; }
    }
}