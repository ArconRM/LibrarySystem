using LibrarySystem.Core.Interfaces;

namespace LibrarySystem.Entities;

public class UserBook: IBaseEntity
{
    public Guid Uuid { get; set; }

    public Guid UserUuid { get; set; }
    public User User { get; set; }

    public Guid BookUuid { get; set; }
    public Book Book { get; set; }

    public DateTime TakenAt { get; set; }
    public DateTime? ReturnedAt { get; set; }
}