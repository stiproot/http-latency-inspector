using Microsoft.Extensions.Configuration;

namespace HttpLatencyInspector;

public class ConfigurationManager : IConfigurationManager
{
    public List<Config> GetConfigurations()
    {
        IConfigurationRoot configurationRoot = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("benchmarks.config.json", optional: false, reloadOnChange: true)
            .Build();

        ConfigMapper.Map(configurationRoot, out List<Config> iterations);

        if (!iterations.Any()) throw new InvalidOperationException();

        return iterations;
    }
}
