namespace Wiaoj.Libraries.Mediator.Abstractions;
public interface ICommandHandler<TCommand> : BaseMediator.ICommandHandler<TCommand> where TCommand : ICommand;
public interface ICommandHandler<in TCommand, TResponse> : BaseMediator.ICommandHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
    where TResponse : notnull;