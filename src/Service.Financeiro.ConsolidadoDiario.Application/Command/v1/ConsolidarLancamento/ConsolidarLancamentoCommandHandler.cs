using MediatR;
using Service.Financeiro.ConsolidadoDiario.Domain.Entities;
using Service.Financeiro.ConsolidadoDiario.Domain.Enuns;
using Service.Financeiro.ConsolidadoDiario.Persistence.Cache;
using Service.Financeiro.ConsolidadoDiario.Persistence.Repository;

namespace Service.Financeiro.ConsolidadoDiario.Application.Command.v1.ConsolidarLancamento
{
    public class ConsolidarLancamentoCommandHandler(IRedisService _redisService,
                                                    IConsolidadoRepository _consolidadoRepository) : IRequestHandler<ConsolidarLancamentoCommand, Unit>
    {
        public async Task<Unit> Handle(ConsolidarLancamentoCommand command, CancellationToken cancellationToken)
        {
            var consolidado = await _redisService.GetDataAsync<Consolidado>($"Consolidado_{command.Data.Date}");

            if (consolidado is null)
                consolidado = await _consolidadoRepository.BuscarConsolidadoDiarioAsync(command.Data.Date);

            if (consolidado is null)
            {
                consolidado = new Consolidado
                {
                    Id = Guid.NewGuid(),
                    Data = DateTime.Now.Date
                };

                consolidado = CalcularConsolidado(consolidado, command);
                await _consolidadoRepository.SalvarConsolidadoAsync(consolidado);
            }
            else
            {
                consolidado = CalcularConsolidado(consolidado, command);
                await _consolidadoRepository.AtualizarConsolidadoAsync(consolidado);
            }

            await _redisService.SetDataAsync($"Consolidado_{command.Data.Date}", consolidado, TimeSpan.FromHours(2));

            return Unit.Value;
        }

        private Consolidado CalcularConsolidado(Consolidado consolidado, ConsolidarLancamentoCommand command)
        {
            consolidado.TotalCredito = command.Tipo == TipoLancamento.Credito ? consolidado.TotalCredito + command.Valor : consolidado.TotalCredito;
            consolidado.TotalDebito = command.Tipo == TipoLancamento.Debito ? consolidado.TotalDebito + command.Valor : consolidado.TotalDebito;

            return consolidado;
        }
    }
}
