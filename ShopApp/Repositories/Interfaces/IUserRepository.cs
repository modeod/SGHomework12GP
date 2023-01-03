using ShopApp.Entities.RootEntity;
using ShopApp.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User?> GetById(int id);
        Task<User?> GetByCredentials(string email, string password);
        Task<User> AddUser(User user);
        Task<User> Update(User user);
        Task<User> Delete(int id);
        Task<bool> DoesUserExist(string email, string password);
    }
}
