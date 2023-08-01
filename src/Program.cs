using Microsoft.Extensions.DependencyInjection;

namespace HttpLatencyInspector;

public class Program
{
	public static async Task Main()
	{
		var serviceProvider = ConfigureServices();

		var processor = serviceProvider.GetRequiredService<IProcessor<Config>>();
		var configurationManager = serviceProvider.GetRequiredService<IConfigurationManager>();
		var iterations = configurationManager.GetConfigurations();

		var results = new List<string>();
		foreach (var iteration in iterations)
		{
			results.Add(await processor.ProcessAsync(iteration));
		}

		string path = Path.Join(Directory.GetCurrentDirectory(), "Results", $"loqate-results-{DateTime.UtcNow.ToString("yyyy-MM-dd HH_mm_ss")}.md");
		string content = Consts.MdHeader + string.Join("", results);

		await File.WriteAllTextAsync(path, content);
	}

	private static IServiceProvider ConfigureServices()
	{
		var services = new ServiceCollection();

		services.AddSingleton(new HttpClient());

		services.AddSingleton<IConfigurationManager, ConfigurationManager>();
		services.AddSingleton<IProcessor<Config>, ConfigProcessor>();
		services.AddSingleton<Abstractions.IFormatter, ResultFormatter>();
		services.AddSingleton<ITaskFactory, HttpLatencyInspector.Factories.TaskFactory>();
		services.AddSingleton<IRequestFactory, RequestFactory>();
		services.AddSingleton<IUrlFactory, UrlFactory>();

		return services.BuildServiceProvider();
	}
}

