using Tryphon.Domain.Entities;

namespace Tryphon.Domain.Infra;

public interface IStatusRepository
{
    Task<Status> CreateAsync(Status processo, CancellationToken cancellationToken = default);

    Task<Status> GetById(int id, CancellationToken cancellationToken = default);
}