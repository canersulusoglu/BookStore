namespace WebAPI.Operations.BookOperations.Queries;

public class GetBookByIdQuery
{
    public int ID {get; set;}
    private readonly BookStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetBookByIdQuery(BookStoreDbContext dbContext, IMapper mapper) {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public GetBookByIdViewModel Handle()
    {
        Book? book = _dbContext.Books!.Where(x => x.Id == ID).SingleOrDefault();
        if(book is null)
            throw new InvalidOperationException("Book is not exists.");
        return _mapper.Map<GetBookByIdViewModel>(book);
    }
}

public class GetBookByIdViewModel {
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Genre { get; set; }
    public int PageCount { get; set; }
    public string? PublishDate { get; set; }
}