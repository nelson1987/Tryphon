using Tryphon.Application.Features.AlteracaoProcesso;
using Tryphon.Application.Features.CriacaoProcesso;

namespace Tryphon.Application.Features;

public interface IProcessoHandler
{
    Task<CriacaoProcessoResponse> Criacao(CriacaoProcessoCommand command, CancellationToken cancellationToken = default);

    Task<AlteracaoProcessoResponse> Alteracao(AlteracaoProcessoCommand command, CancellationToken cancellationToken = default);

    Task<AlteracaoProcessoResponse> AlteracaoStatus(AlteracaoStatusProcessoCommand command, CancellationToken cancellationToken = default);
}