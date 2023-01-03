using ShopApp.Entities.UserEntity;
using ShopApp.Repositories;
using ShopApp.Services.Interfaces;

namespace ShopApp.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenHandler _tokenHandler;

    public UserService(IUserRepository userRepository, ITokenHandler tokenHandler)
    {
        _userRepository = userRepository;
        _tokenHandler = tokenHandler;
    }

    public async Task<User> RegisterUser(User user)
    {
        return await _userRepository.AddUser(user);
    }

    public async Task<string> LoginUser(string email, string password)
    {
        var isCorrectUser = await _userRepository.DoesUserExist(email, password);
        if (!isCorrectUser) throw new ArgumentException();
        var user = await _userRepository.GetByCredentials(email, password);
        return await _tokenHandler.CreateTokenAsync(user!);
    }
}