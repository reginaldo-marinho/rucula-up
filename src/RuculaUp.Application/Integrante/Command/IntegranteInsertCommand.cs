using MediatR;

namespace RuculaUp.Application.Command;

public class IntegranteInsertCommand : IRequest
{
    public IntegranteDto IntegranteDto { get; set; }
}
