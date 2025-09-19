using LibrarySystem.Core.BaseEntities;
using LibrarySystem.Core.Interfaces;
using LibrarySystem.Entities;
using LibrarySystem.Repository.Interfaces;
using LibrarySystem.Service.Interfaces;

namespace LibrarySystem.Service;

public class UserBookService : BaseService<UserBook>, IUserBookService
{
    private readonly IUserBookRepository _userBookRepository;
    private readonly IUserRepository _userRepository;

    public UserBookService(IUserBookRepository userBookRepository, IUserRepository userRepository) : base(
        userBookRepository)
    {
        _userBookRepository = userBookRepository;
        _userRepository = userRepository;
    }

    public async Task<UserBook> AddNewUserBookAsync(Guid userUuid, Guid bookUuid, CancellationToken token)
    {
        var user = await _userRepository.GetUserWithSubscription(userUuid, token);
        if (user is null)
            throw new InvalidOperationException("User not found");

        if (user.Subscription is null)
            throw new InvalidOperationException("User doesn't have a subscription");

        var activeUserBooks = await _userBookRepository.GetActiveUserBooksAsync(userUuid, token);
        if (activeUserBooks.Count >= 5)
            throw new InvalidOperationException("User already has 5 active books");
        
        var isBookTaken = await _userBookRepository.IsBookTakenAsync(bookUuid, token);
        if (isBookTaken)
            throw new InvalidOperationException("Book is already taken");

        var userBook = new UserBook
        {
            UserUuid = userUuid,
            BookUuid = bookUuid,
            TakenAt = DateTime.UtcNow
        };
        var createdUserBook = await _userBookRepository.CreateAsync(userBook, token);
        
        return await _userBookRepository.GetUserBookWithBook(createdUserBook.Uuid, token);
    }

    public async Task<UserBook> ReturnUserBookAsync(Guid userUuid, Guid bookUuid, CancellationToken token)
    {
        var user = await _userRepository.GetUserWithSubscription(userUuid, token);
        if (user is null)
            throw new InvalidOperationException("User not found");
        
        var activeUserBooks = await _userBookRepository.GetActiveUserBooksAsync(userUuid, token);
        var userBook = activeUserBooks.FirstOrDefault(x => x.BookUuid == bookUuid);
        if (userBook is null)
            throw new InvalidOperationException("User book not found");
        
        userBook.ReturnedAt ??= DateTime.UtcNow;
        await _userBookRepository.UpdateAsync(userBook, token);

        return await _userBookRepository.GetUserBookWithBook(userBook.Uuid, token);
    }
}