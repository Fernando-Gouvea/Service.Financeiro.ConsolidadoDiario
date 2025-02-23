using AutoFixture;
using AutoMapper;
using NSubstitute;
using Service.Financeiro.ConsolidadoDiario.Application.Query.v1.BuscarConsolidado;
using Service.Financeiro.ConsolidadoDiario.Domain.Entities;

namespace Service.Financeiro.ConsolidadoDiario.Test.Query.v1.BuscarConsolidado.Mocks.Mapper
{
    public class MapperMock
    {
        public static IMapper GetMock()
        {
            var mock = Substitute.For<IMapper>();

            var fixture = new Fixture();

            mock.Map<BuscarConsolidadoQueryResponse>(Arg.Any<Consolidado>()).Returns(fixture.Create<BuscarConsolidadoQueryResponse>());

            return mock;
        }
    }
}