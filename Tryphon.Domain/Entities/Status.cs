namespace Tryphon.Domain.Entities;

public class Status : Entity
{
    protected Status()
    { }

    public Status(string sigla)
    {
        Sigla = sigla;
    }

    public string Sigla { get; private set; }
}