namespace WebAPI.Operations.BookOperations.Commands.UpdateBook;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand> {
    public UpdateBookCommandValidator(){
        RuleFor(command => command.ID).NotEmpty().GreaterThan(0);
        RuleFor(command => (int)command.Model!.GenreId).GreaterThan(0);
        RuleFor(command => command.Model!.PageCount).GreaterThan(0);
        RuleFor(command => command.Model!.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.AddDays(1).Date);
        RuleFor(command => command.Model!.Title).NotEmpty().MinimumLength(4);
    }
}