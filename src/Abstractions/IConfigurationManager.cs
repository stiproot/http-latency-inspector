using HttpLatencyInspector.Dependencies;

namespace HttpLatencyInspector.Abstractions
{
  public interface IConfigurationManager
  {
    List<Config> GetConfigurations();
  }
}
