using AutoMapper;
using Tryphon.Application.Features;
using Tryphon.Domain.Entities;

namespace Tryphon.Application;

public static class AutoMapperExtensions
{
    private static readonly Lazy<IMapper> _lazy = new(() =>
    {
        var config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(AutoMapperExtensions).Assembly));
        return config.CreateMapper();
    });

    public static IMapper Mapper => _lazy.Value;

    public static T MapToEntity<T>(this ICommand source) => Mapper.Map<T>(source);
    public static T MapToResponse<T>(this Entity source) => Mapper.Map<T>(source);
}