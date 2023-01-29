namespace WebAPI.Operations.BookOperations.Queries;

public class GetBookByIdQuery
{
    public int ID {get; set;}
    private readonly BookStoreDbContext _dbContext;

    public GetBookByIdQuery(BookStoreDbContext dbContext) {
        _dbContext = dbContext;
    }

    public GetBookByIdViewModel Handle()
    {
        Book? book = _dbContext.Books!.Where(x => x.Id == ID).SingleOrDefault();
        if(book is null)
            throw new InvalidOperationException("Book is not exists.");
        return new GetBookByIdViewModel{
            Id = book.Id,
            Title = book.Title!,
            Genre = ((GenreEnum)book.GenreId).ToString(),
            PageCount = book.PageCount,
            PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy")
        };
    }
}

public class GetBookByIdViewModel {
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Genre { get; set; }
    public int PageCount { get; set; }
    public string? PublishDate { get; set; }
}