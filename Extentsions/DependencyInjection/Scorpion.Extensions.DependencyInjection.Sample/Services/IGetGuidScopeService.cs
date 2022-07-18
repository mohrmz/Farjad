using Scorpion.Extensions.DependentyInjection.Abstractions;

namespace Scorpion.Extensions.DependencyInjection.Sample.Services;

public interface IGetGuidScopeService : IScopeLifetime
{
    Guid Execute();
}
