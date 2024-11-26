namespace RuculaUp.Administration;

public sealed class CommandListAll : Command
{
  public CommandListAll() : base(RuculaUpAdministrationConstants.ProjectNameRoot)
  {
  }
  public override string GetCommand(string options = "") =>  $"docker ps";
}
