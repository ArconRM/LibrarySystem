using LibrarySystem.Core.BaseEntities;
using LibrarySystem.Core.Interfaces;
using LibrarySystem.Entities;
using LibrarySystem.Repository.Interfaces;
using LibrarySystem.Service.Interfaces;

namespace LibrarySystem.Service;

public class UserService: BaseService<User>, IUserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository repository) : base(repository)
    {
        _userRepository = repository;
    }
}