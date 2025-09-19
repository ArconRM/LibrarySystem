namespace LibrarySystem.Dto.Responses;

public class UserResponse
{
    public Guid Uuid { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }
}