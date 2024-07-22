namespace Wiaoj.Libraries.Domain.Abstractions;
public abstract class Aggregate<TId>(TId id) : IAggregate
    where TId : IId {
    public TId Id => id;
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public Boolean IsDeleted { get; private set; }
    public DateTime? DeletedAt { get; private set; }

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