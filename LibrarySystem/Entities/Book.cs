using System.ComponentModel.DataAnnotations;
using LibrarySystem.Core.Interfaces;

namespace LibrarySystem.Entities;

public class Book: IBaseEntity
{
    public Guid Uuid { get; set; }

    [MaxLength(100)] 
    public string Genre { get; set; }

    [MaxLength(255)] 
    public string Title { get; set; }
    
    [MaxLength(100)] 
    public string Author { get; set; }
}