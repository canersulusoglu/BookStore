using WebAPI.Operations.BookOperations.Commands;
using WebAPI.Operations.BookOperations.Queries;
namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]s")]
public class BookController : ControllerBase {
    private readonly BookStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public BookController(BookStoreDbContext dbContext, IMapper mapper){
        _dbContext = dbContext;
        _mapper = mapper;
    }
    /// <summary>
    /// Gets all books.
    /// </summary>
    /// <response code="200">Returns all books.</response>
    [HttpGet]
    public IActionResult GetBooks() {
        GetBooksQuery query = new GetBooksQuery(_dbContext, _mapper);
        var result = query.Handle();
        return Ok(result);
    }

    /// <summary>
    /// Gets one book by id.
    /// </summary>
    /// <response code="200">Returns Book with specific id.</response>
    [HttpGet("{id}")]
    public IActionResult GetBookById([FromRoute] int id) {
        GetBookByIdQuery query = new GetBookByIdQuery(_dbContext, _mapper);
        try
        {
            query.ID = id;
            var result = query.Handle();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Add new book.
    /// </summary>
    /// <response code="400">Returns 400 status code, if book name is already exists.</response>
    /// <response code="200">Returns 200 status code, if book successfully added.</response>
    [HttpPost]
    public IActionResult CreateBook([FromBody] CreateBookModel newBook){
        CreateBookCommand command = new CreateBookCommand(_dbContext, _mapper);
        try
        {
            command.Model = newBook;
            command.Handle();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();
    }

    /// <summary>
    /// Updates book by id.
    /// </summary>
    /// <response code="400">Returns 400 status code, if book is not exists.</response>
    /// <response code="200">Returns 200 status code, if book successfully added.</response>
    [HttpPut("{id}")]
    public IActionResult UpdateBook([FromRoute] int id, [FromBody] UpdateBookModel updatedBook){
        UpdateBookCommand command = new UpdateBookCommand(_dbContext);
        try
        {
            command.ID = id;
            command.Model = updatedBook;
            command.Handle();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();
    }

    /// <summary>
    /// Updates book by id with patch operations.
    /// </summary>
    /// <response code="400">Returns 400 status code, if book is not exists.</response>
    /// <response code="200">Returns 200 status code, if book successfully added.</response>
    [HttpPatch("{id}")]
    public IActionResult UpdateBook([FromRoute] int id, [FromBody] JsonPatchDocument<UpdateBookPatchModel> patchDocument){
        UpdateBookPatchCommand command = new UpdateBookPatchCommand(_dbContext);
        try
        {
            command.ID = id;
            command.Model = patchDocument;
            command.Handle();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();
    }

    /// <summary>
    /// Deletes book by id.
    /// </summary>
    /// <response code="400">Returns 400 status code, if book is not exists.</response>
    /// <response code="200">Returns 200 status code, if book successfully deleted.</response>
    [HttpDelete("{id}")]
    public IActionResult DeleteBook([FromRoute] int id){
        DeleteBookCommand command = new DeleteBookCommand(_dbContext);
        try
        {
            command.ID = id;
            command.Handle();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();
    }

    /// <summary>
    /// Filters and orders books.
    /// </summary>
    /// <remarks>
    /// OrderBy Format = {PropertyName}|{'asc' or 'desc'} or just {PropertyName} this means default ascending ordering.
    /// <br /> 
    /// Example = Title|asc,PageCount|desc - Title,PageCount|desc
    /// </remarks>
    /// <response code="200">Returns filtered books.</response>
    [HttpGet("filter")]
    public IActionResult FilterBooks([FromQuery] FilterBooksModel filter){
        FilterBooksQuery query = new FilterBooksQuery(_dbContext, _mapper);
        query.Model = filter;
        var result = query.Handle();
        return Ok(result);
    }
}