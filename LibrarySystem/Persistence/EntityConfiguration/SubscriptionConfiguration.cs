using LibrarySystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibrarySystem.Persistence.EntityConfiguration;

public class SubscriptionConfiguration: IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.HasKey(s => s.Uuid);

        builder.Property(s => s.Uuid)
            .ValueGeneratedOnAdd();
        
        // Связь Subscription -> User (один к одному)
        builder
            .HasOne(s => s.User)
            .WithOne(u => u.Subscription)
            .HasForeignKey<Subscription>(s => s.UserUuid)
            .OnDelete(DeleteBehavior.Cascade);
    }
}