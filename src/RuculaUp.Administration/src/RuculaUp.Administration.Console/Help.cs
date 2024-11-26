using RuculaUp.Administration;
using RuculaUp.Administration;

namespace RuculaUp;

public class Help
{
  public static void Show()
  {
    Console.WriteLine("usage: [ProjectName] [CommandName]");
    Console.WriteLine();
    Console.WriteLine($"  {CommandsNameCostants.UICreateImage}     Create new Image");
    Console.WriteLine($"  {CommandsNameCostants.UIRun}              Create new Container");
    Console.WriteLine($"  {CommandsNameCostants.UIStop}             Stop Container");
    Console.WriteLine($"  {CommandsNameCostants.UIStart}            Start Container");
    Console.WriteLine($"  {CommandsNameCostants.UIInspect}          Inspect Container");

    Console.WriteLine();
    Console.WriteLine($"  {CommandsNameCostants.AppUp}                  compose up Containers");
    Console.WriteLine($"  {CommandsNameCostants.AppDown}                compose down Containers");

    Console.WriteLine($"  {CommandsNameCostants.AppDatabaseBackup}    compose database backup");


  }
}
