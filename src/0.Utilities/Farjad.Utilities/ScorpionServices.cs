using Microsoft.Extensions.Logging;
using Farjad.Extensions.Caching.Abstractions;
using Farjad.Extensions.ObjectMappers.Abstractions;
using Farjad.Extensions.Serializers.Abstractions;
using Farjad.Extensions.Translations.Abstractions;
using Farjad.Extensions.UsersManagement.Abstractions;

namespace Farjad.Utilities
{
    public class FarjadServices
    {
        public readonly ITranslator Translator;
        public readonly ICacheAdapter CacheAdapter;
        public readonly IMapperAdapter MapperFacade;
        public readonly ILoggerFactory LoggerFactory;
        public readonly IJsonSerializer Serializer;
        public readonly IUserInfoService UserInfoService;

        public FarjadServices(ITranslator translator,
                ILoggerFactory loggerFactory,
                IJsonSerializer serializer,
                IUserInfoService userInfoService,
                ICacheAdapter cacheAdapter,
                IMapperAdapter mapperFacade)
        {
            Translator = translator;
            LoggerFactory = loggerFactory;
            Serializer = serializer;
            UserInfoService = userInfoService;
            CacheAdapter = cacheAdapter;
            MapperFacade = mapperFacade;
        }
    }
}