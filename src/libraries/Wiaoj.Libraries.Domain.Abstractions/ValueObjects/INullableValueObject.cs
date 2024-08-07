namespace Wiaoj.Libraries.Domain.Abstractions.ValueObjects;
public interface INullableValueObject<out TSelf> {
    static abstract TSelf? NewNullable();
}

public interface INullableValueObject<out TSelf, in TValue> {
    static abstract TSelf? NewNullable(TValue? value);
}