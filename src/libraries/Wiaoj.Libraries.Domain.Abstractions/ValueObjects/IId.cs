namespace Wiaoj.Libraries.Domain.Abstractions.ValueObjects;
public interface IId<out TSelf, TValue> : IValueObject<TSelf> {
    TValue Value { get; }
    abstract static TSelf From(TValue value);
}

public interface IId<TSelf> : IId<TSelf, String>;