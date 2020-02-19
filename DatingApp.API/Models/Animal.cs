using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatingApp.API.Models
{
    [Table("tbl_animals")]
    public class Animal
    {
        [Column("animal_id")]
        public int Id { get; set; } 
        [Column("animal_name")]
        public string Name { get; set; }
        [Column("date_of_birth")]
        public DateTime DateOfBirth { get; set; }
    }
}