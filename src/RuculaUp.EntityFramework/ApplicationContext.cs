using Microsoft.EntityFrameworkCore;
using RuculaUp.Domain;

namespace RuculaUp.EntityFramework;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public DbSet<Integrante> Integrante {get;set;}     
    
    
}
