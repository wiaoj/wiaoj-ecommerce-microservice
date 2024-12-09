namespace Wiaoj.Libraries.Mediator.Abstractions;
public interface ICommand : BaseMediator.ICommand;
public interface ICommand<out TResponse> : BaseMediator.ICommand<TResponse> where TResponse : notnull;