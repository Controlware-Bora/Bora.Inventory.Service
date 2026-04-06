using Bora.Inventory.Domain.Common.Events;

namespace Bora.Inventory.Domain.Common.Entities;

public abstract class AggregateRoot<TKey> : Entity<TKey>
{
    #region Domain Events

    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    #endregion
    
    
    #region Methods
    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
    #endregion
}