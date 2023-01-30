namespace WebAPI.Operations.BookOperations.Commands.UpdateBook;

public class UpdateBookCommand
{
    public int ID { get; set; }
    public UpdateBookModel? Model { get; set; }
    private readonly BookStoreDbContext _dbContext;

    public UpdateBookCommand(BookStoreDbContext dbContext) {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        Book? book = _dbContext.Books!.SingleOrDefault(x => x.Id == ID);
        if(book is null){
            throw new InvalidOperationException("Book is not exists.");
        }

        // Checking which properties updated
        book.Title = Model!.Title != default ? Model.Title : book.Title;
        book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
        book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
        book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
        _dbContext.SaveChanges();
    }

    public void Validate()
    {
        UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
        validator.ValidateAndThrow(this);
    }
}

public class UpdateBookModel {
    public string? Title { get; set; }
    public GenreEnum GenreId { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishDate { get; set; }
}