using EventFlow.Aggregates;
using EventFlow.ReadStores;

using EventSourcingWorkshop.Domain;
using EventSourcingWorkshop.Domain.Events;

namespace EventSourcingWorkshop.Queries
{
    public class ExampleAggregateReadModel : IReadModel, 
        IAmAsyncReadModelFor<ExampleAggregate, AggregateId, ThingCreated>
    {
        public int Total { get; set; }
        public Task ApplyAsync(IReadModelContext context, IDomainEvent<ExampleAggregate, AggregateId, ThingCreated> domainEvent, CancellationToken cancellationToken)
        {
            Total = domainEvent.AggregateEvent.StarterValue;
            return Task.CompletedTask;
        }
    }
}