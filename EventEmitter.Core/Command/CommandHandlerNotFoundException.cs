using System;

namespace EventEmitter.Core.Command
{
    public class CommandHandlerNotFoundException : Exception
    {
        public CommandHandlerNotFoundException(Type type)
        {
        }
    }
}