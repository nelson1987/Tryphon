namespace Tryphon.Domain.Entities;

public class Status : Entity
{
    protected Status()
    { }

    public Status(string sigla)
    {
        Sigla = sigla;
    }
    public static Status Aberto => new Status("ABT");
    public string Sigla { get; private set; }
    public IReadOnlyCollection<Processo> Processos { get; private set; }
}