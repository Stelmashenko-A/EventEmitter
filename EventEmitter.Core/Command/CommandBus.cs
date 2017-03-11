using System.Linq;
using System.Web.Mvc;

namespace EventEmitter.Core.Command
{
    public class CommandBus : ICommandBus
    {
        public Context Context { get; set; }
        public readonly ICommandDispatcher CommandDispatcher;
        public void Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            Validate(command);
            CommandDispatcher.Execute(command);
        }

        protected readonly IDependencyResolver DependencyResolver;

        public CommandBus(IDependencyResolver dependencyResolver, ICommandDispatcher commandDispatcher)
        {
            DependencyResolver = dependencyResolver;
            CommandDispatcher = commandDispatcher;
        }

        protected void Validate<TCommand>(TCommand command) where TCommand : ICommand
        {
            var validators = DependencyResolver.GetServices(typeof(ICommandValidator<TCommand>)).Select(x => x as ICommandValidator<TCommand>);
            foreach (var validator in validators.Where(validator => !validator.IsValid(command, Context)))
            {
                throw new CommandValidationException(command.GetType().FullName + " falid on " + validator.GetType().FullName);
            }
        }
    }
}