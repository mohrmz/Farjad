﻿using Microsoft.Extensions.Logging;
using Scorpion.Extensions.Caching.Abstractions;
using Scorpion.Extensions.ObjectMappers.Abstractions;
using Scorpion.Extensions.Serializers.Abstractions;
using Scorpion.Extensions.Translations.Abstractions;
using Scorpion.Extensions.UsersManagement.Abstractions;

namespace Scorpion.Utilities
{
    public class ScorpionServices
    {
        public readonly ITranslator Translator;
        public readonly ICacheAdapter CacheAdapter;
        public readonly IMapperAdapter MapperFacade;
        public readonly ILoggerFactory LoggerFactory;
        public readonly IJsonSerializer Serializer;
        public readonly IUserInfoService UserInfoService;

        public ScorpionServices(ITranslator translator,
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