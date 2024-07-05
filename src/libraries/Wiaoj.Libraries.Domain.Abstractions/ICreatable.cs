namespace Wiaoj.Libraries.Domain.Abstractions;
public interface ICreatable {
    DateTime CreatedAt { get; }
    void SetCreatedAt(DateTime createdAt);
}