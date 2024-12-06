namespace Tryphon.Domain.Entities;

public class Processo : Aggregator
{
    protected Processo()
    {
    }

    public Processo(string codigo, Endereco endereco)
    {
        if(string.IsNullOrWhiteSpace(codigo)) throw new BusinessException(codigo);
        Id = 0;
        Codigo = codigo;
        Endereco = endereco;
        Status = Status.Aberto;
    }

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