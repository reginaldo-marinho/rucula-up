namespace RuculaUp.UI.Server;
public class Server
{
  public static string GetWindow(string window)
  {
      var pathConfigurations  = File.ReadLines("UISERVERFOLDER").First();
      return File.ReadAllText($"{pathConfigurations}/window/{window}");
  }
}
