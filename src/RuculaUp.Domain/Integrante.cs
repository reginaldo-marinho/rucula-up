using RuculaX.Domain;

namespace RuculaUp.Domain;

public class Integrante : Entity<string>
{
    public string Nome { get;  set; }
    public DateOnly DataDeNascimento { get;  set; }
    public bool Batizado { get;  set; }
    public byte EstadoCivil { get;  set; } 
    public bool ServeNaIgreja { get;  set; }
    public string Ministerio { get;  set; }
    public string TelefoneCelular { get;  set; }
    public Endereco Endereco { get;  set; }    

}
