using MediatR;

namespace RuculaUp.Application.Command;

public class IntegranteDeleteCommand : IRequest
{
    public string Id { get; set; }
}