namespace Wiaoj.Libraries.Mediator.Abstractions;
public interface IQuery<out TResponse> : BaseMediator.IQuery<TResponse> where TResponse : notnull;