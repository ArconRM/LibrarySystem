namespace LibrarySystem.Dto.Requests;

public class UserBookRequest
{
    public Guid UserUuid { get; set; }

    public Guid BookUuid { get; set; }
}