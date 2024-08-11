using AutoMapper;

namespace Tryphon.Application;

public static class AutoMapperExtensions
{
    private static readonly Lazy<IMapper> _lazy = new(() =>
    {
        var config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(AutoMapperExtensions).Assembly));
        return config.CreateMapper();
    });

    public static IMapper Mapper => _lazy.Value;

    public static T MapTo<T>(this object source) => Mapper.Map<T>(source);
}