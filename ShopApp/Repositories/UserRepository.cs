using Microsoft.EntityFrameworkCore;
using ShopApp.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private ShopDbContext _shopDbContext;
        public UserRepository(ShopDbContext context)
        {
            _shopDbContext = context;
        }
        public async Task<bool> AddUser(User user)
        {
            try
            {
                await _shopDbContext.Users.AddAsync(user);
                await _shopDbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<bool> Delete(User user)
        {
            try
            {
                _shopDbContext.Users.Remove(user);
                await _shopDbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<List<User>> GetAll()
        {
            return await _shopDbContext.Users.ToListAsync();
        }

        public async Task<User?> GetById(int id)
        {
            return await _shopDbContext.Users.FindAsync(id);
        }

        public async Task<bool> Update(User user)
        {
            try
            {
                _shopDbContext.Entry(user).State = EntityState.Modified;
                await _shopDbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
    }
}
