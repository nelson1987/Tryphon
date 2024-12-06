using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tryphon.Domain.Entities;
using Tryphon.Infra;

namespace Tryphon.IntegrationTests;

public class IntegrationTests
{
    [Fact]
    public void Test1()
    {
        var context = GetInMemoryDBContext();
        var endereco = new Endereco("");
        context.Enderecos.AddAsync(endereco);
        context.SaveChanges();
    }

    protected TesteContext GetInMemoryDBContext()
    {
        var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();

        var builder = new DbContextOptionsBuilder<TesteContext>();
        var options = builder.UseInMemoryDatabase("test").UseInternalServiceProvider(serviceProvider).Options;

        TesteContext dbContext = new TesteContext(options);
        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();
        return dbContext;
    }
}