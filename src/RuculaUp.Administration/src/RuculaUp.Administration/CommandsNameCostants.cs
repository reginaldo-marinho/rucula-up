namespace RuculaUp.Administration;

public class CommandsNameCostants
{
  public const string PrincipalCommandUi = "ui";
  public const string PrincipalCommandApp = "app";
  /// <summary>
  /// Init new Container for Image Ui
  /// </summary>
  public const string UICreateImage = $"{PrincipalCommandUi}-image-create";
  /// <summary>
  /// Init new Container for Image Ui
  /// </summary>
  public const string UIRun = $"{PrincipalCommandUi}-run";
  /// <summary>
  /// Start Container
  /// </summary>
  public const string UIStart = $"{PrincipalCommandUi}-start";
  /// <summary>
  /// Stop Container
  /// </summary>
  public const string UIStop = $"{PrincipalCommandUi}-stop";
  /// <summary>
  /// Inspect Container
  /// </summary>
  public const string UIInspect = $"{PrincipalCommandUi}-inspect";

  public const string AppUp = $"{PrincipalCommandApp}-up";
  public const string AppUpBuild = $"{PrincipalCommandApp}-up-build";
  public const string AppStart = $"{PrincipalCommandApp}-start";
  public const string AppDown = $"{PrincipalCommandApp}-down";
  public const string AppRemove = $"{PrincipalCommandApp}-rm";
  public const string AppStop = $"{PrincipalCommandApp}-stop";
  public const string AppDtBExec = $"{PrincipalCommandApp}-db-exec";
  public const string AppDatabaseBackup = $"{PrincipalCommandApp}-db-backup";
}
