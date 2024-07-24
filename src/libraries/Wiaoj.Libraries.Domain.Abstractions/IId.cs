namespace Wiaoj.Libraries.Domain.Abstractions;
public interface IId<out TObject, out TValue> : IValueObject<TObject> {
    public TValue Value { get; }
}

public interface IId<TObject> : IId<TObject, String>;