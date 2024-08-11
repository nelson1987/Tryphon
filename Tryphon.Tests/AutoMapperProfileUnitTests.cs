using AutoMapper;
using Tryphon.Application.Features.AlteracaoProcesso;
using Tryphon.Application.Features.CriacaoProcesso;

namespace Tryphon.Tests;

public class AutoMapperProfileUnitTests
{
    [Fact]
    public void ValidateCriacaoProcessoMappingConfigurationTest()
    {
        MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new CriacaoProcessoMapping()));
        IMapper mapper = mapperConfiguration.CreateMapper();
        mapper.ConfigurationProvider.AssertConfigurationIsValid();
    }

    [Fact]
    public void ValidateAlteracaoProcessoMappingConfigurationTest()
    {
        MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new AlteracaoProcessoMapping()));
        IMapper mapper = mapperConfiguration.CreateMapper();
        mapper.ConfigurationProvider.AssertConfigurationIsValid();
    }
}