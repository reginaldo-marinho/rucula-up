
using MediatR;
using Microsoft.EntityFrameworkCore;
using RuculaUp.Domain;

namespace RuculaUp.Application.Query;

public class IntegranteQueryHandle : IRequestHandler<IntegranteQueryGet,IntegranteDto>
{
    IntegranteRepository _repository;

    public IntegranteQueryHandle(IntegranteRepository repository)
    {
        _repository = repository;
    }

  public async Task<IntegranteDto> Handle(IntegranteQueryGet request, CancellationToken cancellationToken)
  {
        var config = this._repository.DbSet.Include(c=> c.Endereco);

        var filter = new Integrante {
            Id  = request.Id
        };

        var result = await this._repository.GetAsync(filter, config);
        
        IntegranteDto integrante = new() 
        {
            Id = result.Id,
            Nome = result.Nome,
            DataDeNascimento = result.DataDeNascimento.ToDateTime(TimeOnly.MinValue),
            Batizado = result.Batizado,
            EstadoCivil = result.EstadoCivil,
            ServeNaIgreja = result.ServeNaIgreja,
            Ministerio = result.Ministerio,
            TelefoneCelular = result.TelefoneCelular,
            Endereco = new EnderecoDto(){
                 
                  Rua = result.Endereco.Rua,
                  Bairro = result.Endereco.Bairro,
                  Cidade = result.Endereco.Cidade
            }
        };

       return integrante;
  }
}
