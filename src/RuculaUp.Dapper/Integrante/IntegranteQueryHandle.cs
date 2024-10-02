using MediatR;

namespace RuculaUp.Dapper.Integrante;

public class IntegranteQueryHandle : IRequestHandler<IntegrantesPorFaixaEtariaInput,List<IntegrantesPorFaixaEtariaDto>>
{
    public string StringConnection;

    public IntegranteQueryHandle(DapperConnectionString dapperConnectionString)
    {
      StringConnection = dapperConnectionString.StringConnection;
    }

  public async Task<List<IntegrantesPorFaixaEtariaDto>> Handle(IntegrantesPorFaixaEtariaInput request, CancellationToken cancellationToken)
  {
      var integrante = new  IntegrantesPorFaixaEtaria(StringConnection);
      return await integrante.SelectAsync(request); 
  }
}
