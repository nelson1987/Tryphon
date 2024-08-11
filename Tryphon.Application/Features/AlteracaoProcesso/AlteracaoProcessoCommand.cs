namespace Tryphon.Application.Features.AlteracaoProcesso;

public record AlteracaoProcessoCommand(int Id, string Codigo);
public record AlteracaoStatusProcessoCommand(int Id, int StatusId);