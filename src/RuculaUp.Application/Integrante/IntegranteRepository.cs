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

    public async override Task AlterAsync(IntegranteDto inputDto)
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

        await Repository.AlterAsync(integrante);

    }

    public override Task AlterAsync(IntegranteDto inputDto, Expression<Func<Integrante, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async override Task DeleteAsync(IntegranteDto identityDto)
    {
        await Repository.DeleteAsync(
            new Integrante {
             Id = identityDto.Id
        });
    }

    public override Task DeleteAsync(IntegranteDto inputDto, Expression<Func<Integrante, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async override Task<IntegranteDto> GetAsync(Integrante input, CancellationToken token)
    {
        var result = await this.Repository.GetAsync(input);
        

        IntegranteDto integrante = new() 
        {
            Id = result.Id,
            Nome = result.Nome,
            DataDeNascimento = result.DataDeNascimento,
            Batizado = result.Batizado,
            EstadoCivil = result.EstadoCivil,
            ServeNaIgreja = result.ServeNaIgreja,
            Ministerio = result.Ministerio,
            TelefoneCelular = result.TelefoneCelular
        };

        return integrante;
    }

    public override Task<IntegranteDto> GetAsync(Expression<Func<Integrante, bool>> predicate, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
