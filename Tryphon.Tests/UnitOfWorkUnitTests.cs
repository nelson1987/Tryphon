using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Moq;
using Tryphon.Domain.Entities;
using Tryphon.Domain.Infra;
using Tryphon.Infra;

namespace Tryphon.Tests;

public class UnitOfWorkUnitTests
{
    private readonly IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization { ConfigureMembers = true });
    private readonly UnitOfWork _sut;
    private readonly CancellationToken _token = CancellationToken.None;
    private readonly Mock<IProcessoRepository> _processoRepository;
    private readonly Mock<IStatusRepository> _statusRepository;

    public UnitOfWorkUnitTests()
    {
        _processoRepository = _fixture.Freeze<Mock<IProcessoRepository>>();
        _statusRepository = _fixture.Freeze<Mock<IStatusRepository>>();
        _sut = _fixture.Build<UnitOfWork>()
            .OmitAutoProperties()
            .Create();
    }

    [Fact]
    public async Task SaveChangeAsync_TudoFuncionandoCorretamente_RetornaSucesso()
    {
        //Instanciar
        var processo = new Processo();
        //Adicioanr
        await _sut.Processos.CreateAsync(processo, _token);
        //Salvar
        await _sut.SaveChangesAsync(_token);
        //Confirmar
        var processoEncontrado = await _sut.Processos.GetById(processo.Id, _token);
        processoEncontrado.Id.Should().Be(processo.Id);

        //_processoRepository
        //    .Setup(x => x.Create(It.IsAny<Processo>(), _token))
        //    .ReturnsAsync(new Processo());

        //var result = await _sut.SaveChangesAsync(_token);
        //result.Should().Be(1);
        //
        //_processoRepository
        //    .Verify(x => x.Create(It.IsAny<Processo>(), _token), Times.Once);
    }

    [Fact]
    public async void CreateAsyncMethodAddNewUser()
    {
        //var options = new DbContextOptions<TesteContext>();
        ////(options) =>
        ////options
        ////        .UseSqlServer(connectionString)
        ////        .ConfigureWarnings(w => w.Throw(RelationalEventId.MultipleCollectionIncludeWarning))
        ////);
        //var context = new TesteContext(options);
        //var unitOfWork = new UnitOfWork((TesteContext)context, _processoRepository.Object, _statusRepository.Object);

        //Processo user = new Processo();
        //Processo usersInDatabase;

        //await unitOfWork.Processos.CreateAsync(user, _token);

        //await unitOfWork.SaveChangesAsync(_token);
        //usersInDatabase = await unitOfWork.Processos.GetById(user.Id, _token);

        ////Assert.Single(usersInDatabase);
        //user.Id.Should().Be(1);
    }
}