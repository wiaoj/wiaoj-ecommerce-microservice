namespace Wiaoj.Libraries.Domain.Abstractions;
public interface IId<out T> {
    public T Value { get; }
}

public interface IId : IId<String>;

public interface IValueObject { }