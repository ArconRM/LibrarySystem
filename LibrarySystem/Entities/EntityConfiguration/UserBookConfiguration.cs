using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibrarySystem.Entities.EntityConfiguration;

public class UserBookConfiguration: IEntityTypeConfiguration<UserBook>
{
    public void Configure(EntityTypeBuilder<UserBook> builder)
    {
        builder.HasKey(ub => ub.Uuid);
        
        builder.Property(ub => ub.Uuid)
            .ValueGeneratedOnAdd();
        
        builder
            .HasOne(ub => ub.User)
            .WithMany(u => u.UserBooks)
            .HasForeignKey(ub => ub.UserUuid);
        
        builder
            .HasOne(ub => ub.Book)
            .WithMany()
            .HasForeignKey(ub => ub.BookUuid);
    }
}