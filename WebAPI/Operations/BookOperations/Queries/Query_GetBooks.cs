namespace WebAPI.Operations.BookOperations.Queries;

public class GetBooksQuery
{
    private readonly BookStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper) {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<GetBooksViewModel> Handle()
    {
        List<GetBooksViewModel> vm = _mapper.Map<List<GetBooksViewModel>>(_dbContext.Books!.ToList<Book>());
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