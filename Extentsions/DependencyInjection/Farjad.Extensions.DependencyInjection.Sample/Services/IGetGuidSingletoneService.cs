using Farjad.Extensions.DependentyInjection.Abstractions;

namespace Farjad.Extensions.DependencyInjection.Sample.Services;

public interface IGetGuidSingletoneService : ISingletoneLifetime
{
    Guid Execute();
}
