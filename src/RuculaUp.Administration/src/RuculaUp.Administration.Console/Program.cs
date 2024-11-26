
using System.Text.RegularExpressions;
using Figgle;
using RuculaUp;
using RuculaUp.Administration;
using RuculaUp.Administration.Docker;

if (args.Length == 0)
{
  Console.ForegroundColor = ConsoleColor.Yellow;
  Console.WriteLine(FiggleFonts.Ogre.Render("rucula up"));
  Console.ResetColor();
  Console.WriteLine("Welcome to rucula-up cli");
  Console.WriteLine("Please, enter a command or enter a --help for a list of available commands. ");

  Help.Show();
  return;
}

  var target = args[0];

  if (target == "--help")
  {
    return;
  }

  ICommand command = null;
  var isRoot = true;

  switch (target)
  {
    case "list-all":
      command = new CommandListAll();
      break;
    default:
      isRoot = false;
      break;
  }

  if (isRoot)
  {
    command?.Run();
    return;
  }


  if (Configurations.Exist(target) == false)
  {
    throw new Exception("Project Name not found");
  }

  var principalCommand = Regex.Match(args[1], @"(^[A-z]+)-");

  if (principalCommand.Success == false)
  {
    return;
  }

  switch (principalCommand.Groups[1].Value)
  {
    case CommandsNameCostants.PrincipalCommandUi:
      new UICommand(target).Run(args[1]);
      break;
    case CommandsNameCostants.PrincipalCommandApp:
      new AppCommand(target).Run(args[1]);
      break;
    default:
      Console.WriteLine($"Command {args[1]} is not recognized");
      break;
  }




