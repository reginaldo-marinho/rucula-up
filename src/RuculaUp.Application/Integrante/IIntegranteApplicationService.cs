namespace RuculaUp.Application;

public interface IIntegranteApplicationService
{
    public Task InsertAsync(IntegranteDto integrante);
    public Task AlterAsync(IntegranteDto integrante);
    public Task DeleteAsync(string id);
    public Task<IntegranteDto>  GetAsync(string id);
}
