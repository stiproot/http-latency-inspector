using HttpLatencyInspector.Dependencies;

namespace HttpLatencyInspector.Abstractions;

public interface IUrlFactory
{
    Uri Create(Config config);
}
