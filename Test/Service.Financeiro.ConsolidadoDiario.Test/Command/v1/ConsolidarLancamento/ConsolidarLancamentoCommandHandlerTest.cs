using AutoFixture;
using MediatR;
using Service.Financeiro.ConsolidadoDiario.Application.Command.v1.ConsolidarLancamento;
using Service.Financeiro.ConsolidadoDiario.Test.Command.v1.ConsolidarLancamento.Mocks.Redis;
using Service.Financeiro.ConsolidadoDiario.Test.Command.v1.ConsolidarLancamento.Mocks.Repository;

namespace Service.Financeiro.ConsolidadoDiario.Test.Command.v1.ConsolidarLancamento
{
    public class ConsolidarLancamentoCommandHandlerTest
    {
        [Test]
        public void ConsolidarLancamento()
        {
            var redis = RedisMock.GetMock();
            var repository = RepositotyMock.MockBuscarConsolidadoDiarioAsync();
            var handler = new ConsolidarLancamentoCommandHandler(redis, repository);
            var fixture = new Fixture();
            var response = handler.Handle(fixture.Create<ConsolidarLancamentoCommand>(), CancellationToken.None);

            Assert.That(response.Result, Is.EqualTo(Unit.Value));
        }
    }
}
