using Service.Financeiro.ConsolidadoDiario.Domain.Entities;

namespace Service.Financeiro.ConsolidadoDiario.Persistence.Repository
{
    public interface IConsolidadoRepository
    {
        Task<IEnumerable<Consolidado>> ListarConsolidadoDiarioAsync(int pagina = 1, int tamanhoPagina = 100);
        Task<Consolidado?> BuscarConsolidadoDiarioAsync(DateTime date);
        Task<Consolidado> SalvarConsolidadoAsync(Consolidado consolidado);
        Task<Consolidado> AtualizarConsolidadoAsync(Consolidado consolidado);
    }
}
