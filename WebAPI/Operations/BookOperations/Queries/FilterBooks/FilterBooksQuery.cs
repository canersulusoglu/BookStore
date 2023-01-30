namespace WebAPI.Operations.BookOperations.Queries.FilterBooks;

public class FilterBooksQuery
{
    public FilterBooksModel? Model { get; set; }
    private readonly BookStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public FilterBooksQuery(BookStoreDbContext dbContext, IMapper mapper) {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<FilterBooksViewModel> Handle()
    {
        var filter = _dbContext.Books!.AsQueryable();
        List<Book> bookList = new List<Book>();

        // Filtering
        if (Model!.Title is not null)
            filter = filter.Where(x => x.Title == Model!.Title);
        if(Model!.MinPageCount is not null)
            filter = filter.Where(x => x.PageCount >= Model!.MinPageCount);
        if(Model!.MaxPageCount is not null)
            filter = filter.Where(x => x.PageCount <= Model!.MaxPageCount);
        if(Model!.PublishDateFrom is not null)
            filter = filter.Where(x => x.PublishDate >= Model!.PublishDateFrom);
        if(Model!.PublishDateTo is not null)
            filter = filter.Where(x => x.PublishDate <= Model!.PublishDateTo);

        bookList = filter.ToList<Book>();
        
        // Ordering
        if(Model!.OrderBy is not null){
            // Split order parameters
            List<string> orderParams = Convert.ToString(Model!.OrderBy).Split(',').ToList<string>();
            if(orderParams.Count > 0){
                foreach (var order in orderParams)
                {
                    // Finding order type ascending or descending default is ascending.
                    List<string> splitedOrder = order.Split('|').ToList<string>();
                    string orderKey = splitedOrder[0];
                    string orderType = splitedOrder.ElementAtOrDefault(1) != null ? splitedOrder[1] : "asc";
                    
                    // Checking order property whether exists then ordering.
                    PropertyInfo? prop = typeof(Book).GetProperty(orderKey);
                    if(prop is not null){
                        if(orderType == "asc"){
                            bookList = bookList.OrderBy(x => prop.GetValue(x)).ToList<Book>();
                        }else{
                            bookList = bookList.OrderByDescending(x => prop.GetValue(x)).ToList<Book>();
                        }
                    }
                }
            }
        }

        List<FilterBooksViewModel> vm = _mapper.Map<List<FilterBooksViewModel>>(bookList);
        return vm;
    }

    public void Validate()
    {
        FilterBooksQueryValidator validator = new FilterBooksQueryValidator();
        validator.ValidateAndThrow(this);
    }
}

public class FilterBooksModel {
    public string? Title { get; set; }
    public int? MinPageCount { get; set; }
    public int? MaxPageCount { get; set; }
    public DateTime? PublishDateFrom { get; set; }
    public DateTime? PublishDateTo { get; set; }
    public string? OrderBy { get; set; }
}

public class FilterBooksViewModel {
    public string? Title { get; set; }
    public string? Genre { get; set; }
    public int PageCount { get; set; }
    public string? PublishDate { get; set; }
}