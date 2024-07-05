namespace Wiaoj.Libraries.Domain.Abstractions;
public interface IDeletable {
    Boolean IsDeleted { get; }
    DateTime? DeletedAt { get; }
    void Delete(DateTime deletedAt);
    void Restore();
}