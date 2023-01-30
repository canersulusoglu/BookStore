namespace WebAPI.Operations.BookOperations.Commands.CreateBook;

public class CreateBookCommand
{
    public CreateBookModel? Model { get; set; }
    private readonly BookStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateBookCommand(BookStoreDbContext dbContext, IMapper mapper) {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        Book? book = _dbContext.Books!.SingleOrDefault(x => x.Title == Model!.Title);
        if (book is not null){
            throw new InvalidOperationException("Book is already exists.");
        }
        
        book = _mapper.Map<Book>(Model);
        _dbContext.Books!.Add(book);
        _dbContext.SaveChanges();
    }

    public void Validate()
    {
        CreateBookCommandValidator validator = new CreateBookCommandValidator();
        validator.ValidateAndThrow(this);
    }
}

public class CreateBookModel {
    public string? Title { get; set; }
    public GenreEnum GenreId { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishDate { get; set; }
}