using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Contracts {
  public interface IRepository {
    void Add<T> (T entity) where T : class;
    void Delete<T> (T entity) where T : class;
    Task<bool> SaveAll ();
    Task<IEnumerable<User>> GetUsers ();
    Task<User> GetUser (int userId);
    Task<Photo> GetPhoto (int photoId);
    Task<Photo> GetMainPhotoForUser (int userId);
    public Task<User> GetUser (int id, bool isCurrentUser); 
  }
}