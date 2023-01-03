using ShopApp.Entities.UserEntity;

namespace ShopApp.Services.Interfaces;

public interface ITokenHandler
{
    Task<string> CreateTokenAsync(User user);
}