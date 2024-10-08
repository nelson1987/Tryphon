﻿using Tryphon.Domain.Entities;

namespace Tryphon.Domain.Infra;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task<TEntity> GetById(int id, CancellationToken cancellationToken = default);
}

public interface IProcessoRepository : IRepository<Processo>
{
    Task<Processo?> GetFirstProcessoAsync(int id, CancellationToken cancellationToken = default);
}