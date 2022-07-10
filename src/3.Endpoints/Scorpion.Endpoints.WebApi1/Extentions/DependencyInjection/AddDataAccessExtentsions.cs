using Scorpion.Core.Contracts.Data.Commands;
using Scorpion.Core.Contracts.Data.Queries;
using System.Reflection;

namespace Scorpion.Endpoints.WebApi.Extentions.DependencyInjection;

/// <summary>
/// توابع کمکی جهت ثبت نیازمندی‌های لایه داده
/// </summary>
public static class AddDataAccessExtentsions
{
    public static IServiceCollection AddScorpionDataAccess(
        this IServiceCollection services,
        IEnumerable<Assembly> assembliesForSearch) =>
        services.AddRepositories(assembliesForSearch).AddUnitOfWorks(assembliesForSearch);

    public static IServiceCollection AddRepositories(this IServiceCollection services,
        IEnumerable<Assembly> assembliesForSearch) =>
        services.AddWithTransientLifetime(assembliesForSearch, typeof(ICommandRepository<>), typeof(IQueryRepository));

    public static IServiceCollection AddUnitOfWorks(this IServiceCollection services,
        IEnumerable<Assembly> assembliesForSearch) =>
        services.AddWithTransientLifetime(assembliesForSearch, typeof(IUnitOfWork));
}