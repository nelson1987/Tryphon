namespace Tryphon.Application.Features.AlteracaoProcesso;

public record AlteracaoProcessoCommand(int Id, string Codigo) : ICommand;
public record AlteracaoStatusProcessoCommand(int Id, int StatusId) : ICommand;