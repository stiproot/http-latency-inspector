namespace HttpLatencyInspector.Abstractions;

public interface ITaskFactory
{
    Task<HttpResponseMessage> Create(
        HttpClient client,
        Uri uri,
        HttpRequestMessage request);
}
