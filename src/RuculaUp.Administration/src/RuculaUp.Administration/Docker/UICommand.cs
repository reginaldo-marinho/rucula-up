
namespace RuculaUp.Administration.Docker;

public class UICommand : Command
{
    public UICommand(string projectName) : base(projectName)
    {
    }
    public override string GetCommand(string options) => commandName(options);

    private static string commandName(string options) => options switch
    {
      CommandsNameCostants.UICreateImage => $"docker build -t rucula-ui {RuculaUpAdministrationConstants.PathProject}/src/RuculaUp.WebUi",
      CommandsNameCostants.UIRun => $"docker run -d --name rucula-ui -p 9000:9000 --restart always --network application rucula-ui",
      CommandsNameCostants.UIStart => $"docker start rucula-ui",
      CommandsNameCostants.UIStop => $"docker stop rucula-ui",
      CommandsNameCostants.UIInspect => $"docker inspect rucula-ui",
      _ => throw new ("Invalid command name"),
    };
}
