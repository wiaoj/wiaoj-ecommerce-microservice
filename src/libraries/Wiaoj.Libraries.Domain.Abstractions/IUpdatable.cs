namespace Wiaoj.Libraries.Domain.Abstractions;
public interface IUpdatable {
    DateTime? UpdatedAt { get; }
    void SetUpdatedAt(DateTime updatedAt);
}