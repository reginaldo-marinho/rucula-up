using System.Diagnostics;
using System.Text;

namespace RuculaUp.Administration;

public abstract class Command : ICommand
{
    protected ConfigurationBase ConfigurationBase;

    public Command(string projectName)
    {
      ConfigurationBase =  new ConfigurationBase(projectName);
    }
    public void Run(string options = "")
    {
      using var process = new Process();

      string? command = null;

      if(ConfigurationBase.OS == RuculaUpAdministrationConstants.OperationSystemLinux)
      {
        command = $" -c \"{GetCommand(options)}\"";
      }

      if(command is null)
      {
        throw new NullReferenceException($"{nameof(command)} is null");
      }

      Console.WriteLine(command);

      ProcessStartInfo startInfo = new(ConfigurationBase.Terminal)
      {
        Arguments = command,
        UseShellExecute = false
      };

      process.StartInfo = startInfo;
      process.Start();
    }
    public abstract string GetCommand(string options = "");
}
