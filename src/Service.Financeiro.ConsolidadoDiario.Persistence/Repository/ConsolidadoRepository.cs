using Microsoft.EntityFrameworkCore;
using Service.Financeiro.ConsolidadoDiario.Domain.Entities;
using Service.Financeiro.ConsolidadoDiario.Persistence.Context;

namespace Service.Financeiro.ConsolidadoDiario.Persistence.Repository
{
    public class ConsolidadoRepository(ConsolidadoContext _context) : IConsolidadoRepository
    {
        public async Task<IEnumerable<Consolidado>> ListarConsolidadoDiarioAsync(int pagina = 1, int tamanhoPagina = 100)
        {
            return await _context.Consolidado
                                 .Skip((pagina - 1) * tamanhoPagina)
                                 .Take(tamanhoPagina)
                                 .ToListAsync();
        }

        public async Task<Consolidado?> BuscarConsolidadoDiarioAsync(DateTime date)
        {
            return await _context.Consolidado.FirstOrDefaultAsync(x => x.Data.Date == date.Date);
        }

        public async Task<Consolidado> SalvarConsolidadoAsync(Consolidado consolidado)
        {
            await _context.AddAsync(consolidado);

            await _context.SaveChangesAsync();

            return consolidado;
        }

        public async Task<Consolidado> AtualizarConsolidadoAsync(Consolidado consolidado)
        {
            _context.Update(consolidado);

            await _context.SaveChangesAsync();

            return consolidado;
        }
    }
}
