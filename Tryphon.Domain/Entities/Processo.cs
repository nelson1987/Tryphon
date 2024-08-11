namespace Tryphon.Domain.Entities;

public class Processo : Entity
{
    public string Codigo { get; private set; }

    public Endereco Endereco { get; private set; }

    public Status Status { get; private set; }

    public void AlteracaoCodigo(string codigo)
    {
        Codigo = codigo;
    }

    public void AlteracaoStatus(Status status)
    {
        Status = status;
    }

    public void AlteracaoEndereco(Endereco endereco)
    {
        Endereco = endereco;
    }
}