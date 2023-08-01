using Microsoft.Extensions.Configuration;

namespace HttpLatencyInspector.Dependencies;

internal class ConfigMapper
{
    public static void Map(IConfigurationRoot configurationRoot, out List<Config> config)
    {
        config = new List<Config>();
        configurationRoot.GetSection("iterations").Bind(config);
    }
}