using AutoFixture;
using NSubstitute;
using Service.Financeiro.ConsolidadoDiario.Domain.Entities;
using Service.Financeiro.ConsolidadoDiario.Persistence.Cache;

namespace Service.Financeiro.ConsolidadoDiario.Test.Query.v1.BuscarConsolidado.Mocks.Redis
{
    public class RedisMock
    {
        public static IRedisService GetMock()
        {
            var mock = Substitute.For<IRedisService>();

            var fixture = new Fixture();

            mock.GetDataAsync<Consolidado>(Arg.Any<string>()).Returns(fixture.Create<Consolidado>());

            return mock;
        }

        public static IRedisService GetMock_Null()
        {
            var mock = Substitute.For<IRedisService>();

            mock.GetDataAsync<Consolidado>(Arg.Any<string>());

            return mock;
        }
    }
}