namespace WebAPI.Operations.BookOperations.Commands;

public class UpdateBookPatchCommand
{
    public int ID { get; set; }
    public JsonPatchDocument<UpdateBookPatchModel>? Model { get; set; }
    private readonly BookStoreDbContext _dbContext;

    public UpdateBookPatchCommand(BookStoreDbContext dbContext) {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        Book? book = _dbContext.Books!.SingleOrDefault(x => x.Id == ID);
        if(book is null){
            throw new InvalidOperationException("Book is not exists.");
        }

        UpdateBookPatchModel updatedBook = new UpdateBookPatchModel();
        Model!.ApplyTo(updatedBook);

        // Checking which properties updated
        book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;
        book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
        book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
        book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;
        _dbContext.SaveChanges();
    }
}

public class UpdateBookPatchModel {
    public string? Title { get; set; }
    public GenreEnum GenreId { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishDate { get; set; }
}