using RuculaUp.Administration;

namespace RuculaUp.AdministrationTest;

[TestClass]
public class ConfigurationDefaultTest
{
  [TestMethod]
  public void Test()
  {
    var configs = Configurations.Get();
    var a = configs;

  }
}
