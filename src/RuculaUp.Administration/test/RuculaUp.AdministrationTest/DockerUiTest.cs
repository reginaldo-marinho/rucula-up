using RuculaUp.Administration;
using RuculaUp.Administration.Docker;

namespace RuculaUp.AdministrationTest;

[TestClass]
public class DockerUiTest
{
    UICommand UI;

    public DockerUiTest()
    {
        UI = new UICommand("project-of-test");
    }

    [TestMethod]
    public void PrincipalCommandUi_ShouldBe_Ui()
    {
      Assert.AreEqual("ui", CommandsNameCostants.PrincipalCommandUi);
    }

    [TestMethod]
    public void UICreateImage_ShouldBe_CorrectValue()
    {
      Assert.AreEqual("ui-image-create", CommandsNameCostants.UICreateImage);
    }

    [TestMethod]
    public void UIRun_ShouldBe_CorrectValue()
    {
      Assert.AreEqual("ui-run", CommandsNameCostants.UIRun);
    }

    [TestMethod]
    public void UIStart_ShouldBe_CorrectValue()
    {
      Assert.AreEqual("ui-start", CommandsNameCostants.UIStart);
    }

    [TestMethod]
    public void UIStop_ShouldBe_CorrectValue()
    {
      Assert.AreEqual("ui-stop", CommandsNameCostants.UIStop);
    }

    [TestMethod]
    public void UIInspect_ShouldBe_CorrectValue()
    {
      Assert.AreEqual("ui-inspect", CommandsNameCostants.UIInspect);
    }

      [TestMethod]
      public void UICreateImage_ShouldHaveCorrectValue()
      {
        string expected =
          $"docker build -t rucula-ui ${RuculaUpAdministrationConstants.PathProject}/src/RuculaUp.WebUi";
        var actual = UI.GetCommand(CommandsNameCostants.UICreateImage);

        Assert.AreEqual(expected, actual);
      }

      [TestMethod]
      public void UIRun_ShouldHaveCorrectValue()
      {
        string expected = "docker run -d --name rucula-ui -p 9000:9000 --restart always --network application rucula-ui";
        string actual = UI.GetCommand(CommandsNameCostants.UIRun);

        Assert.AreEqual(expected, actual);
      }

      [TestMethod]
      public void UIStart_ShouldHaveCorrectValue()
      {
        string expected = "docker start rucula-ui";
        string actual = UI.GetCommand(CommandsNameCostants.UIStart);

        Assert.AreEqual(expected, actual);
      }

      [TestMethod]
      public void UIStop_ShouldHaveCorrectValue()
      {
        string expected = "docker stop rucula-ui";
        string actual = UI.GetCommand( CommandsNameCostants.UIStop);

        Assert.AreEqual(expected, actual);
      }

      [TestMethod]
      public void UIInspect_ShouldHaveCorrectValue()
      {
        string expected = "docker inspect rucula-ui";
        string actual = UI.GetCommand(CommandsNameCostants.UIInspect);

        Assert.AreEqual(expected, actual);
      }
}
