using MediatR;
using Microsoft.AspNetCore.Mvc;
using RuculaUp.Dapper.Integrante;

namespace RuculaUp.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntegranteQueryController : ControllerBase
    {
        IMediator _mediator;
        public IntegranteQueryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<IntegrantesPorFaixaEtariaDto>> Get()
        {
               
            
            var result = await _mediator.Send(new IntegrantesPorFaixaEtariaInput());
            
            return result;
        }
    }
}
