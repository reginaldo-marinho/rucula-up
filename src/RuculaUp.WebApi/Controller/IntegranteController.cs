using Microsoft.AspNetCore.Mvc;
using RuculaUp.Application;


namespace RuculaX.WebApi;

[ApiController]
[Route("[controller]")]
public class IntegranteController : ControllerBase
{
    IIntegranteApplicationService _integranteService;

    public IntegranteController(IIntegranteApplicationService integranteService)
    {
        _integranteService = integranteService;
    }
    
    [HttpGet]
    public async Task<IntegranteDto> Get(string id)
    {
        return await _integranteService.GetAsync(id);
    }
    
    [HttpPost]
    public async Task Post(IntegranteDto integrante)
    {
        await _integranteService.InsertAsync(integrante);
    }
    
    [HttpPut]
    public async Task Put(IntegranteDto integrante)
    {
        await _integranteService.AlterAsync(integrante);
    }

    [HttpDelete]
    public async Task Delete(string id)
    {
        await _integranteService.DeleteAsync(id);
    }
}

