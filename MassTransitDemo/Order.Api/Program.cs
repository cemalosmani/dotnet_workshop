using MassTransit;
using Microsoft.EntityFrameworkCore;
using Stock.Api.Consumers;
using AppContext = Order.Api.Models.AppContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("amqps://jjpejume:7yBazkIDzjQexclvpDALL3dgZYNYmLBi@woodpecker.rmq.cloudamqp.com/jjpejume");
    });
});

builder.Services.AddDbContext<AppContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
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

