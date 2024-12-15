namespace RuculaUp.UI.Server.Test;

[TestClass]
public class UnitTest1
{
  [TestMethod]
  public void TestMethod1()
  {
      var value = Server.GetWindow("my-test.json");
      Assert.AreEqual("{}\n", value);
  }
}
