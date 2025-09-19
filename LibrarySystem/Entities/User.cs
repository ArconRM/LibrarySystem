using System.ComponentModel.DataAnnotations;
using LibrarySystem.Core.Interfaces;

namespace LibrarySystem.Entities;

public class User: IBaseEntity
{
    public Guid Uuid { get; set; }

    public string FullName { get; set; }

    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; set; }
    
    [Phone]
    [MaxLength(20)] 
    public string PhoneNumber { get; set; }
    

    public Subscription? Subscription { get; set; }
    
    public ICollection<UserBook> UserBooks { get; set; }
}