using System.Net;

namespace ApiAiBlazorLab.Tests
{
    public class FakeHandler : HttpMessageHandler
    {
        private readonly string _json;

        public FakeHandler(string json)
        {
            _json = json;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(_json, System.Text.Encoding.UTF8, "application/json");
            return Task.FromResult(response);
        }
    }
}
