using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Api.Data;
using DatingApp.API.Contracts;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Repositories {
  public class Repository : IRepository {
    private readonly DataContext _context;
    public Repository (DataContext context) {
      _context = context;
    }
    public void Add<T> (T entity) where T : class {
      _context.Add (entity);
    }

    public void Delete<T> (T entity) where T : class {
      _context.Remove (entity);
    }

    public async Task<Photo> GetPhoto (int photoId) {
      return await _context.Photos
        .FirstOrDefaultAsync (p => p.Id == photoId);
    }

    public async Task<User> GetUser (int userId) {
      Console.Write (userId);
      return await _context.Users.Include (p => p.Photos).FirstOrDefaultAsync (x => x.Id == userId);
    }
   public async Task<Photo> GetMainPhotoForUser(int userId)
        {
            return await _context.Photos.Where(u => u.UserId == userId)
                .FirstOrDefaultAsync(p => p.IsMain);
        }

  public async Task<User> GetUser(int id, bool isCurrentUser)
        {
            var query = _context.Users.AsQueryable();

            if (isCurrentUser)
                query = query.IgnoreQueryFilters();

            var user = await query.FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }
    public async Task<IEnumerable<User>> GetUsers () {
      return await _context.Users.Include (p => p.Photos).ToListAsync ();
    }

    public async Task<bool> SaveAll () {
      return await _context.SaveChangesAsync () > 0;
    }
  }
}