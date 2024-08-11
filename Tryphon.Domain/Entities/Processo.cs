namespace Tryphon.Domain.Entities;

public class Processo : Entity
{
    public string Codigo { get; private set; }

    public int EnderecoId
    { get { return Endereco.Id; } }

    public Endereco Endereco { get; private set; }

    public int StatusId
    { get { return Status.Id; } }

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