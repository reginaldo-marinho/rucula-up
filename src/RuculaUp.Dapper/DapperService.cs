using Microsoft.Extensions.DependencyInjection;
using RuculaUp.Dapper.Integrante;

namespace RuculaUp.Dapper;

public static class DapperService
{
    public static IServiceCollection AddDapper(this IServiceCollection services,  string connectionString)
    {
        services.AddScoped(connection => new DapperConnectionString(connectionString));

        services.AddScoped<IntegranteQueryHandle>();
        
        return services;
    }
}
