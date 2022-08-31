using EventFlow.AspNetCore.Extensions;
using EventFlow.DependencyInjection.Extensions;
using EventFlow.EventStores.Files;
using EventFlow.Extensions;

using EventSourcingWorkshop.ApplicationLayer;
using EventSourcingWorkshop.Controllers;
using EventSourcingWorkshop.Domain;
using EventSourcingWorkshop.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEventFlow(ef =>
{
    ef.AddDefaults(typeof(AggregateController).Assembly);
    ef.AddDefaults(typeof(ExampleAggregate).Assembly);
    ef.AddDefaults(typeof(CreateThingCommandHandler).Assembly);
    ef.AddDefaults(typeof(ExampleAggregateReadModel).Assembly);
    ef.AddAspNetCore();
    ef.UseFilesEventStore(FilesEventStoreConfiguration.Create(".\\store\\"));
    ef.UseInMemoryReadStoreFor<ExampleAggregateReadModel>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
