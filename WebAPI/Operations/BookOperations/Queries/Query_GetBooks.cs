namespace WebAPI.Operations.BookOperations.Queries;

public class GetBooksQuery
{
    private readonly BookStoreDbContext _dbContext;

    public GetBooksQuery(BookStoreDbContext dbContext) {
        _dbContext = dbContext;
    }

    public List<GetBooksViewModel> Handle()
    {

        List<GetBooksViewModel> vm = new List<GetBooksViewModel>();
        foreach(Book book in _dbContext.Books!.ToList<Book>()){
            vm.Add(new GetBooksViewModel{
                Id = book.Id,
                Title = book.Title!,
                Genre = ((GenreEnum)book.GenreId).ToString(),
                PageCount = book.PageCount,
                PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy")
            });
        }
        return vm;
    }
}

public class GetBooksViewModel {
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Genre { get; set; }
    public int PageCount { get; set; }
    public string? PublishDate { get; set; }
}