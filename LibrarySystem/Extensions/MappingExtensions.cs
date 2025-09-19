using LibrarySystem.Dto.Requests;
using LibrarySystem.Dto.Responses;
using LibrarySystem.Entities;

namespace LibrarySystem.Extensions;

public static class MappingExtensions
{
    public static Book ToEntity(this AddNewBookRequest request)
    {
        return new Book
        {
            Author = request.Author,
            Genre = request.Genre,
            Title = request.Title
        };
    }

    public static BookResponse ToResponse(this Book entity)
    {
        return new BookResponse
        {
            Uuid = entity.Uuid,
            Author = entity.Author,
            Genre = entity.Genre,
            Title = entity.Title
        };
    }

    public static User ToEntity(this UserRequest request)
    {
        return new User
        {
            Email = request.Email,
            FullName = request.FullName,
            PhoneNumber = request.PhoneNumber
        };
    }

    public static User ToEntity(this UpdateUserRequest request)
    {
        return new User
        {
            Uuid = request.Uuid,
            Email = request.Email,
            FullName = request.FullName,
            PhoneNumber = request.PhoneNumber
        };
    }

    public static UserResponse ToResponse(this User entity)
    {
        return new UserResponse
        {
            Uuid = entity.Uuid,
            FullName = entity.FullName,
            Email = entity.Email,
            PhoneNumber = entity.PhoneNumber
        };
    }

    public static FullUserResponse ToFullResponse(this User entity)
    {
        return new FullUserResponse
        {
            Uuid = entity.Uuid,
            FullName = entity.FullName,
            Email = entity.Email,
            PhoneNumber = entity.PhoneNumber,
            Subscription = entity.Subscription is not null
                ? new SubscriptionResponse
                {
                    Uuid = entity.Subscription.Uuid,
                    StartDate = entity.Subscription.StartDate,
                    EndDate = entity.Subscription.EndDate,
                    Price = entity.Subscription.Price,
                }
                : null,
            UserBooks = entity.UserBooks.Select(ub => new UserBookResponse
            {
                Uuid = ub.Uuid,
                Book = ub.Book.ToResponse(),
                TakenAt = ub.TakenAt,
                ReturnedAt = ub.ReturnedAt
            }).ToList()
        };
    }

    public static UserBookResponse ToResponse(this UserBook entity)
    {
        return new UserBookResponse
        {
            Uuid = entity.Uuid,
            Book = entity.Book.ToResponse(),
            TakenAt = entity.TakenAt,
            ReturnedAt = entity.ReturnedAt
        };
    }

    public static Subscription ToEntity(this SetUserSubscriptionRequest request)
    {
        return new Subscription
        {
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Price = request.Price
        };
    }
}