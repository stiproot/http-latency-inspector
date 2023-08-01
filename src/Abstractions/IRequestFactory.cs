using HttpLatencyInspector.Dependencies;

namespace HttpLatencyInspector.Abstractions;

public interface IRequestFactory
{
    HttpRequestMessage Create(
        Config config,
        Uri uri);
}
