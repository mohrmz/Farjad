using Microsoft.Extensions.DependencyInjection;
using Farjad.Extensions.UsersManagement.Abstractions;
using Farjad.Extensions.UsersManagement.Services;

namespace Farjad.Extensions.DependencyInjection;

public static class UserInfoServiceCollectionExtensions
{
    public static IServiceCollection AddFarjadWebUserInfoService(this IServiceCollection services, bool useFake = false)
    {
        if (useFake)
        {
            services.AddSingleton<IUserInfoService, FakeUserInfoService>();

        }
        else
        {
            services.AddSingleton<IUserInfoService, WebUserInfoService>();

        }
        return services;
    }
}

