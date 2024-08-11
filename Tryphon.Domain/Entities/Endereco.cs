namespace Tryphon.Domain.Entities;

public class Endereco : Entity
{
    protected Endereco()
    { }

    public Endereco(string logradouro, Cidade cidade)
    {
        Logradouro = logradouro;
        Cidade = cidade;
    }

    public string Logradouro { get; private set; }
    public Cidade Cidade { get; private set; }
    public IReadOnlyCollection<Processo> Processos { get; private set; }
}