using FluentValidation;

namespace Tryphon.Application.Features.CriacaoProcesso;

public class CriacaoProcessoCommandValidator : AbstractValidator<CriacaoProcessoCommand>
{
    public CriacaoProcessoCommandValidator()
    {
        RuleFor(x => x.Codigo).NotEmpty();
    }
}
