using RuculaUp.Domain;
using RuculaX.EntityFramework;

namespace RuculaUp.Application;

public class IntegranteApplicationService : IIntegranteApplicationService
{
    UnitOfWorkAsync _unitOfWork;
    IntegranteRepository _repository;
    public IntegranteApplicationService(IntegranteRepository repository, UnitOfWorkAsync unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task  InsertAsync(IntegranteDto integrante)
    {
        await _unitOfWork.BeginAsync();
        await _repository.InsertAsync(integrante);
        await _unitOfWork.SaveChangesAsync();
        await _unitOfWork.CommitAsync();
    }

    public async Task AlterAsync(IntegranteDto integrante)
    {
        await _unitOfWork.BeginAsync();
        await _repository.AlterAsync(integrante);
        await _unitOfWork.SaveChangesAsync();
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteAsync(string id)
    {
        await _unitOfWork.BeginAsync();
        await _repository.DeleteAsync(new IntegranteDto{
             Id = id
        });
        await _unitOfWork.SaveChangesAsync();
        await _unitOfWork.CommitAsync();
    }

    public async Task<IntegranteDto> GetAsync(string id)
    {
       var result = await this._repository.GetAsync(new Integrante {
        Id = id
       }, CancellationToken.None);


       return result;
    }
}