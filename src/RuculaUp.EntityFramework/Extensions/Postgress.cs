using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RuculaUp.EntityFramework;

public static class Postgress
{
    public static void AddPostgressContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DbContext,ApplicationContext>(options =>
                options.UseNpgsql(connectionString));
    }
}
