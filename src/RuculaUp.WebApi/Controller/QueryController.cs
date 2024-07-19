using Microsoft.AspNetCore.Mvc;
using RuculaUp.EntityFramework;
using RuculaX.Database.Query;

namespace RuculaIUp.WebApi;

[ApiController]
[Route("[controller]")]
public class QueryController : ControllerBase
{
    private readonly FactoryQuery<ApplicationContext> _query;
    public QueryController(FactoryQuery<ApplicationContext> query)
    {
        _query = query;
    }

    [HttpPost]
    public Task<IQueryConfigurationOutput> Post(QueryConfigurationInput configuration)
    {
        return _query.QueryAsync(configuration);
    }
}
