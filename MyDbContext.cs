using WebApplication1.model;

namespace WebApplication1;

using Microsoft.EntityFrameworkCore;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options): base(options) {}
    
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Author>().HasData(
            new Author {Id = 1, FirstName = "Rana", LastName = "Masud"},
            new Author{Id = 2, FirstName = "Mohammad", LastName = "Mohammad"}
        );

        modelBuilder.Entity<Book>().HasData(
            new Book {BookId = 1, AuthorId = 1, Title = "Demo"},
            new Book {BookId = 2, AuthorId = 2, Title = "Demo -2"}
            );
    }
}