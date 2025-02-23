using AutoFixture;
using NSubstitute;
using Service.Financeiro.Lancamento.Persistence.Repository;
using LancamentoDb = Service.Financeiro.Lancamento.Domain.Entities.Lancamento;

namespace Service.Financeiro.ConsolidadoDiario.Test.Applications.v1.AdicionarLancamento.Mocks.Repository
{
    public class RepositotyMock
    {
        public static ILancamentoRepository MockSalvarLancamentosAsync()
        {
            var mock = Substitute.For<ILancamentoRepository>();

            var fixture = new Fixture();

            mock.SalvarLancamentosAsync(Arg.Any<LancamentoDb>()).Returns(fixture.Create<LancamentoDb>());

            return mock;
        }
    }
}
