namespace EventEmitter.Core.Command
{
    public interface ICommandValidator<in TCommand> where TCommand : ICommand
    {
        bool IsValid(TCommand command, Context context);
    }
}