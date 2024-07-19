using System.Linq.Expressions;
using RuculaUp.Domain;
using RuculaX.EntityFramework;

namespace RuculaUp.Application;

public class IntegranteRepository : RepositoryCrudMApAsync<Integrante, IntegranteDto, string>
{
    public IntegranteRepository(RepositoryCrudBaseAsync<Integrante, string> repository) : base(repository)
    {
    }

    public async override Task InsertAsync(IntegranteDto inputDto)
    {
        Integrante integrante = new() 
        {
            Id = inputDto.Id,
            Nome = inputDto.Nome,
            DataDeNascimento = inputDto.DataDeNascimento,
            Batizado = inputDto.Batizado,
            EstadoCivil = inputDto.EstadoCivil,
            ServeNaIgreja = inputDto.ServeNaIgreja,
            Ministerio = inputDto.Ministerio,
            TelefoneCelular = inputDto.TelefoneCelular
        };

        await Repository.InsertAsync(integrante);
    }

    public override Task AlterAsync(IntegranteDto inputDto)
    {
        throw new NotImplementedException();
    }

    public override Task AlterAsync(IntegranteDto inputDto, Expression<Func<Integrante, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteAsync(IntegranteDto identityDto)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteAsync(IntegranteDto inputDto, Expression<Func<Integrante, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public override Task<IntegranteDto> GetAsync(Integrante input, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public override Task<IntegranteDto> GetAsync(Expression<Func<Integrante, bool>> predicate, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
