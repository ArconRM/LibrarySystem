namespace LibrarySystem.Dto.Responses;

public class BookResponse
{
    public Guid Uuid { get; set; }

    public string Genre { get; set; }
    
    public string Title { get; set; }
    
    public string Author { get; set; }
}