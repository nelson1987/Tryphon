using Tryphon.Application.Features.AlteracaoProcesso;
using Tryphon.Application.Features.CriacaoProcesso;
using Tryphon.Domain.Entities;
using Tryphon.Domain.Infra;

namespace Tryphon.Application.Features;

public class ProcessoHandler : IProcessoHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public ProcessoHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CriacaoProcessoResponse> Criacao(CriacaoProcessoCommand command, CancellationToken cancellationToken = default)
    {
        try
        {
            var processo = command.MapTo<Processo>();

            var status = await _unitOfWork.Status.GetById(command.StatusId, cancellationToken);
            processo.AlteracaoStatus(status);

            var cidade = await _unitOfWork.Cidade.GetById(command.CidadeId, cancellationToken);
            var endereco = new Endereco(command.Logradouro, cidade);
            processo.AlteracaoEndereco(endereco);

            if (processo.Status is null) throw new Exception();
            if (processo.Endereco is null) throw new Exception();

            await _unitOfWork.Processos.CreateAsync(processo, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new CriacaoProcessoResponse();
        }
        catch (Exception)
        {
            return new CriacaoProcessoResponse();
        }
    }

    public async Task<AlteracaoProcessoResponse> Alteracao(AlteracaoProcessoCommand command, CancellationToken cancellationToken = default)
    {
        var processo = await _unitOfWork.Processos.GetFirstProcessoAsync(command.Id, cancellationToken);
        processo.AlteracaoCodigo(command.Codigo);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return new AlteracaoProcessoResponse(processo.Id, processo.Status.Id);
    }

    public async Task<AlteracaoProcessoResponse> AlteracaoStatus(AlteracaoStatusProcessoCommand command, CancellationToken cancellationToken = default)
    {
        var processo = await _unitOfWork.Processos.GetById(command.Id, cancellationToken);
        var status = await _unitOfWork.Status.GetById(command.StatusId, cancellationToken);
        processo.AlteracaoStatus(status);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return new AlteracaoProcessoResponse(processo.Id, processo.Status.Id);
    }
}