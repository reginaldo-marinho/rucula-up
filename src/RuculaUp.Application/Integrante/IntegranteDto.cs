using RuculaX.Domain;

namespace RuculaUp.Application;

public record IntegranteDto: IEntityDto
{
    public string Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataDeNascimento { get; set; }
    public bool Batizado { get; set; }
    public byte EstadoCivil { get; set; } 
    public bool ServeNaIgreja { get; set; }
    public string Ministerio { get; set; }
    public string TelefoneCelular { get; set; }
}