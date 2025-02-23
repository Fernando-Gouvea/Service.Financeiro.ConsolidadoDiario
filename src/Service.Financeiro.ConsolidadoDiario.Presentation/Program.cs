using MassTransit;
using Microsoft.EntityFrameworkCore;
using Service.Financeiro.ConsolidadoDiario.Application.Applications.v1.ConsolidarLancamento;
using Service.Financeiro.ConsolidadoDiario.Persistence.Cache;
using Service.Financeiro.ConsolidadoDiario.Persistence.Context;
using Service.Financeiro.ConsolidadoDiario.Persistence.Repository;
using Service.Financeiro.ConsolidadoDiario.Presentation.Api.Queues;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddDbContext<ConsolidadoContext>(options => options.UseInMemoryDatabase("TestDatabase"));
builder.Services.AddControllers();
builder.Services.AddSingleton<IRedisService, RedisService>();
builder.Services.AddScoped<IConsolidadoRepository, ConsolidadoRepository>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(ConsolidarLancamentoCommandHandler).Assembly);
});

builder.Services.AddMassTransit(x =>
{
    x.AddDelayedMessageScheduler();
    x.AddConsumer<QueueConsolidarLancamentoConsumer>(typeof(QueueConsolidarLancamentoConsumerDefinition));
    x.SetKebabCaseEndpointNameFormatter();
    x.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(configuration.GetConnectionString("RabbitMq"));
        cfg.UseDelayedMessageScheduler();
        cfg.ServiceInstance(instance =>
        {
            instance.ConfigureJobServiceEndpoints();
            instance.ConfigureEndpoints(ctx, new KebabCaseEndpointNameFormatter("prod", false));

        });
    });
});

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();