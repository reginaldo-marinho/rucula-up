using MediatR;

namespace RuculaUp.Application.Query;

public class IntegranteQueryGet : IRequest <IntegranteDto>
{
    public string Id { get; set; }
}
