using AutoFixture;
using NSubstitute;
using Service.Financeiro.ConsolidadoDiario.Domain.Entities;
using Service.Financeiro.ConsolidadoDiario.Persistence.Repository;

namespace Service.Financeiro.ConsolidadoDiario.Test.Command.v1.ConsolidarLancamento.Mocks.Repository
{
    public class RepositotyMock
    {
        public static IConsolidadoRepository MockBuscarConsolidadoDiarioAsync()
        {
            var mock = Substitute.For<IConsolidadoRepository>();

            var fixture = new Fixture();

            mock.BuscarConsolidadoDiarioAsync(Arg.Any<DateTime>()).Returns(fixture.Create<Consolidado>());

            return mock;
        }
    }
}
