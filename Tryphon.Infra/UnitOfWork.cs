using Tryphon.Domain.Infra;

namespace Tryphon.Infra;

public class UnitOfWork : IUnitOfWork
{
    private readonly TesteContext _testeContext;

    public UnitOfWork(TesteContext testeContext, IProcessoRepository processos, IStatusRepository status, IEnderecoRepository endereco, ICidadeRepository cidade, IEstadoRepository estado)
    {
        _testeContext = testeContext;
        Processos = processos;
        Status = status;
        Endereco = endereco;
        Cidade = cidade;
        Estado = estado;
    }

    public IProcessoRepository Processos { get; }
    public IStatusRepository Status { get; }
    public IEnderecoRepository Endereco { get; }
    public ICidadeRepository Cidade { get; }
    public IEstadoRepository Estado { get; }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        //Pegar os processos em inclusao e criar os históricos
        //_testeContext.Set<Processo>().Include(x=>x.Status).ProjectTo().SaveChangesAsync(cancellationToken)
        //_testeContext.Set<Processo>().
        return await _testeContext.SaveChangesAsync(cancellationToken);
    }
}