namespace Tryphon.Domain.Entities;

public class Cidade : Entity
{
    protected Cidade()
    { }

    public Cidade(string nome, Estado estado)
    {
        Nome = nome;
        Estado = estado;
    }

    public int EstadoId
    { get { return Estado.Id; } }
    public string Nome { get; private set; }
    public Estado Estado { get; private set; }
}