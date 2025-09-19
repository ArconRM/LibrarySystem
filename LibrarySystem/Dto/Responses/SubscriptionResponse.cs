namespace LibrarySystem.Dto.Responses;

public class SubscriptionResponse
{
    public Guid Uuid { get; set; }
    
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal Price { get; set; }
}