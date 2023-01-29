namespace WebAPI.Operations.BookOperations.Commands;

public class DeleteBookCommand
{
    public int ID { get; set; }
    private readonly BookStoreDbContext _dbContext;

    public DeleteBookCommand(BookStoreDbContext dbContext) {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        Book? book = _dbContext.Books!.SingleOrDefault(x => x.Id == ID);
        if(book is null){
            throw new InvalidOperationException("Book is not exists.");
        }
        _dbContext.Books!.Remove(book);
        _dbContext.SaveChanges();
    }
}