using MediatR;

namespace Service.Financeiro.ConsolidadoDiario.Application.Query.v1.BuscarConsolidado
{
    public class BuscarConsolidadoQuery : IRequest<BuscarConsolidadoQueryResponse>
    {
        public DateTime Data { get; set; }
    }
}
