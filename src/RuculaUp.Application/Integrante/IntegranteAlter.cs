using RuculaUp.Domain;
using RuculaX.EntityFramework;

namespace RuculaUp.Application;

public class IntegranteAlter : IAlterMap<Integrante>
{
    private IntegranteDto _inputDto;
    public IntegranteAlter(IntegranteDto inputDto)
    {
        _inputDto = inputDto;
    }

    public Integrante Map(Integrante entity)
    {
            entity.Id = _inputDto.Id;
            entity.Nome = _inputDto.Nome;
            entity.DataDeNascimento = _inputDto.DataDeNascimento;
            entity.Batizado = _inputDto.Batizado;
            entity.EstadoCivil = _inputDto.EstadoCivil;
            entity.ServeNaIgreja = _inputDto.ServeNaIgreja;
            entity.Ministerio = _inputDto.Ministerio;
            entity.TelefoneCelular = _inputDto.TelefoneCelular;
            entity.Endereco.Id = _inputDto.Id;
            entity.Endereco.Rua = _inputDto.Endereco.Rua;
            entity.Endereco.Bairro = _inputDto.Endereco.Bairro;
            entity.Endereco.Cidade = _inputDto.Endereco.Cidade;
            
        return entity;
    }
}
