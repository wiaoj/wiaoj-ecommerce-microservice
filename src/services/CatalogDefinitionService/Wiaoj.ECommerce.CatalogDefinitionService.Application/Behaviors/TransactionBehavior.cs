using Mediator;
using System.Transactions;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Abstractions;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Application.Behaviors;
internal sealed class TransactionBehavior<TMessage, TResponse>(IUnitOfWork unitOfWork) : IPipelineBehavior<TMessage, TResponse>
      where TMessage : notnull, IMessage {

    public async ValueTask<TResponse> Handle(TMessage message,
                                             CancellationToken cancellationToken,
                                             MessageHandlerDelegate<TMessage, TResponse> next) {
        // The execution is wrapped in a transaction scope to ensure that if any other
        // SaveChanges calls to the data source (e.g. EF Core) are called, that they are
        // transacted atomically. The isolation is set to ReadCommitted by default (i.e. read-
        // locks are released, while write-locks are maintained for the duration of the
        // transaction). Learn more on this approach for EF Core:
        // https://docs.microsoft.com/en-us/ef/core/saving/transactions#using-systemtransactions

        TResponse? response = await next(message, cancellationToken);

        TransactionOptions transactionOptions = new() {
            IsolationLevel = IsolationLevel.ReadCommitted
        };

        await unitOfWork.CreateExecutionStrategyAsync(async (_) => {
            using TransactionScope transaction = new(TransactionScopeOption.Required,
                                                     transactionOptions,
                                                     TransactionScopeAsyncFlowOption.Enabled);

            // By calling SaveChanges at the last point in the transaction ensures that write-
            // locks in the database are created and then released as quickly as possible. This
            // helps optimize the application to handle a higher degree of concurrency.
            await unitOfWork.SaveChangesAsync(cancellationToken);

            // Commit transaction if everything succeeds, transaction will auto-rollback when
            // disposed if anything failed.
            transaction.Complete();
        }, cancellationToken);

        return response;
    }
}