using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Moq;
using Tryphon.Api.Controllers;
using Tryphon.Application.Features;
using Tryphon.Application.Features.CriacaoProcesso;

namespace Tryphon.Tests;

public class ProcessosControllerUnitTests
{
    private readonly IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization { ConfigureMembers = true });
    private readonly CriacaoProcessoCommand _command;
    private readonly ProcessosController _sut;
    private readonly CancellationToken _token = CancellationToken.None;
    private readonly Mock<IProcessoHandler> _handler;

    public ProcessosControllerUnitTests()
    {
        _command = _fixture.Create<CriacaoProcessoCommand>();
        _handler = _fixture.Freeze<Mock<IProcessoHandler>>();
        _sut = _fixture.Build<ProcessosController>()
            .OmitAutoProperties()
            .Create();
    }

    [Fact]
    public async Task PostAsync_QuandoFuncionandoCorretamente_RetornaSucesso()
    {
        _handler
            .Setup(x => x.Criacao(_command, _token))
            .ReturnsAsync(new CriacaoProcessoResponse());

        var result = await _sut.PostAsync(_command, _token);

        result.Should().BeOfType<CriacaoProcessoResponse>();
        _handler
            .Verify(x => x.Criacao(_command, _token), Times.Once);
        //_resendHandler.Verify(x => x.Handle(It.IsNotNull<AddMovementCommand>(), _token), Times.Once);
        // .Which.Value.Should().BeEquivalentTo(_students);
    }

    [Fact]
    public async Task PostAsync_QuandoHandlerRetornaException_RetornaFalha()
    {
        _handler
            .Setup(x => x.Criacao(_command, _token))
            .ThrowsAsync(new Exception("Exception"));

        Func<Task> result = async () => await _sut.PostAsync(_command, _token);

        await result.Should().ThrowAsync<Exception>()
            .WithMessage("Exception");
        _handler.Verify(x => x.Criacao(_command, _token), Times.Once);
        //_resendHandler.Verify(x => x.Handle(It.IsNotNull<AddMovementCommand>(), _token), Times.Once);
        // .Which.Value.Should().BeEquivalentTo(_students);
    }
}