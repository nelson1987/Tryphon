using Tryphon.Domain.Entities;

namespace Tryphon.Domain.Infra;

public interface IEnderecoRepository
{
    Task<Endereco> CreateAsync(Endereco endereco, CancellationToken cancellationToken = default);

    Task<Endereco> GetById(int id, CancellationToken cancellationToken = default);
}

public interface ICidadeRepository
{
    Task<Cidade> CreateAsync(Cidade cidade, CancellationToken cancellationToken = default);

    Task<Cidade> GetById(int id, CancellationToken cancellationToken = default);
}

public interface IEstadoRepository
{
    Task<Estado> CreateAsync(Estado cidade, CancellationToken cancellationToken = default);

    Task<Estado> GetById(int id, CancellationToken cancellationToken = default);
}