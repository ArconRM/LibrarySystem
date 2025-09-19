using LibrarySystem.Core.BaseEntities;
using LibrarySystem.Entities;
using LibrarySystem.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repository;

public class BookRepository: BaseRepository<Book>, IBookRepository
{
    private readonly LibraryDbContext _context;
    
    public BookRepository(LibraryDbContext context) : base(context)
    {
        _context = context;
    }
}