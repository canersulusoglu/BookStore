namespace WebAPI.Operations.BookOperations.Queries.FilterBooks;

public class FilterBooksQueryValidator : AbstractValidator<FilterBooksQuery> {
    public FilterBooksQueryValidator(){
        RuleFor(command => command.Model!.MinPageCount).GreaterThan(0);
        RuleFor(command => command.Model!.MaxPageCount).GreaterThan(0);
    }
}