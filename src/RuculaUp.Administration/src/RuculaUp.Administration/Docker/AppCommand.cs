namespace RuculaUp.Administration;

public sealed class AppCommand : Command
{
    public AppCommand(string projectName) : base(projectName){}
    public override string GetCommand(string options) =>  commandName(options, this.ConfigurationBase);

    private static string commandName(string options,  ConfigurationBase configurationBase) => options switch
    {
      CommandsNameCostants.AppUp => $"docker compose -f {configurationBase.DockerComposeFile} -p {configurationBase.ProjectName} up -d",
      CommandsNameCostants.AppUpBuild => $"docker compose -f {configurationBase.DockerComposeFile} -p {configurationBase.ProjectName} up -d --build",
      CommandsNameCostants.AppDown => $"docker compose -f {configurationBase.DockerComposeFile} -p {configurationBase.ProjectName}  down",
      CommandsNameCostants.AppRemove => $"docker compose -p  {configurationBase.ProjectName} rm --force",
      CommandsNameCostants.AppStop => $"docker compose -p  {configurationBase.ProjectName} stop",
      CommandsNameCostants.AppDatabaseBackup => $"docker run --rm --volumes-from db_postgres_{configurationBase.ProjectName} -v {configurationBase.PathBackupDestination}:/backup ubuntu tar cvf /backup/backup_{configurationBase.ProjectName}_{DateTime.Now.ToString("yyyyMMddTHHmmssfffffffK")}.tar {configurationBase.PathBackupOrigin}",
      CommandsNameCostants.AppDtBExec => $"docker exec -it db_postgres{configurationBase.ProjectName} /bin/bash",
      _ => throw new ("Invalid command name"),
    };
}
