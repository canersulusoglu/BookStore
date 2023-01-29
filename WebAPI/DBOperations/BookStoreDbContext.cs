namespace WebAPI.DBOperations;

public class BookStoreDbContext : DbContext {
    public DbSet<Book>? Books {get; set;}
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) {}
}