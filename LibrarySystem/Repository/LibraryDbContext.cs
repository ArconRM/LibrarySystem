using System.Reflection;
using LibrarySystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repository;

public class LibraryDbContext: DbContext
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<Book> Books { get; set; }

    public DbSet<Subscription> Subscriptions { get; set; }

    public DbSet<UserBook> UserBooks { get; set; }
    
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}