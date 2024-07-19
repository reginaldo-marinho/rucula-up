using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RuculaUp.EntityFramework;

public class IntegranteModelConfiguration : IEntityTypeConfiguration<IntegranteModel>
{
    public void Configure(EntityTypeBuilder<IntegranteModel> builder)
    {
        builder.Property(c => c.Nome).HasMaxLength(40).IsRequired();
        builder.Property(c => c.DataDeNascimento).IsRequired();
        builder.Property(c => c.Batizado).IsRequired();
        builder.Property(c => c.EstadoCivil).IsRequired();
        builder.Property(c => c.ServeNaIgreja).IsRequired();
        builder.Property(c => c.Ministerio).HasMaxLength(40).IsRequired(false);
        builder.Property(c => c.TelefoneCelular).HasMaxLength(11).IsRequired();   
    }
}
