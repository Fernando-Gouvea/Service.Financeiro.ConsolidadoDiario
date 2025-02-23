using AutoMapper;
using Service.Financeiro.ConsolidadoDiario.Application.Query.v1.BuscarConsolidado;
using Service.Financeiro.ConsolidadoDiario.Domain.Entities;

namespace Service.Financeiro.ConsolidadoDiario.Application.Profiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Consolidado, BuscarConsolidadoQueryResponse>().ReverseMap();
        }
    }
}
