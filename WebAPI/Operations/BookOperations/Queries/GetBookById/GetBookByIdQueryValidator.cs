namespace WebAPI.Operations.BookOperations.Queries.GetBookById;

public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery> {
    public GetBookByIdQueryValidator(){
        RuleFor(command => command.ID).GreaterThan(0);
    }
}