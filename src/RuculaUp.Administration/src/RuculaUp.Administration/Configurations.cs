using System.Collections.Immutable;
using System.Text.Json;

namespace RuculaUp.Administration;

public static class Configurations
{
    private static Configuration? configuration = null;

    public static Configuration Get()
    {
      CreateInstance();
      return configuration;
    }

    public static bool Exist(string projecName)
    {
      CreateInstance();
      var project = configuration.Projects.FirstOrDefault(c => c.ProjectName == projecName);

      return project is not null;
    }

    private static void CreateInstance()
    {
      if(configuration is null)
      {
        var configurationFile  = File.ReadAllText("Rucula.Up.Configuration.json");
        configuration = JsonSerializer.Deserialize<Configuration>(configurationFile);
      }
    }

}
