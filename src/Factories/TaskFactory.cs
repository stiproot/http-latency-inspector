namespace HttpLatencyInspector.Factories;

public class TaskFactory : ITaskFactory
{
    public async Task<HttpResponseMessage> Create(
        HttpClient client,
        Uri uri,
        HttpRequestMessage request
    )
        => await client.SendAsync(request);
}
