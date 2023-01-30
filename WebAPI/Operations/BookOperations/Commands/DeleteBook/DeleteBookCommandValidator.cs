namespace WebAPI.Operations.BookOperations.Commands.DeleteBook;

public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand> {
    public DeleteBookCommandValidator(){
        RuleFor(command => command.ID).NotEmpty().GreaterThan(0);
    }
}