namespace RuculaUp.Dapper;

public abstract class DapperQuery<TOutput,TInput>(string stringConnection)
{
  protected string StringConnection = stringConnection;

  public abstract Task<TOutput> SelectAsync(TInput input);
}