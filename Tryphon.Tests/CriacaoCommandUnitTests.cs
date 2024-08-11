using AutoFixture;
using AutoFixture.AutoMoq;
using FluentValidation;
using FluentValidation.TestHelper;
using Tryphon.Application.Features.CriacaoProcesso;

namespace Tryphon.Tests;

public class CriacaoProcessoCommandValidatorUnitTests
{
    private readonly IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());
    private readonly IValidator<CriacaoProcessoCommand> _validator;
    private readonly CriacaoProcessoCommand _command;

    public CriacaoProcessoCommandValidatorUnitTests()
    {
        _command = _fixture.Build<CriacaoProcessoCommand>()
            .Create();
        _validator = _fixture.Create<CriacaoProcessoCommandValidator>();
    }

    [Fact]
    public void Given_a_valid_event_when_all_fields_are_valid_should_pass_validation()
        => _validator
            .TestValidate(_command)
            .ShouldNotHaveAnyValidationErrors();

    [Fact]
    public void Given_a_cancellation_request_with_invalid_asset_id_should_fail_validation()
        => _validator
            .TestValidate(_command with { Codigo = string.Empty })
            .ShouldHaveValidationErrorFor(x => x.Codigo)
            .Only();
}