namespace Tryphon.Application.Features.CriacaoProcesso;

public record CriacaoProcessoCommand(string Codigo, int StatusId, string Logradouro, int CidadeId);