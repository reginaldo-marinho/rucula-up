namespace RuculaUp.Administration;

public sealed class Configuration
{
  public string  ProjectPath { get; set; }
  public string  PathBackupDestination { get; set; }
  public List<Project> Projects { get; set; }
}

 public sealed class Project
 {
   public string Environment { get;  set; }
   public string ProjectName { get;  set;}
   public string DockerComposeFile { get; set;}
   public string PathBackupOrigin { get; set;}
 }
