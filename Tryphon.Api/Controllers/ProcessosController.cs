using Microsoft.AspNetCore.Mvc;
using Tryphon.Application.Features;
using Tryphon.Application.Features.AlteracaoProcesso;
using Tryphon.Application.Features.CriacaoProcesso;

namespace Tryphon.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProcessosController : ControllerBase
{
    private readonly IProcessoHandler _handler;

    public ProcessosController(IProcessoHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<CriacaoProcessoResponse> PostAsync(CriacaoProcessoCommand command, CancellationToken cancellationToken)
    {
        return await _handler.Criacao(command, cancellationToken);
    }

    [HttpPatch]
    public async Task<AlteracaoProcessoResponse> PatchAsync(AlteracaoProcessoCommand command, CancellationToken cancellationToken)
    {
        return await _handler.Alteracao(command, cancellationToken);
    }

    [HttpPatch("AlteraStatus")]
    public async Task<AlteracaoProcessoResponse> PatchStatusAsync(AlteracaoStatusProcessoCommand command, CancellationToken cancellationToken)
    {
        return await _handler.AlteracaoStatus(command, cancellationToken);
    }
}