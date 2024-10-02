using Dapper;
using Npgsql;

namespace RuculaUp.Dapper.Integrante;

public class IntegrantesPorFaixaEtaria : DapperQuery<List<IntegrantesPorFaixaEtariaDto>,IntegrantesPorFaixaEtariaInput>
{
  public IntegrantesPorFaixaEtaria(string stringConnection) : base(stringConnection)
  {
  }

  public async override Task<List<IntegrantesPorFaixaEtariaDto>> SelectAsync(IntegrantesPorFaixaEtariaInput input)
  {
      using var connection = new NpgsqlConnection(StringConnection);
      var result = await  connection.QueryAsync<IntegrantesPorFaixaEtariaDto>(IntegrantesPorFaixaEtariaQuery.Query);
      return result.ToList();  
  }
}
