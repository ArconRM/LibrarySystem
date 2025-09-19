using LibrarySystem.Core.BaseEntities;
using LibrarySystem.Entities;
using LibrarySystem.Persistence.Repository.Interfaces;

namespace LibrarySystem.Persistence.Repository;

public class SubscriptionRepository: BaseRepository<Subscription>, ISubscriptionRepository
{
    private readonly LibraryDbContext _context;
    
    public SubscriptionRepository(LibraryDbContext context) : base(context)
    {
        _context = context;
    }
}