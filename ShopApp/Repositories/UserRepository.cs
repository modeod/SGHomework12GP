﻿using Microsoft.EntityFrameworkCore;
using ShopApp.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ShopDbContext _shopDbContext;
        
        public UserRepository(ShopDbContext context)
        {
            _shopDbContext = context;
        }

        public async Task<User?> GetByCredentials(string email, string password)
        {
            return await _shopDbContext.Users
                .FirstOrDefaultAsync(x => x.Email == email 
                                          && string.Equals(x.Password, password));
        }

        public async Task<User> AddUser(User user)
        {
            if (user is null)
            {
                throw new NullReferenceException("User can`t be null");
            }
            try
            {
                await _shopDbContext.Users.AddAsync(user);
                await _shopDbContext.SaveChangesAsync();
                return _shopDbContext.Users.First(u => u.Id == user.Id);
            }
            catch (DbUpdateException)
            {
                throw new ArgumentException("Couldn`t add user");
            }
        }

        public async Task<User> Delete(int id)
        {
            var user = await _shopDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                throw new ArgumentException("Wrong id");
            }
            try
            {
                _shopDbContext.Users.Remove(user);
                await _shopDbContext.SaveChangesAsync();
                return user;
            }
            catch (DbUpdateException)
            {
                throw new Exception("Couldn`t delete user");
            }
        }

        public async Task<bool> DoesUserExist(string email, string password)
        {
            return await _shopDbContext.Users
                .AnyAsync(x => 
                    x.Email == email 
                    && string.Equals(x.Password, password));
        }

        public async Task<List<User>> GetAll()
        {
            return await _shopDbContext.Users.ToListAsync();
        }

        public async Task<User?> GetById(int id)
        {
            return await _shopDbContext.Users.FindAsync(id);
        }

        public async Task<User> Update(User user)
        {
            if (user is null)
            {
                throw new NullReferenceException("User can`t be null");
            }
            try
            {
                _shopDbContext.Entry(user).State = EntityState.Modified;
                await _shopDbContext.SaveChangesAsync();
                return _shopDbContext.Users.First(u => u.Id == user.Id);
            }
            catch (DbUpdateException)
            {
                throw new ArgumentException("Couldn`t update user");
            }
        }
    }
}
