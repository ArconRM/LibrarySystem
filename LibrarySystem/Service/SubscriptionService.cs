using LibrarySystem.Core.BaseEntities;
using LibrarySystem.Core.Interfaces;
using LibrarySystem.Entities;
using LibrarySystem.Repository.Interfaces;
using LibrarySystem.Service.Interfaces;

namespace LibrarySystem.Service;

public class SubscriptionService: BaseService<Subscription>, ISubscriptionService
{
    private readonly ISubscriptionRepository _subscriptionRepository;
    
    public SubscriptionService(ISubscriptionRepository repository) : base(repository)
    {
        _subscriptionRepository = repository;
    }
}