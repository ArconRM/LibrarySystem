using System.ComponentModel.DataAnnotations;
using LibrarySystem.Core.Interfaces;

namespace LibrarySystem.Entities;

public class Subscription: IBaseEntity
{
    public Guid Uuid { get; set; }
    
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal Price { get; set; }

    
    public Guid UserUuid { get; set; }
    public User User { get; set; }
}