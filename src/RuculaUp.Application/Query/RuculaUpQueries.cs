using RuculaX.Database.Query;

namespace RuculaUp.Application;

public class RuculaUpQueries : Queries
{
    public RuculaUpQueries()
    {
        Set(nameof(IntegranteQueryPaged), typeof(IntegranteQueryPaged));
    }
}
