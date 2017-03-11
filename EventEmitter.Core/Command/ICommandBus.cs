namespace EventEmitter.Core.Command
{
    public interface ICommandBus
    {
        Context Context { get; set; }
        void Execute<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
