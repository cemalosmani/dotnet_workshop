using MassTransit;
using Payment.Api.Consumers;
using Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<StockSufficientEventConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("amqps://jjpejume:7yBazkIDzjQexclvpDALL3dgZYNYmLBi@woodpecker.rmq.cloudamqp.com/jjpejume");
        cfg.ReceiveEndpoint(RabbitMQConstants.StockSufficientQueueName,e =>
        {
            e.ConfigureConsumer<StockSufficientEventConsumer>(context);
        });
    });
});

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

