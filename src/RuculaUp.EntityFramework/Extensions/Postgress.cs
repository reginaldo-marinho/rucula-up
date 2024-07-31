using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RuculaUp.EntityFramework;

public static class Postgress
{
    public static void AddPostgressContext(this IServiceCollection services,  string environment, IConfigurationManager configurationManager)
    {
        string connectionString = "";
        
        if(environment == "Development")
        {
            connectionString = "Host=127.0.0.1;Database=Church;;Username={USERNAME};Password={PASSWORD}"
            .Replace("{USERNAME}",configurationManager["Church:Username"])
            .Replace("{PASSWORD}",configurationManager["Church:Password"]); 
        }

        if(environment == "Staging")
        {
            connectionString = 
            "Host={DB_HOST};Database=rucula_hom;Username={DB_USER};Password={DB_PASSWORD}"
                .Replace("{DB_HOST}", Environment.GetEnvironmentVariable("DB_HOST"))
                .Replace("{DB_USER}", Environment.GetEnvironmentVariable("DB_USER"))
                .Replace("{DB_PASSWORD}", Environment.GetEnvironmentVariable("DB_PASSWORD"));
        }

        if(environment == "Production")
        {
            connectionString = 
                "Host={DB_HOST};Database=rucula_prd;Username={DB_USER};Password={DB_PASSWORD}"
                .Replace("{DB_HOST}", Environment.GetEnvironmentVariable("DB_HOST"))
                .Replace("{DB_USER}", Environment.GetEnvironmentVariable("DB_USER"))
                .Replace("{DB_PASSWORD}", Environment.GetEnvironmentVariable("DB_PASSWORD"));
        }
        
        
        services.AddDbContext<DbContext,ApplicationContext>(options =>
                options.UseNpgsql(connectionString));
    }
}
