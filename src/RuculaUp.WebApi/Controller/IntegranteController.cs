using MediatR;
using Microsoft.AspNetCore.Mvc;
using RuculaUp.Application;
using RuculaUp.Application.Command;
using RuculaUp.Application.Query;


namespace RuculaX.WebApi;

[ApiController]
[Route("[controller]")]
public class IntegranteController : ControllerBase
{
    IMediator _mediator;
    public IntegranteController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IntegranteDto> Get(string id)
    {
        var query = new IntegranteQueryGet { 
            Id = id
        };
        
        var result = await _mediator.Send(query);
        
        return result;
    }
    
    [HttpPost]
    public async Task Post(IntegranteDto integrante)
    {
        var command = new IntegranteInsertCommand { 
            IntegranteDto = integrante
        };
        
        await _mediator.Send(command);
    }

    [HttpPut]
    public async Task Put(IntegranteDto integrante)
    {
        var command = new IntegranteAlterCommand { 
            IntegranteDto = integrante
        };

        await _mediator.Send(command);
    }

    [HttpDelete]
    public async Task Delete(string id)
    {
        var command = new IntegranteDeleteCommand { 
            Id = id
        };
        await _mediator.Send(command);    
    }
}

