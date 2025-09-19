using LibrarySystem.Core.BaseEntities;
using LibrarySystem.Core.Interfaces;
using LibrarySystem.Entities;
using LibrarySystem.Repository.Interfaces;
using LibrarySystem.Service.Interfaces;

namespace LibrarySystem.Service;

public class UserBookService: BaseService<UserBook>, IUserBookService
{
    private readonly IUserBookRepository _userBookRepository;
    
    public UserBookService(IUserBookRepository repository) : base(repository)
    {
        _userBookRepository = repository;
    }
}