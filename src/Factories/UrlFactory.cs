namespace HttpLatencyInspector.Factories;

public class UrlFactory : IUrlFactory
{
    public Uri Create(Config config)
    {
        string routeParams = CreateRouteParams(ref config);
        string queryParams = CreateQueryParams(ref config);
        string url = $"{config.BaseUrl}/{config.BaseRoute}{routeParams}{queryParams}";

        return new Uri(url);
    }

    private string CreateRouteParams(ref Config config)
    {
        if (!config.RouteParams.Any())
        {
            return "";
        }

        return string.Join("", config.RouteParams.Select(rp => $"/{rp.Key}{(string.IsNullOrWhiteSpace(rp.Value) ? "" : "/")}{rp.Value}"));
    }

    private string CreateQueryParams(ref Config config)
    {
        if (!config.QueryParams.Any())
        {
            return "";
        }

        return "?" + string.Join("&", config.QueryParams.Select(rp => $"{rp.Key}={rp.Value}"));
    }
}
