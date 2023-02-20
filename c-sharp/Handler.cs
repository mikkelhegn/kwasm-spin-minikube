using Fermyon.Spin.Sdk;

namespace CSharp;

public static class Handler
{
    [HttpHandler]
    public static HttpResponse HandleHttpRequest(HttpRequest request)
    {

        var outRequest = new HttpRequest {
            Method = Fermyon.Spin.Sdk.HttpMethod.Get,
            Url = "https://some-random-api.ml/facts/dog",
        };

        var response = HttpOutbound.Send(outRequest);
    
        return new HttpResponse
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Headers = new Dictionary<string, string>
            {
                { "Content-Type", "text/plain" },
            },
            // BodyAsString = "Hello from .NET\n",
            BodyAsString = response.BodyAsString,
        };
    }
}
