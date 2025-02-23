using MediatR;
using Service.Financeiro.ConsolidadoDiario.Domain.Enuns;

namespace Service.Financeiro.ConsolidadoDiario.Application.Applications.v1.ConsolidarLancamento
{
    public class ConsolidarLancamentoCommand : IRequest<Unit>
    {
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public TipoLancamento Tipo { get; set; }
    }
}
