using EventFlow;
using EventFlow.Queries;

using EventSourcingWorkshop.ApplicationLayer;
using EventSourcingWorkshop.Queries;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcingWorkshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AggregateController : ControllerBase
    {
        private ICommandBus _commandBus { get; }
        private IQueryProcessor _queryProcessor { get; }
        public AggregateController(ICommandBus commandBus, IQueryProcessor queryProcessor)
        {
            _commandBus = commandBus;
            _queryProcessor = queryProcessor;
        }

        [HttpGet("ExampleEndpoint/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var results = await _queryProcessor.ProcessAsync(new ReadModelByIdQuery<ExampleAggregateReadModel>(id), new CancellationToken());
            return Ok(results);
        }

        [HttpPost("ExampleEndpoint/")]
        public async Task<IActionResult> CompleteCommand([FromBody] int StarterValue)
        {
            var id = Guid.NewGuid().ToString();
            var aggregateId = new Domain.AggregateId("aggregate-" + id);
            var command = new CreateThingCommand(aggregateId, StarterValue);
            var result = await _commandBus.PublishAsync(command, new CancellationToken());
            return Ok(aggregateId);
        }
    }
}
