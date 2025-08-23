using Luma.Extensions.Caching.Abstractions;
using Luma.Extensions.ObjectMappers.Abstractions;
using Luma.Extensions.Serializers.Abstractions;
using Luma.Extensions.Translations.Abstractions;
using Luma.Extensions.UsersManagement.Abstractions;
using Microsoft.Extensions.Logging;

namespace Luma.Utilities;

public class LumaServices
{
    public readonly ITranslator Translator;
    public readonly ICacheAdapter CacheAdapter;
    public readonly IMapperAdapter MapperFacade;
    public readonly ILoggerFactory LoggerFactory;
    public readonly IJsonSerializer Serializer;
    public readonly IUserInfoService UserInfoService;

    public LumaServices(ITranslator translator,
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
