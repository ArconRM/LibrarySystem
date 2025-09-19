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
}