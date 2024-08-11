namespace Tryphon.Domain.Entities;

public class Estado : Entity
{
    protected Estado()
    { }

    public Estado(string sigla)
    {
        Sigla = sigla;
    }

    public string Sigla { get; private set; }
}