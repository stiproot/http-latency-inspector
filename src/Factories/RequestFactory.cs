namespace HttpLatencyInspector.Factories;

public class RequestFactory : IRequestFactory
{
  public HttpRequestMessage Create(Config config, Uri uri)
  {
    var request = new HttpRequestMessage(Consts.HttpMethods[config.Verb], uri);
    var content = new StringContent(config.RequestPayload);
    request.Content = content;
    return request;
  }
}
