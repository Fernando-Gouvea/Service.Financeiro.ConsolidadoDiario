using AutoFixture;
using Service.Financeiro.ConsolidadoDiario.Application.Query.v1.BuscarConsolidado;
using Service.Financeiro.ConsolidadoDiario.Test.Query.v1.BuscarConsolidado.Mocks.Mapper;
using Service.Financeiro.ConsolidadoDiario.Test.Query.v1.BuscarConsolidado.Mocks.Redis;
using Service.Financeiro.ConsolidadoDiario.Test.Query.v1.BuscarConsolidado.Mocks.Repository;

namespace Service.Financeiro.ConsolidadoDiario.Test.Query.v1.BuscarConsolidado
{
    public class BuscarConsolidadoQueryHandlerTest
    {
        [Test]
        public void BuscarLancamento_Cache()
        {
            var redis = RedisMock.GetMock();
            var mapper = MapperMock.GetMock();
            var repository = RepositotyMock.MockBuscarConsolidadoDiarioAsync();
            var handler = new BuscarConsolidadoQueryHandler(mapper, redis, repository);
            var fixture = new Fixture();
            var response = handler.Handle(fixture.Create<BuscarConsolidadoQuery>(), CancellationToken.None);

            Assert.That(response.Result, Is.Not.Null);
        }

        [Test]
        public void BuscarLancamento_BD()
        {
            var redis = RedisMock.GetMock_Null();
            var mapper = MapperMock.GetMock();
            var repository = RepositotyMock.MockBuscarConsolidadoDiarioAsync();
            var handler = new BuscarConsolidadoQueryHandler(mapper, redis, repository);
            var fixture = new Fixture();
            var response = handler.Handle(fixture.Create<BuscarConsolidadoQuery>(), CancellationToken.None);

            Assert.That(response.Result, Is.Not.Null);
        }
    }
}