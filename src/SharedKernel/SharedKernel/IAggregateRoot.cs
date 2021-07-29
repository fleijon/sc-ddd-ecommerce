using SharedKernel.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel
{
    /// <summary>
    ///  Aggregate root interface
    /// </summary>
    public interface IAggregateRoot
    {
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

        void ClearDomainEvents();
    }
}