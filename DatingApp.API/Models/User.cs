using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatingApp.API.Models
{
  [Table("tbl_system_users")]
  public class User
  {
    private int id;

    [Column("user_id")]
    [Key]
    public int Id { get => id; set => id = value; }
    [Column("username")]
    public string Username { get; set; }
    [Column("password_hash")]
    public byte[] PasswordHash { get; set; }
    [Column("password_salt")]
    public byte[] PasswordSalt { get; set; }
  }
}

