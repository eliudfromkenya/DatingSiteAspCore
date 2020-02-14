using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatingApp.API.Models {
  [Table ("tbl_system_users")]
  public class User {
    private int id;

    [Column ("user_id")]
    [Key]
    public int Id { get => id; set => id = value; }

    [Column ("username")]
    public string Username { get; set; }

    [Column ("password_hash")]
    public byte[] PasswordHash { get; set; }

    [Column ("password_salt")]
    public byte[] PasswordSalt { get; set; }

    [Column ("gender")]
    public string Gender { get; set; }

    [Column ("birth_date")]
    public DateTime DateOfBirth { get; set; }

    [Column ("known_as")]
    public string KnownAs { get; set; }

    [Column ("date_created")]
    public DateTime Created { get; set; }

    [Column ("when_last_active")]
    public DateTime LastActive { get; set; }

    [Column ("introduction")]
    public string Introduction { get; set; }

    [Column ("looking_for")]
    public string LookingFor { get; set; }

    [Column ("interests")]
    public string Interests { get; set; }

    [Column ("city")]
    public string City { get; set; }

    [Column ("country")]
    public string Country { get; set; }
    public ICollection<Photo> Photos { get; set; }
  }
}