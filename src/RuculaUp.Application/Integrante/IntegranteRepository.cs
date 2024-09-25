using Microsoft.EntityFrameworkCore;
using RuculaUp.Domain;
using RuculaX.EntityFramework;

namespace RuculaUp.Application;

public sealed class IntegranteRepository : RepositoryCrudBaseAsync<Integrante, string>
{
  public IntegranteRepository(DbContext context) : base(context)
  {

  }
}
