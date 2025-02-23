using AutoMapper;
using MediatR;
using Service.Financeiro.ConsolidadoDiario.Domain.Entities;
using Service.Financeiro.ConsolidadoDiario.Persistence.Cache;
using Service.Financeiro.ConsolidadoDiario.Persistence.Repository;

namespace Service.Financeiro.ConsolidadoDiario.Application.Query.v1.BuscarConsolidado
{
    public class BuscarConsolidadoQueryHandler(IMapper _mapper,
                                               IRedisService _redisService,
                                               IConsolidadoRepository _consolidadoRepository) : IRequestHandler<BuscarConsolidadoQuery, BuscarConsolidadoQueryResponse>
    {
        public async Task<BuscarConsolidadoQueryResponse> Handle(BuscarConsolidadoQuery command, CancellationToken cancellationToken)
        {
            var consolidado = await _redisService.GetDataAsync<Consolidado>($"Consolidado_{command.Data.Date}");

            if (consolidado is null)
                consolidado = await _consolidadoRepository.BuscarConsolidadoDiarioAsync(command.Data.Date);

            return _mapper.Map<BuscarConsolidadoQueryResponse>(consolidado);
        }
    }
}
