using EventFlow.Commands;

using EventSourcingWorkshop.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingWorkshop.ApplicationLayer
{
    public class CreateThingCommandHandler : CommandHandler<ExampleAggregate, AggregateId, CreateThingCommand>
    {
        public override Task ExecuteAsync(ExampleAggregate aggregate, CreateThingCommand command, CancellationToken cancellationToken)
        {
            var executionResult = aggregate.Create(command.StarterValue);
            return Task.FromResult(executionResult);
        }
    }
}