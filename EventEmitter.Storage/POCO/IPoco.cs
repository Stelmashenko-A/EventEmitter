using System;

namespace EventEmitter.Storage
{
    public interface IPoco
    {
        Guid Id { get; set; }
    }
}