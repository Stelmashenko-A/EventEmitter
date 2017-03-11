namespace EventEmitter.Core.Command
{
    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}