using MassTransit;
using MediatR;
using Service.Financeiro.ConsolidadoDiario.Application.Command.v1.ConsolidarLancamento;
using Service.Financeiro.ConsolidadoDiario.Infrastructure.Events;

namespace Service.Financeiro.ConsolidadoDiario.Presentation.Api.Queues
{
    public class QueueConsolidarLancamentoConsumer(IMediator _mediator) : IConsumer<ConsolidarLancamentoEvent>
    {
        public async Task Consume(ConsumeContext<ConsolidarLancamentoEvent> context)
        {
            await _mediator.Send(new ConsolidarLancamentoCommand { Data = context.Message.Data, Tipo = context.Message.Tipo, Valor = context.Message.Valor });
        }
    }

    public class QueueConsolidarLancamentoConsumerDefinition : ConsumerDefinition<QueueConsolidarLancamentoConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<QueueConsolidarLancamentoConsumer> consumerConfigurator, IRegistrationContext context)
        {
            consumerConfigurator.UseMessageRetry(retry => retry.Interval(3, TimeSpan.FromSeconds(30)));
        }
    }
}

