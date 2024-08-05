namespace Wiaoj.Libraries.Domain.Abstractions;
public interface IValueObject<out TSelf> {
    static abstract TSelf New();
}

public interface IValueObject<out TSelf, in TValue> {
    static abstract TSelf New(TValue value);
}

public interface IValueObject<out TSelf, in TValue1, in TValue2> {
    static abstract TSelf New(TValue1 value1, TValue2 value2);
}