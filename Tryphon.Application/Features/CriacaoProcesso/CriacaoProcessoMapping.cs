using AutoMapper;
using Tryphon.Domain.Entities;

namespace Tryphon.Application.Features.CriacaoProcesso;

public class CriacaoProcessoMapping : Profile
{
    public CriacaoProcessoMapping()
    {
        CreateMap<CriacaoProcessoCommand, Processo>()
            .ForMember(dest => dest.Codigo, ori => ori.MapFrom(x => x.Codigo))
            .ForMember(dest => dest.Id, ori => ori.MapFrom(x=> 0))
            .ForMember(dest => dest.Endereco, ori => ori.Ignore())
            .ForMember(dest => dest.Status, ori => ori.Ignore());
    }
}
