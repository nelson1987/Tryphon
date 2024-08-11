using AutoMapper;
using Tryphon.Domain.Entities;

namespace Tryphon.Application.Features.AlteracaoProcesso;

public class AlteracaoProcessoMapping : Profile
{
    public AlteracaoProcessoMapping()
    {
        CreateMap<AlteracaoProcessoCommand, Processo>();
    }
}
