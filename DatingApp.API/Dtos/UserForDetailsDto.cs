using System;
using System.Collections.Generic;
using DatingApp.API.Models;

namespace DatingApp.API.Dtos
{
    public class UserForDetailsDto
    {
    public int Id { get; set; }    
    public string Username { get; set; }    
    public int Age { get; set; }    
    public DateTime DateOfBirth { get; set; }    
    public string KnownAs { get; set; }    
    public DateTime Created { get; set; }    
    public DateTime LastActive { get; set; }   
    public string Introduction { get; set; }    
    public string LookingFor { get; set; }    
    public string Interests { get; set; }    
    public string City { get; set; }    
    public string Country { get; set; }
    public string PhotoURL { get; set; }
    public ICollection<PhotoForDetailDto> Photos { get; set; }
    }
}