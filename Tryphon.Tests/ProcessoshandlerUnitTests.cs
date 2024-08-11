using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Moq;
using Tryphon.Application.Features;
using Tryphon.Application.Features.CriacaoProcesso;
using Tryphon.Domain.Infra;

namespace Tryphon.Tests;

public class ProcessoshandlerUnitTests
{
    private readonly IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization { ConfigureMembers = true });
    private readonly CriacaoProcessoCommand _command;
    private readonly ProcessoHandler _sut;
    private readonly CancellationToken _token = CancellationToken.None;
    private readonly Mock<IUnitOfWork> _unitOfWork;

    public ProcessoshandlerUnitTests()
    {
        _command = _fixture.Create<CriacaoProcessoCommand>();
        _unitOfWork = _fixture.Freeze<Mock<IUnitOfWork>>();
        _sut = _fixture.Build<ProcessoHandler>()
            .OmitAutoProperties()
            .Create();
    }

    [Fact]
    public async Task SaveChangeAsync_TudoFuncionandoCorretamente_RetornaSucesso()
    {
        _unitOfWork
            .Setup(x => x.SaveChangesAsync(_token))
            .ReturnsAsync(1);

        var result = await _sut.Criacao(_command, _token);

        result.Should().BeOfType<CriacaoProcessoResponse>();
        _unitOfWork
            .Verify(x => x.SaveChangesAsync(_token), Times.Once);
    }

    [Fact]
    public async Task SaveChangeAsync_SaveChangeAsyncRetorna0_RetornaExcecao()
    {
        _unitOfWork
            .Setup(x => x.SaveChangesAsync(_token))
            .ReturnsAsync(0);

        var result = await _sut.Criacao(_command, _token);

        result.Should().BeOfType<CriacaoProcessoResponse>();
        _unitOfWork
            .Verify(x => x.SaveChangesAsync(_token), Times.Once);
    }

    [Fact]
    public async Task SaveChangeAsync_SaveChangeAsyncRetornaExcecao_RetornaExcecao()
    {
        _unitOfWork
            .Setup(x => x.SaveChangesAsync(_token))
            .ThrowsAsync(new Exception("Exception"));

        Func<Task> result = async () => await _sut.Criacao(_command, _token);

        await result.Should().ThrowAsync<Exception>()
            .WithMessage("Exception");
        _unitOfWork
            .Verify(x => x.SaveChangesAsync(_token), Times.Once);
    }
}