using System;

namespace RuculaUp.Dapper.Integrante;

public record IntegrantesPorFaixaEtariaDto
{
    public string FaixaEtaria { get; set; }
    public int Total { get; set; }
}
