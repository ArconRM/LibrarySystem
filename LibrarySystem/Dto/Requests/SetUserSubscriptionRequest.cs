namespace LibrarySystem.Dto.Requests;

public class SetUserSubscriptionRequest
{
    public Guid UserUuid { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
    
    public decimal Price { get; set; }
}