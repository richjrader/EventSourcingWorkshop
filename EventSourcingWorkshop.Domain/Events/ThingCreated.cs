using EventFlow.Aggregates;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingWorkshop.Domain.Events
{
    public  class ThingCreated : AggregateEvent<ExampleAggregate, AggregateId>
    {
        public int StarterValue { get; }

        public ThingCreated(int starterValue)
        {
            StarterValue = starterValue;
        }
    }
}
