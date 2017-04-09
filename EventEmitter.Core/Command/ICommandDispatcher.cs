namespace EventEmitter.Core.Command
{
    public interface ICommandDispatcher
    {
        Context Context { get; set; }
        void Execute<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
