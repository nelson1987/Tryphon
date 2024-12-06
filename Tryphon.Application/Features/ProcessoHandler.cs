using Tryphon.Application.Features.AlteracaoProcesso;
using Tryphon.Application.Features.CriacaoProcesso;
using Tryphon.Domain.Entities;
using Tryphon.Domain.Infra;

namespace Tryphon.Application.Features;

public class ProcessoHandler : HandlerBase<CriacaoProcessoCommand, CriacaoProcessoResponse>, IProcessoHandler
{
    public ProcessoHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<Result<CriacaoProcessoResponse>> Criacao(CriacaoProcessoCommand command,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var processo = command.MapToEntity<Processo>();

            var status = await _unitOfWork.Status.GetById(command.StatusId, cancellationToken);
            if (status is null) return Fail(Error.StatusNaoEncontrado);
            processo.AlteracaoStatus(status);

            var cidade = await _unitOfWork.Cidade.GetById(command.CidadeId, cancellationToken);
            if (cidade is null) return Fail(Error.EnderecoNaoEncontrado);
            var endereco = new Endereco(command.Logradouro, cidade);
            processo.AlteracaoEndereco(endereco);

            await _unitOfWork.Processos.CreateAsync(processo, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Ok(processo.MapToResponse<CriacaoProcessoResponse>());
        }
        catch (Exception ex)
        {
            return Fail(Error.ErroInesperado(ex));
        }
    }

    public async Task<Result<AlteracaoProcessoResponse>> Alteracao(AlteracaoProcessoCommand command,
        CancellationToken cancellationToken = default)
    {
        var processo = await _unitOfWork.Processos.GetFirstProcessoAsync(command.Id, cancellationToken);
        if (processo is null) throw new Exception();
        processo.AlteracaoCodigo(command.Codigo);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<AlteracaoProcessoResponse>.Success(new AlteracaoProcessoResponse(processo.Id,
            processo.Status.Id));
    }

    public async Task<Result<AlteracaoProcessoResponse>> AlteracaoStatus(AlteracaoStatusProcessoCommand command,
        CancellationToken cancellationToken = default)
    {
        var processo = await _unitOfWork.Processos.GetById(command.Id, cancellationToken);
        var status = await _unitOfWork.Status.GetById(command.StatusId, cancellationToken);
        processo.AlteracaoStatus(status);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<AlteracaoProcessoResponse>.Success(new AlteracaoProcessoResponse(processo.Id,
            processo.Status.Id));
    }
}