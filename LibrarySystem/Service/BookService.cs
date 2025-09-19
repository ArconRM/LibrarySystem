using LibrarySystem.Core.BaseEntities;
using LibrarySystem.Core.Interfaces;
using LibrarySystem.Entities;
using LibrarySystem.Repository.Interfaces;
using LibrarySystem.Service.Interfaces;

namespace LibrarySystem.Service;

public class BookService: BaseService<Book>, IBookService
{
    private readonly IBookRepository _bookRepository;
    
    public BookService(IBookRepository repository) : base(repository)
    {
        _bookRepository = repository;
    }
}