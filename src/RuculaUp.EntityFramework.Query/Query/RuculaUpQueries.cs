using RuculaX.Database.Query;

namespace RuculaUp.EntityFramework.Query;

public class RuculaUpQueries : Queries
{
    public RuculaUpQueries()
    {
        Set(nameof(IntegranteQueryPaged), typeof(IntegranteQueryPaged));
    }
}
