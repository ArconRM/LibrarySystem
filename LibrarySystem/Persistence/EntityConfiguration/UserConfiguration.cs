using LibrarySystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibrarySystem.Persistence.EntityConfiguration;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Uuid);

        builder.Property(u => u.Uuid)
            .ValueGeneratedOnAdd();
        
        builder.Property(u => u.FullName)
            .IsRequired();

        builder.Property(u => u.Email)
            .IsRequired();

        // Связь User -> UserBooks (один ко многим)
        builder
            .HasMany(u => u.UserBooks)
            .WithOne(ub => ub.User)
            .HasForeignKey(ub => ub.UserUuid);
        
        builder.HasIndex(u => u.Email)
            .IsUnique();
    }
}