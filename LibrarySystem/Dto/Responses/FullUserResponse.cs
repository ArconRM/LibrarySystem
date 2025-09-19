namespace LibrarySystem.Dto.Responses;

public class FullUserResponse
{
    public Guid Uuid { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public SubscriptionResponse? Subscription { get; set; }
    
    public ICollection<UserBookResponse> UserBooks { get; set; }
}