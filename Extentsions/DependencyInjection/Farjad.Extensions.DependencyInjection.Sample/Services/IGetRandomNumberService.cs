using Farjad.Extensions.DependentyInjection.Abstractions;

namespace Farjad.Extensions.DependencyInjection.Sample.Services;

public interface IGetGuidTransientService : ITransientLifetime
{
    Guid Execute();
}