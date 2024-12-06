namespace Tryphon.Domain.Entities;

public class Estado : Entity
{
    protected Estado()
    { }

    public Estado(string sigla)
    {
        Id = Id;
        Sigla = sigla;
        _cidades = new List<Cidade>();
    }

    public string Sigla { get; private set; }
    
    private readonly List<Cidade> _cidades;
    public IReadOnlyCollection<Cidade> Cidades => _cidades.AsReadOnly();
}