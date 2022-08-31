using EventFlow.Commands;

using EventSourcingWorkshop.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingWorkshop.ApplicationLayer
{
    public class CreateThingCommand : Command<ExampleAggregate, AggregateId>
    {

        public int StarterValue { get; }
        public CreateThingCommand(AggregateId aggregateId, int value) : base(aggregateId)
        {
            StarterValue = value;
        }
    }
}