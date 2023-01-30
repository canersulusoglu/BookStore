namespace WebAPI.Operations.BookOperations.Commands.CreateBook;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand> {
    public CreateBookCommandValidator(){
        RuleFor(command => (int)command.Model!.GenreId).GreaterThan(0);
        RuleFor(command => command.Model!.PageCount).GreaterThan(0);
        RuleFor(command => command.Model!.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.AddDays(1).Date);
        RuleFor(command => command.Model!.Title).NotEmpty().MinimumLength(4);
    }
}