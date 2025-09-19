using LibrarySystem.Core.BaseEntities;
using LibrarySystem.Entities;
using LibrarySystem.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repository;

public class UserBookRepository: BaseRepository<UserBook>, IUserBookRepository
{
    private readonly LibraryDbContext _context;
    
    public UserBookRepository(LibraryDbContext context) : base(context)
    {
        _context = context;
    }
}