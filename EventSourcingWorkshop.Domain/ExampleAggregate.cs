using EventFlow.Aggregates;
using EventFlow.Aggregates.ExecutionResults;

using EventSourcingWorkshop.Domain.Events;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingWorkshop.Domain
{
    //Rename me!
    public class ExampleAggregate : AggregateRoot<ExampleAggregate, AggregateId>
    {
        public int currentValue { get; private set; }
        public ExampleAggregate(AggregateId id) : base(id)
        {

        }

        public IExecutionResult Create(int starterValue)
        {
            Emit(new ThingCreated(starterValue));

            return ExecutionResult.Success();
        }

        public void Apply(ThingCreated thingCreated)
        {
            currentValue = thingCreated.StarterValue;
        }
    }
}
