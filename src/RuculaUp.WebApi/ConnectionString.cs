using System;

namespace RuculaUp.WebApi;

public class ConnectionStringPostgres
{
    public string ConnectionString {get; private set;}
    public ConnectionStringPostgres(string environment, IConfigurationManager configurationManager)
    {
        
        if(environment == "Development")
        {
            ConnectionString = "Host=127.0.0.1;Database=Church;;Username={USERNAME};Password={PASSWORD}"
            .Replace("{USERNAME}",configurationManager["Church:Username"])
            .Replace("{PASSWORD}",configurationManager["Church:Password"]); 
        }

        if(environment == "Staging")
        {
            ConnectionString = 
            "Host=DB_STAGING;Database=rucula_hom;Username={DB_USER};Password={DB_PASSWORD}"
                .Replace("{DB_HOST}", Environment.GetEnvironmentVariable("DB_HOST"))
                .Replace("{DB_USER}", Environment.GetEnvironmentVariable("DB_USER"))
                .Replace("{DB_PASSWORD}", Environment.GetEnvironmentVariable("DB_PASSWORD"));
        }

        if(environment == "Production")
        {
            ConnectionString = 
                "Host=DB_PRODUCTION;Database=rucula_prd;Username={DB_USER};Password={DB_PASSWORD}"
                .Replace("{DB_HOST}", Environment.GetEnvironmentVariable("DB_HOST"))
                .Replace("{DB_USER}", Environment.GetEnvironmentVariable("DB_USER"))
                .Replace("{DB_PASSWORD}", Environment.GetEnvironmentVariable("DB_PASSWORD"));
        }
    }
}
