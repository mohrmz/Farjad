using Scorpion.Extensions.DependentyInjection.Abstractions;

namespace Scorpion.Extensions.DependencyInjection.Sample.Services;

public interface IGetGuidSingletoneService : ISingletoneLifetime
{
    Guid Execute();
}
