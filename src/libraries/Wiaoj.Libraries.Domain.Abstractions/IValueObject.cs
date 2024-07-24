namespace Wiaoj.Libraries.Domain.Abstractions;
public interface IValueObject<out TObject> {
    static abstract TObject New();
}

public interface IValueObject<out TObject, in TValue> {
    static abstract TObject New(TValue value);
}

public interface IValueObject<out TObject, in TValue1, in TValue2> {
    static abstract TObject New(TValue1 value1, TValue2 value2);
}