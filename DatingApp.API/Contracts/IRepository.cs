using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Helpers;
using DatingApp.API.Models;

namespace DatingApp.API.Contracts {
  public interface IRepository {
    void Add<T> (T entity) where T : class;
    void Delete<T> (T entity) where T : class;
    Task<bool> SaveAll ();
    Task<PagedList<User>> GetUsers (UserParams userParams);
    Task<User> GetUser (int userId);
    Task<Photo> GetPhoto (int photoId);
    Task<Photo> GetMainPhotoForUser (int userId);
    Task<Like> GetLike(int userId, int recipientId);
    Task<User> GetUser (int id, bool isCurrentUser);
    Task<Message> GetMessage (int id);  
    Task<PagedList<Message>> GetMessagesForUser (MessageParams messageParams);
    Task<IEnumerable<Message>> GetMessageThread(int userId, int recepientId);

  }
}