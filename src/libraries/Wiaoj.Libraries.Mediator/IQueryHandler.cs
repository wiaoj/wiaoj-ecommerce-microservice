namespace Wiaoj.Libraries.Mediator.Abstractions;
public interface IQueryHandler<in TQuery, TResponse> : BaseMediator.IQueryHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
    where TResponse : notnull;