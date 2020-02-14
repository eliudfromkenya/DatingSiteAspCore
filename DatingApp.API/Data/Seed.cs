using System;
using System.Collections.Generic;
using System.Linq;
using DatingApp.Api.Data;
using DatingApp.API.Models;
using Newtonsoft.Json;

namespace DatingApp.API.Data
{
  public class Seed
  {
    private readonly DataContext _context;
    public Seed(DataContext context)
    {
      _context = context;
    }
    
    public void SeedUsers()
    {
      try
      {
        var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
        var users = JsonConvert.DeserializeObject<List<User>>(userData);

        foreach (var user in users)
        {
          byte[] hashed, salt;
          CreateHashedPassword("password", out hashed, out salt);

          user.Username = user.Username.ToLower();
          user.PasswordSalt = salt;
          user.PasswordHash = hashed;

          _context.Users.Add(user);
        }
        _context.SaveChanges();
        Console.Write(_context.Users.Count().ToString());
      }
      catch (System.Exception ex)
      {
        Console.Write(ex);
      }
    }

    private void CreateHashedPassword(string v, out byte[] hashed, out byte[] salt)
    {
      using (var hmac = new System.Security.Cryptography.HMACSHA512())
      {
        salt = hmac.Key;
        hashed = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("password"));
      }
    }
  }
}