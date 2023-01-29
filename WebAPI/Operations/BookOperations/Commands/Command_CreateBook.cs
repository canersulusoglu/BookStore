namespace WebAPI.Operations.BookOperations.Commands;

public class CreateBookCommand
{
    public CreateBookModel? Model { get; set; }
    private readonly BookStoreDbContext _dbContext;

    public CreateBookCommand(BookStoreDbContext dbContext) {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        Book? book = _dbContext.Books!.SingleOrDefault(x => x.Title == Model!.Title);
        if (book is not null){
            throw new InvalidOperationException("Book is already exists.");
        }
        book = new Book();
        book.Title = Model!.Title;
        book.GenreId = Model.GenreId;
        book.PageCount = Model.PageCount;
        book.PublishDate = Model.PublishDate;
        _dbContext.Books!.Add(book);
        _dbContext.SaveChanges();
    }
}

public class CreateBookModel {
    public string? Title { get; set; }
    public GenreEnum GenreId { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishDate { get; set; }
}