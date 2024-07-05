namespace Wiaoj.Libraries.Domain.Abstractions;
public interface IId<out T> where T : IValueObject {
    public T Id { get; }
}

public interface IValueObject { }