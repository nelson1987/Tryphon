using AutoMapper;
using Tryphon.Domain.Entities;

namespace Tryphon.Application.Features.CriacaoProcesso;

public class CriacaoProcessoMapping : Profile
{
    public CriacaoProcessoMapping()
    {
        CreateMap<CriacaoProcessoCommand, Processo>()
            .ForMember(dest => dest.Codigo, ori => ori.MapFrom(x => x.Codigo));
    }
}
