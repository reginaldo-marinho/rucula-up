using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RuculaUp.Domain;

namespace RuculaUp.EntityFramework;

public class IntegranteConfiguration : IEntityTypeConfiguration<Integrante>
{
    public void Configure(EntityTypeBuilder<Integrante> builder)
    {
        builder.Property(c => c.Nome).HasMaxLength(40).IsRequired();
        builder.Property(c => c.DataDeNascimento).IsRequired();
        builder.Property(c => c.Batizado).IsRequired();
        builder.Property(c => c.EstadoCivil).IsRequired();
        builder.Property(c => c.ServeNaIgreja).IsRequired();
        builder.Property(c => c.Ministerio).HasMaxLength(40).IsRequired(false);
        builder.Property(c => c.TelefoneCelular).HasMaxLength(11).IsRequired();   

        builder.OwnsOne(p => p.Endereco, inte => {
            inte.HasKey(c=> c.Id).HasName("Endereco_PK");            
            inte.WithOwner().HasForeignKey(p => p.Id);
        });
    }

}