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
    
    [HttpPost]
    public async Task Post(IntegranteDto integrante)
    {
        await _integranteService.InsertAsync(integrante);
    }
}
