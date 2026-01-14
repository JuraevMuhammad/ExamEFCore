using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Date;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : DbContext(option)
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<BorrowRecord> BorrowRecords { get; set; }
    public DbSet<LibraryCard> LibraryCards { get; set; }
    public DbSet<Student> Students { get; set; }
}