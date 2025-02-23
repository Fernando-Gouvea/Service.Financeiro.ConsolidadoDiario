using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Financeiro.ConsolidadoDiario.Application.Query.v1.BuscarConsolidado;

namespace Service.Financeiro.ConsolidadoDiario.Presentation.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsolidadoController(IMediator _mediator) : ControllerBase
    {
        [HttpGet("[action]/{data}")]
        public async Task<IActionResult> BuscarConsolidadoAsync(DateTime data)
        {
            var result = await _mediator.Send(new BuscarConsolidadoQuery { Data = data });

            return Ok(result);
        }
    }
}
