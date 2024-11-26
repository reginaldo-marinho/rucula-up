namespace RuculaUp.Administration;

public class ConfigurationBase
{
    public string ProjectName { get; private set; }
    public string DockerComposeFile { get; private set; }
    public string PathBackupOrigin { get; private set; }
    public string PathBackupDestination { get; private set; }
    public string OS { get; private set; }
    public string Terminal { get; private set; }
    public ConfigurationBase(string projectName)
    {
      if (projectName != RuculaUpAdministrationConstants.ProjectNameRoot)
      {
        var configuration = Configurations.Get();
        var project = configuration.Projects.First(c => c.ProjectName == projectName);
        DockerComposeFile =  $"{configuration.ProjectPath}/{project.DockerComposeFile}" ;
        ProjectName = project.ProjectName;
        PathBackupOrigin = project.PathBackupOrigin;
        PathBackupDestination = configuration.PathBackupDestination;
      }

      OpetationSystem();
    }
    private void OpetationSystem()
    {
        if(OperatingSystem.IsLinux())
        {
            OS = RuculaUpAdministrationConstants.OperationSystemLinux;
            Terminal = RuculaUpAdministrationConstants.TerminalLinuxBash;
            return;
        }
        if(OperatingSystem.IsWindows())
        {
            OS = RuculaUpAdministrationConstants.OperationSystemWindows;
            Terminal = RuculaUpAdministrationConstants.TerminalWindows;
            return;
        }

        throw new Exception("");
    }
}
