using LibrarySystem.Core.BaseEntities;
using LibrarySystem.Entities;
using LibrarySystem.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repository;

public class SubscriptionRepository: BaseRepository<Subscription>, ISubscriptionRepository
{
    private readonly LibraryDbContext _context;
    
    public SubscriptionRepository(LibraryDbContext context) : base(context)
    {
        _context = context;
    }
}