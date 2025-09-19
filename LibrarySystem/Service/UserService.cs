using LibrarySystem.Core.BaseEntities;
using LibrarySystem.Core.Interfaces;
using LibrarySystem.Entities;
using LibrarySystem.Repository.Interfaces;
using LibrarySystem.Service.Interfaces;

namespace LibrarySystem.Service;

public class UserService : BaseService<User>, IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ISubscriptionRepository _subscriptionRepository;

    public UserService(IUserRepository userRepository, ISubscriptionRepository subscriptionRepository) : base(userRepository)
    {
        _userRepository = userRepository;
        _subscriptionRepository = subscriptionRepository;
    }

    public async Task<User> SetUserSubscription(Guid userUuid, Subscription subscription, CancellationToken token)
    {
        // Получаем пользователя с текущей подпиской для проверки
        var user = await _userRepository.GetUserWithSubscription(userUuid, token);
        if (user == null)
            throw new InvalidOperationException("User not found");
        
        // Пользователь может иметь только одну активную подписку
        if (user.Subscription is not null)
            throw new InvalidOperationException("User has already subscription");

        // Создаем новую подписку на основе переданных данных
        var newSubscription = new Subscription
        {
            Uuid = Guid.NewGuid(),
            StartDate = subscription.StartDate,
            EndDate = subscription.EndDate,
            Price = subscription.Price,
            UserUuid = userUuid
        };
        await _subscriptionRepository.CreateAsync(newSubscription, token);
        
        return await _userRepository.GetUserWithAllInfo(userUuid, token);
    }
    
    public async Task<User?> GetUserWithAllInfo(Guid userUuid, CancellationToken token)
    {
        return await _userRepository.GetUserWithAllInfo(userUuid, token);
    }
}