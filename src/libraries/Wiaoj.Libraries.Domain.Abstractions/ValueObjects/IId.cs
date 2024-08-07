namespace Wiaoj.Libraries.Domain.Abstractions.ValueObjects;
public interface IId<out TSelf, out TValue> : IValueObject<TSelf> {
    TValue Value { get; }
}

public interface IId<TSelf> : IId<TSelf, String>;