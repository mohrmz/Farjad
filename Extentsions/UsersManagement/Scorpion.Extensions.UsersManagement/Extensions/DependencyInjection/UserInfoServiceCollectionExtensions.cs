using Microsoft.Extensions.DependencyInjection;
using Scorpion.Extensions.UsersManagement.Services;
using Scorpion.Extentions.UsersManagement.Abstractions;

namespace Scorpion.Extensions.DependencyInjection;

public static class UserInfoServiceCollectionExtensions
{
    public static IServiceCollection AddScorpionWebUserInfoService(this IServiceCollection services,bool useFake=false)
    {
        if(useFake)
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

