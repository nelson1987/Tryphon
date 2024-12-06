using AutoMapper;
using Tryphon.Domain.Entities;

namespace Tryphon.Application.Features.AlteracaoProcesso;

public class AlteracaoProcessoMapping : Profile
{
    public AlteracaoProcessoMapping()
    {
        CreateMap<AlteracaoProcessoCommand, Processo>()
            .ForMember(dest => dest.Endereco, ori => ori.Ignore())
            .ForMember(dest => dest.Status, ori => ori.Ignore());
    }
}
