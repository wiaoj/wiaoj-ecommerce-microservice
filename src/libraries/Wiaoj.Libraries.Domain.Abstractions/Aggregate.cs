namespace Wiaoj.Libraries.Domain.Abstractions;
public abstract class Aggregate<TId> : IAggregate
    where TId : IId<TId> {
    public TId Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public Boolean IsDeleted { get; private set; }
    public DateTime? DeletedAt { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected Aggregate() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected Aggregate(TId id) {
        this.Id = id;
    }

    public void Delete(DateTime deletedAt) {
        if(this.IsDeleted)
            throw new InvalidOperationException("Entity is already deleted.");
        this.IsDeleted = true;
        this.DeletedAt = deletedAt;
    }

    public void Restore() {
        if(!this.IsDeleted)
            throw new InvalidOperationException("Entity is not deleted.");
        this.IsDeleted = false;
        this.DeletedAt = null;
    }

    public void SetCreatedAt(DateTime createdAt) {
        if(this.CreatedAt != default)
            throw new InvalidOperationException("CreatedAt can only be set once.");
        this.CreatedAt = createdAt;
    }

    public void SetUpdatedAt(DateTime updatedAt) {
        this.UpdatedAt = updatedAt;
    }
}