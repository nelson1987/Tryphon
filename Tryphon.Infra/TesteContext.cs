using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Tryphon.Domain.Entities;
using Tryphon.Domain.Infra;

namespace Tryphon.Infra;

public class TesteContext(DbContextOptions<TesteContext> options)
        : DbContext(options)
{
    public DbSet<Processo> Processos { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<Cidade> Cidades { get; set; }
    public DbSet<Estado> Estados { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}

public static class Dependencies
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        var connectionString = "Server=localhost,1433;Database=BaseGeografica_v1;User ID=sa;Password=SqlServer2019!;TrustServerCertificate=True";
        services.AddDbContext<TesteContext>(options =>
        options
                .UseSqlServer(connectionString)
                .ConfigureWarnings(w => w.Throw(RelationalEventId.MultipleCollectionIncludeWarning))
        );
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IProcessoRepository, ProcessoRepository>();
        services.AddScoped<IStatusRepository, StatusRepository>();
        services.AddScoped<IEnderecoRepository, EnderecoRepository>();
        services.AddScoped<ICidadeRepository, CidadeRepository>();
        services.AddScoped<IEstadoRepository, EstadoRepository>();
        return services;
    }
}

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task<TEntity> GetById(int id, CancellationToken cancellationToken = default);
}

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly TesteContext _testeContext;

    public Repository(TesteContext testeContext)
    {
        _testeContext = testeContext;
    }

    public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _testeContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        return entity;
    }

    public async Task<TEntity> GetById(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _testeContext.Set<TEntity>().FindAsync(id, cancellationToken);
        return entity;
    }
}

public class ProcessoRepository : Repository<Processo>, IProcessoRepository
{
    private readonly TesteContext _testeContext;

    public ProcessoRepository(TesteContext testeContext) : base(testeContext)
    {
        _testeContext = testeContext;
    }
    public async Task<Processo?> GetFirstProcessoAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _testeContext.Set<Processo>()
            .Include(x => x.Status)
            .Include(x => x.Endereco)
                .ThenInclude(x => x.Cidade)
                    .ThenInclude(x => x.Estado)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}

public class StatusRepository : Repository<Status>, IStatusRepository
{
    private readonly TesteContext _testeContext;

    public StatusRepository(TesteContext testeContext) : base(testeContext)
    {
        _testeContext = testeContext;
    }
}

public class CidadeRepository : Repository<Cidade>, ICidadeRepository
{
    private readonly TesteContext _testeContext;

    public CidadeRepository(TesteContext testeContext) : base(testeContext)
    {
        _testeContext = testeContext;
    }
}

public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
{
    private readonly TesteContext _testeContext;

    public EnderecoRepository(TesteContext testeContext) : base(testeContext)
    {
        _testeContext = testeContext;
    }
}

public class EstadoRepository : Repository<Estado>, IEstadoRepository
{
    private readonly TesteContext _testeContext;

    public EstadoRepository(TesteContext testeContext) : base(testeContext)
    {
        _testeContext = testeContext;
    }
}