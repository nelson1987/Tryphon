using FluentValidation;

namespace Tryphon.Application.Features.AlteracaoProcesso;

public class AlteracaoProcessoCommandValidator : AbstractValidator<AlteracaoProcessoCommand>
{
    public AlteracaoProcessoCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Codigo).NotEmpty();
    }
}