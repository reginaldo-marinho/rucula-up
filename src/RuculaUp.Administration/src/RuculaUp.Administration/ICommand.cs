namespace RuculaUp.Administration;

public interface ICommand
{
    void Run(string options = "");
    string GetCommand(string options = "");
}
