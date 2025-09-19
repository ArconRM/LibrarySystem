namespace LibrarySystem.Dto.Requests;

public class AddNewBookRequest
{
    public string Genre { get; set; }
    
    public string Title { get; set; }
    
    public string Author { get; set; }
}