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
    public async Task<IActionResult> PostAsync(CriacaoProcessoCommand command, CancellationToken cancellationToken)
    {
        var criacao = await _handler.Criacao(command, cancellationToken);
        return criacao.IsSuccess ? Created() : BadRequest(criacao.Error);
    }

    [HttpPatch]
    public async Task<IActionResult> PatchAsync(AlteracaoProcessoCommand command, CancellationToken cancellationToken)
    {
        var alteracao = await _handler.Alteracao(command, cancellationToken);
        return alteracao.IsSuccess ? NoContent() : BadRequest(alteracao.Error);
    }

    [HttpPatch("AlteraStatus")]
    public async Task<IActionResult> PatchStatusAsync(AlteracaoStatusProcessoCommand command,
        CancellationToken cancellationToken)
    {
        var alteracaoStatus = await _handler.AlteracaoStatus(command, cancellationToken);
        return alteracaoStatus.IsSuccess ? NoContent() : BadRequest(alteracaoStatus.Error);
    }
}