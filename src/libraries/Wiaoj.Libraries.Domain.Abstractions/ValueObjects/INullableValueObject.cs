namespace Wiaoj.Libraries.Domain.Abstractions.ValueObjects;
public interface INullableValueObject<out TSelf> {
    abstract static TSelf? NewNullable();
}

public interface INullableValueObject<out TSelf, in TValue> {
    abstract static TSelf? NewNullable(TValue? value);
}