using Luma.Core.Domain.Events;

namespace Luma.Core.Domain.Entities;


public interface IAggregateRoot
{
    void ClearEvents();
    IEnumerable<IDomainEvent> GetEvents();
}
