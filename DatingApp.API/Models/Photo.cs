using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatingApp.API.Models {
    public class Photo {

        [Column ("photo_id")]
        [Key]
        public int Id { get; set; }

        [Column ("photo_url")]
        public string Url { get; set; }

        [Column ("descrition")]
        public string Description { get; set; }

        [Column ("date_added")]
        public DateTime DateAdded { get; set; }

        [Column ("public_cloudinary_id")]
        public string PublicId { get; set; }

        [Column ("is_profile_main_photo")]
        public bool IsMain { get; set; }

        public User User { get; set; }

        [Column ("user_id")]
        public int UserId { get; set; }
    }
}