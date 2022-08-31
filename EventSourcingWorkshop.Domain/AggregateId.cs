using EventFlow.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingWorkshop.Domain
{
    public class AggregateId : Identity<AggregateId>
    {
        public AggregateId(string value) : base(value)
        {
        }
    }
}
