namespace LibrarySystem.Dto.Requests;

public class UpdateUserRequest: UserRequest
{
    public Guid Uuid { get; set; }
}