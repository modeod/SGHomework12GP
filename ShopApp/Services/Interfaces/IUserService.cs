using ShopApp.Entities.UserEntity;

namespace ShopApp.Services.Interfaces;

public interface IUserService
{
    Task<User> RegisterUser(User user);
    Task<string> LoginUser(string email, string password);
}