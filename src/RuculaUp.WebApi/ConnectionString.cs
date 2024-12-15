using System;
using System.Net;

namespace RuculaUp.WebApi;

public class ConnectionStringPostgres
{
    public string? ConnectionString {get; private set;}
    public ConnectionStringPostgres(string environment, IConfigurationManager configurationManager)
    {
      var  isContainer =  Environment.GetEnvironmentVariable("ENVIRONMENT_CONTAINER");
      var descriptionConnectionStringMessage = configurationManager["DescriptionConnectionStringMessage"];

      if (isContainer is null)
      {
          ShowMessageConnectionString("Connected with CLI dotnet user-secrets");

          ConnectionString = "Host=127.0.0.1;Database=Church;Username={USERNAME};Password={PASSWORD}"
          .Replace("{USERNAME}",configurationManager["Church:Username"])
          .Replace("{PASSWORD}",configurationManager["Church:Password"]);

          ShowMessageConnectionString(descriptionConnectionStringMessage);
          return;
      }

      var host = Environment.GetEnvironmentVariable("DB_HOST");
      var user = Environment.GetEnvironmentVariable("DB_USER");
      var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

      ConnectionString = configurationManager.GetConnectionString("PSQL")
        .Replace("{DB_HOST}",host)
        .Replace("{DB_USER}",user)
        .Replace("{DB_PASSWORD}",password);
      if (ConnectionString is null)
      {
        throw new NullReferenceException("Connection string not found");
      }
      ShowMessageConnectionString(host);
      ShowMessageConnectionString(descriptionConnectionStringMessage);
    }

    private void ShowMessageConnectionString(string? descriptionConnectionStringMessage = "")
    {
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine($"rucula-up: {descriptionConnectionStringMessage}");
      Console.ResetColor();
    }
}
