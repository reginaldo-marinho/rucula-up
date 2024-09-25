using MediatR;
using Microsoft.EntityFrameworkCore;
using RuculaUp.Domain;
using RuculaX.EntityFramework;

namespace RuculaUp.Application.Command;

public class IntegranteCommand :  IRequestHandler<IntegranteInsertCommand>,
                                        IRequestHandler<IntegranteAlterCommand>,
                                        IRequestHandler<IntegranteDeleteCommand>                                         
{
    private UnitOfWorkAsync _unitOfWork;
    private IntegranteRepository _repository;
    public IntegranteCommand(IntegranteRepository repository, UnitOfWorkAsync unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(IntegranteInsertCommand request, CancellationToken cancellationToken)
    {
            await _unitOfWork.BeginAsync();
            
            Integrante integrante = new() 
            {
                Id = request.IntegranteDto.Id,
                Nome = request.IntegranteDto.Nome,
                DataDeNascimento = request.IntegranteDto.DataDeNascimento,
                Batizado = request.IntegranteDto.Batizado,
                EstadoCivil = request.IntegranteDto.EstadoCivil,
                ServeNaIgreja = request.IntegranteDto.ServeNaIgreja,
                Ministerio = request.IntegranteDto.Ministerio,
                TelefoneCelular = request.IntegranteDto.TelefoneCelular,
                Endereco = new Endereco {
                    Id = request.IntegranteDto.Id,
                    Rua = request.IntegranteDto.Endereco.Rua,
                    Bairro = request.IntegranteDto.Endereco.Bairro,
                    Cidade = request.IntegranteDto.Endereco.Cidade,
                }
            };

            await _repository.InsertAsync(integrante);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();
    }

    public async Task Handle(IntegranteAlterCommand request, CancellationToken cancellationToken)
    {
            await _unitOfWork.BeginAsync();
            
            var integranteMap = new IntegranteAlter(request.IntegranteDto);

            Integrante integrante = new() 
            {
                Id = request.IntegranteDto.Id
            };

            var set = _repository.DbSet.Include( c=> c.Endereco);
            await _repository.AlterAsync(integrante, integranteMap, set);

            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();
    }

    public async Task Handle(IntegranteDeleteCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginAsync();

            await _repository.DeleteAsync(
                new Integrante {
                Id = request.Id
            });
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();
    }
}
