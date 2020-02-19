using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatingApp.API.Models
{
    public class Message
    { 
        [Column ("message_id")]
        [Key]
        public int Id { get; set; }
        [Column ("sender_id")]
        public int SenderId { get; set; }
        public virtual User Sender { get; set; }
        [Column ("receipient_id")]
        public int RecipientId { get; set; }
        public virtual User Recipient { get; set; }
        [Column ("message_content")]
        public string Content { get; set; }
        [Column ("message_is_read")]
        public bool IsRead { get; set; }
        [Column ("message_date_was_read")]
        public DateTime? DateRead { get; set; }
        [Column ("message_sent")]
        public DateTime MessageSent { get; set; }
        [Column ("sender_deleted")]
        public bool SenderDeleted { get; set; }
        [Column ("recipient_deleted")]
        public bool RecipientDeleted { get; set; }
    }
}