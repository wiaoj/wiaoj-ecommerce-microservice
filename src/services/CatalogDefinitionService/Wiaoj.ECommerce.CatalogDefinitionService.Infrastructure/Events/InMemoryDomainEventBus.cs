using System.Threading.Channels;
using Wiaoj.ECommerce.CatalogDefinitionService.Application.Abstractions;
using Wiaoj.Libraries.Domain.Abstractions.DomainEvents;

namespace Wiaoj.ECommerce.CatalogDefinitionService.Infrastructure.Events; 
internal sealed class InMemoryDomainEventBus(IInMemoryMessageQueue messageQueue) : IDomainEventBus {
    public async Task PublishAsync<T>(T domainEvent, CancellationToken cancellationToken) where T : IDomainEvent {
        await messageQueue.Writer.WriteAsync(domainEvent, cancellationToken);
    }

    public async Task PublishAsync<T>(IEnumerable<T> domainEvents, CancellationToken cancellationToken) where T : IDomainEvent {
        foreach(T domainEvent in domainEvents)
            await messageQueue.Writer.WriteAsync(domainEvent, cancellationToken);
    }
}
internal sealed class InMemoryMessageQueue : IInMemoryMessageQueue {
    private readonly Channel<IDomainEvent> channel = Channel.CreateUnbounded<IDomainEvent>();
    public ChannelWriter<IDomainEvent> Writer => this.channel.Writer;
    public ChannelReader<IDomainEvent> Reader => this.channel.Reader;
}

internal interface IInMemoryMessageQueue {
    public ChannelWriter<IDomainEvent> Writer { get; }
    public ChannelReader<IDomainEvent> Reader { get; }
}