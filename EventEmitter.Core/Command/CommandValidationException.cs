using System;

namespace EventEmitter.Core.Command
{
    public class CommandValidationException : Exception
    {
        public CommandValidationException(string message)
            : base(message)
        {
        }
    }
}