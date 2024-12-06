using Tryphon.Application.Features.AlteracaoProcesso;
using Tryphon.Application.Features.CriacaoProcesso;
using Tryphon.Domain.Infra;

namespace Tryphon.Application.Features;

public interface IProcessoHandler
{
    Task<Result<CriacaoProcessoResponse>> Criacao(CriacaoProcessoCommand command,
        CancellationToken cancellationToken = default);

    Task<Result<AlteracaoProcessoResponse>> Alteracao(AlteracaoProcessoCommand command,
        CancellationToken cancellationToken = default);

    Task<Result<AlteracaoProcessoResponse>> AlteracaoStatus(AlteracaoStatusProcessoCommand command,
        CancellationToken cancellationToken = default);
}

public sealed class Result<T>
{
    public T? Value { get; }
    public Error? Error { get; }
    public bool IsSuccess => Error == null;

    public Result(T value)
    {
        Value = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Result(Error error)
    {
        Error = error ?? throw new ArgumentNullException(nameof(error));
    }

    public static Result<T> Success(T value) => new Result<T>(value);

    public static Result<T> Failure(Error error) => new Result<T>(error);
}

public class Error
{
    private Error(int code, string message)
    {
        Code = code;
        Message = message;
    }

    public int Code { get; private set; }
    public string Message { get; private set; }
    public static Error ProcessoNaoEncontrado = new Error(100, "Processo Não Encontrado.");
    public static Error ProcessoNaoConcluido = new Error(101, "Processo Não Concluido.");
    public static Error StatusNaoEncontrado = new Error(200, "Status Não Encontrado.");
    public static Error EnderecoNaoEncontrado = new Error(300, "Endereco Não Encontrado.");

    public static Error ErroInesperado(Exception exception) =>
        new Error(1, $"Ocorreu um erro inesperado. {exception.Message}");
}

public interface ICommand
{
}

public interface IResponse<TCommand> where TCommand : ICommand
{
}

public interface IHandler<TCommand, TResponse> where TCommand : ICommand where TResponse : IResponse<TCommand>
{
}

public abstract class HandlerBase<TCommand, TResponse> : IHandler<TCommand, TResponse> where TCommand : ICommand where TResponse : IResponse<TCommand>
{
    protected readonly IUnitOfWork _unitOfWork;

    protected HandlerBase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    protected Result<TResponse> Fail(Error error) =>
        Result<TResponse>.Failure(error);
    protected Result<TResponse> Ok(TResponse response) =>
        Result<TResponse>.Success(response);
}