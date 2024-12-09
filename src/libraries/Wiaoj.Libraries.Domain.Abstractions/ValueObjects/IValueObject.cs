namespace Wiaoj.Libraries.Domain.Abstractions.ValueObjects;
public interface IValueObject<out TSelf> {
    abstract static TSelf New();
}

public interface IValueObject<out TSelf, in TValue> {
    abstract static TSelf New(TValue value);
}

public interface IValueObject<out TSelf, in TValue1, in TValue2> {
    abstract static TSelf New(TValue1 value1, TValue2 value2);
}