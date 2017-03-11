using System;
using System.Web.Mvc;

namespace EventEmitter.Core.Command
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IDependencyResolver _resolver;

        public CommandDispatcher(IDependencyResolver resolver)
        {
            _resolver = resolver;
        }

        public void Execute<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }
            var handler = _resolver.GetService(typeof(ICommandHandler<TCommand>)) as ICommandHandler<TCommand>;
            
            if (handler == null)
            {
                throw new CommandHandlerNotFoundException(typeof(TCommand));
            }

            handler.Execute(command);
        }
    }
}