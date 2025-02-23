namespace Service.Financeiro.ConsolidadoDiario.Domain.Entities
{
    public class Consolidado
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public decimal TotalCredito { get; set; }
        public decimal TotalDebito { get; set; }
        public decimal Saldo { get => TotalCredito - TotalDebito; }
    }
}
