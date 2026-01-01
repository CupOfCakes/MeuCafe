using Domain.Repositories;
using Domain.Entities;

namespace Application.UseCases.Users;

public class ListUsersUseCase
{
    private readonly IUserRepository _userRepository;

    public ListUsersUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> ExecuteAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users;
    }
}
