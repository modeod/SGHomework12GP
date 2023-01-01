using ShopApp.Entities.RootEntity;
using ShopApp.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Repositories
{
    internal interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User?> GetById(int id);
        Task<bool> AddUser(User user);
        Task<bool> Update(User user);
        Task<bool> Delete(User user);
    }
}
