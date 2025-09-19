using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibrarySystem.Entities.EntityConfiguration;

public class BookConfiguration: IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b => b.Uuid);

        builder.Property(b => b.Uuid)
            .ValueGeneratedOnAdd();

        builder.Property(b => b.Title)
            .IsRequired();
        
        builder.Property(b => b.Author)
            .IsRequired();
    }
}