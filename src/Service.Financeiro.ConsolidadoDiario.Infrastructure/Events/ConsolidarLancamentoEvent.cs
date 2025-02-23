using Service.Financeiro.ConsolidadoDiario.Domain.Enuns;

namespace Service.Financeiro.ConsolidadoDiario.Infrastructure.Events
{
    public class ConsolidarLancamentoEvent
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public TipoLancamento Tipo { get; set; }
    }
}
