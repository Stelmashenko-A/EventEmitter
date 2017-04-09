using System.Linq;
using System.Web.Mvc;

namespace EventEmitter.Core.Command
{
    public class CommandDispatcher : ICommandDispatcher
    {
        public Context Context { get; set; }
        public readonly ICommandBus CommandBus;
        public void Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            Validate(command);
            CommandBus.Execute(command);
        }

        protected readonly IDependencyResolver DependencyResolver;

        public CommandDispatcher(IDependencyResolver dependencyResolver, ICommandBus commandBus)
        {
            DependencyResolver = dependencyResolver;
            CommandBus = commandBus;
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