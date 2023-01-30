namespace WebAPI.Operations.BookOperations.Commands.UpdateBookPatch;

public class UpdateBookPatchCommandValidator : AbstractValidator<UpdateBookPatchCommand> {
    public UpdateBookPatchCommandValidator(){
        RuleFor(command => command.ID).NotEmpty().GreaterThan(0);
    }
}