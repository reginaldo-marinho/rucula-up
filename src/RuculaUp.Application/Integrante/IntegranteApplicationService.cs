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
}