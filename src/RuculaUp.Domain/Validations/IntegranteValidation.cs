using FluentValidation;

namespace RuculaUp.Domain;

public class IntegranteValidation : AbstractValidator<Integrante>
{
    public IntegranteValidation()
    {
        RuleFor(c => c.Nome);
        RuleFor(c => c.DataDeNascimento);
        RuleFor(c => c.Batizado);
        RuleFor(c => c.EstadoCivil);
        RuleFor(c => c.ServeNaIgreja);
        RuleFor(c => c.Ministerio);
        RuleFor(c => c.TelefoneCelular);
    }
}
