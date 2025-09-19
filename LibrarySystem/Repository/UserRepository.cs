using LibrarySystem.Core.BaseEntities;
using LibrarySystem.Entities;
using LibrarySystem.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repository;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly LibraryDbContext _context;

    public UserRepository(LibraryDbContext context) : base(context)
    {
        _context = context;
    }
}