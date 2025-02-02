﻿using Wiaoj.Libraries.Domain.Abstractions.DomainEvents;
using Wiaoj.Libraries.Domain.Abstractions.Exceptions;
using Wiaoj.Libraries.Domain.Abstractions.ValueObjects;

namespace Wiaoj.Libraries.Domain.Abstractions;
public abstract class Aggregate<TId> : IAggregate, IHasDomainEvent
    where TId : class, IId<TId> {
    public TId Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public Boolean IsDeleted { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    private readonly List<IDomainEvent> domainEvents = [];
    public IReadOnlyList<IDomainEvent> DomainEvents => this.domainEvents.AsReadOnly();

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected Aggregate() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected Aggregate(TId id) {
        this.Id = id;
    }

    public void Delete(DateTime deletedAt) {
        if(this.IsDeleted)
            throw new EntityAlreadyDeletedException();
        this.IsDeleted = true;
        this.DeletedAt = deletedAt;
    }

    public void Restore() {
        if(!this.IsDeleted)
            throw new EntityNotDeletedException();
        this.IsDeleted = false;
        this.DeletedAt = null;
    }

    public void SetCreatedAt(DateTime createdAt) {
        if(this.CreatedAt != default)
            throw new CreatedAtAlreadySetException();
        this.CreatedAt = createdAt;
    }

    public void SetUpdatedAt(DateTime updatedAt) {
        this.UpdatedAt = updatedAt;
    }

    public void AddDomainEvent(IDomainEvent @event) {
        if(!this.domainEvents.Exists(x => x == @event)) 
            this.domainEvents.Add(@event);
    }

    public void ClearDomainEvents() {
        this.domainEvents.Clear();
    }
}