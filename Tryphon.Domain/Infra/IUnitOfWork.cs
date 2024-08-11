namespace Tryphon.Domain.Infra;

public interface IUnitOfWork
{
    IProcessoRepository Processos { get; }
    IStatusRepository Status { get; }
    IEnderecoRepository Endereco { get; }
    ICidadeRepository Cidade { get; }
    IEstadoRepository Estado { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}