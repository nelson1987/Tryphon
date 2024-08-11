using Tryphon.Domain.Entities;

namespace Tryphon.Domain.Infra;

public interface IEnderecoRepository : IRepository<Endereco>
{
}

public interface ICidadeRepository : IRepository<Cidade>
{
}

public interface IEstadoRepository : IRepository<Estado>
{
}