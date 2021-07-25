using System;

namespace SharedKernel.Events
{
    public interface IDomainEvent : INotification
    {
        DateTime CreatedAt { get; }
    }
}