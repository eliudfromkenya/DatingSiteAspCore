﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DatingApp.Api.Models;
using DatingApp.API.Models;

namespace DatingApp.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options ) : base(options){  }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<User> Users { get; set; }  
    }
}