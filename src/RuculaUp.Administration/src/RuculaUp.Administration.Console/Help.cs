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
    Console.WriteLine($"  {CommandsNameCostants.AppUp}        compose up Containers");
    Console.WriteLine($"  {CommandsNameCostants.AppUpBuild}  compose up Containers and force build images");
    Console.WriteLine($"  {CommandsNameCostants.AppDown}      compose down Containers");

    Console.WriteLine($"  {CommandsNameCostants.AppStart}     compose start container(s)");
    Console.WriteLine($"  {CommandsNameCostants.AppRemove}        compose remove container(s)");
    Console.WriteLine($"  {CommandsNameCostants.AppStop}      compose stop container(s)");

    Console.WriteLine($"  {CommandsNameCostants.AppDtBExec} compose exec iterative mode container");
    Console.WriteLine($"  {CommandsNameCostants.AppDatabaseBackup} compose container(database) backup");


    Console.WriteLine();

  }
}
