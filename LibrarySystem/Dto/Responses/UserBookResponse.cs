namespace LibrarySystem.Dto.Responses;

public class UserBookResponse
{
    public Guid Uuid { get; set; }

    public BookResponse Book { get; set; }

    public DateTime TakenAt { get; set; }
    public DateTime? ReturnedAt { get; set; }
}