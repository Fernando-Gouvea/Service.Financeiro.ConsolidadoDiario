using Microsoft.EntityFrameworkCore;
using Service.Financeiro.ConsolidadoDiario.Domain.Entities;

namespace Service.Financeiro.ConsolidadoDiario.Persistence.Context
{
    public class ConsolidadoContext : DbContext
    {
        public ConsolidadoContext(DbContextOptions<ConsolidadoContext> options) : base(options)
        { }

        public DbSet<Consolidado> Consolidado { get; set; } = default!;
    }
}
