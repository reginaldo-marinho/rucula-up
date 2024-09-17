using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RuculaUp.Application;
using RuculaUp.EntityFramework;


namespace RuculaX.WebApi;

[ApiController]
[Route("[controller]")]
public class IntegranteController : ControllerBase
{
    IIntegranteApplicationService _integranteService;

    ApplicationContext ctx;
    public IntegranteController(IIntegranteApplicationService integranteService, ApplicationContext context)
    {
        _integranteService = integranteService;
        ctx = context;
    }
    
    [HttpGet]
    public async Task<IntegranteDto> Get(string id)
    {
        var result = await _integranteService.GetAsync(id);
        return result;
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

