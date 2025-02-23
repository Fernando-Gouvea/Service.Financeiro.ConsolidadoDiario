using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Service.Financeiro.ConsolidadoDiario.Presentation.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsolidadoController(IMediator _mediator) : ControllerBase
    {
        [HttpGet("[action]/{date}")]
        public async Task<IActionResult> BuscarConlidadoAsync(DateTime date)
        {
           // var result = await _mediator.Send();

            return Ok();
        }
    }
}
