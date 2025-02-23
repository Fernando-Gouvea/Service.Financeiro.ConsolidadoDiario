using AutoFixture;
using AutoMapper;
using NSubstitute;
using Service.Financeiro.Lancamento.Application.Applications.v1.AdicionarLancamento;
using LancamentoDb = Service.Financeiro.Lancamento.Domain.Entities.Lancamento;

namespace Service.Financeiro.ConsolidadoDiario.Test.Applications.v1.AdicionarLancamento.Mocks.Mapper
{
    public class MapperMock
    {
        public static IMapper GetMock()
        {
            var mock = Substitute.For<IMapper>();

            var fixture = new Fixture();

            mock.Map<AdicionarLancamentoCommand>(Arg.Any<LancamentoDb>()).Returns(fixture.Create<AdicionarLancamentoCommand>());
            mock.Map<AdicionarLancamentoCommandResponse>(Arg.Any<LancamentoDb>()).Returns(fixture.Create<AdicionarLancamentoCommandResponse>());

            return mock;
        }
    }
}