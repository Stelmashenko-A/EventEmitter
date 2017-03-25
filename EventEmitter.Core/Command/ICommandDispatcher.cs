using System;
using System.Linq;

namespace EventEmitter.Core.Command
{
    public interface ICommandDispatcher
    {
        void Execute<TCommand>(TCommand command)
            where TCommand : ICommand;
    }

    public class SignOnCommand : ICommand
    {
        public int Id { get; private set; }
        public int EffectiveDate { get; private set; }

        public SignOnCommand()
        {
            Id = 1;
            EffectiveDate = 1;
        }
    }

    public class SignOnCommandHandler : ICommandHandler<SignOnCommand>
    {
        public void Execute(SignOnCommand command)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.GetName().Name == "EventEmitter.Core");
            var t = 0;
            t = 10;
        }
    }

    public class SignOnCommandValidator : ICommandValidator<SignOnCommand>
    {
        public bool IsValid(SignOnCommand command, Context context)
        {
            return true;
        }
    }
}