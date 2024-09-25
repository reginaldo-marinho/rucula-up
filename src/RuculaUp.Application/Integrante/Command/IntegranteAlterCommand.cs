using System;
using MediatR;

namespace RuculaUp.Application.Command;

public class IntegranteAlterCommand : IRequest
{
    public IntegranteDto IntegranteDto { get; set; }
}
