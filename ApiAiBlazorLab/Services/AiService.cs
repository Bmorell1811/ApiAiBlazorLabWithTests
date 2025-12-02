using System.Net.Http.Json;
using System.Text.Json;

namespace ApiAiBlazorLab.Services
{
    public class AiService
    {
        private readonly HttpClient _http;
        private readonly string _apiKey;

        public AiService(HttpClient http, IConfiguration config)
        {
            _http = http;
            _apiKey = config["OpenAI:ApiKey"] ?? "";
        }

        public async Task<string> AskAsync(string prompt)
        {
            if (string.IsNullOrWhiteSpace(_apiKey))
                return "API key not configured.";

            _http.DefaultRequestHeaders.Clear();
            _http.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

            var body = new
            {
                model = "gpt-4o-mini",
                messages = new[]
                {
                    new { role = "user", content = prompt }
                }
            };

            var response = await _http.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", body);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                    return "⚠️ Rate limit exceeded. Free tier allows 3 requests/min. Add billing at platform.openai.com/settings/organization/billing";
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    return "⚠️ Invalid API key. Check your key at platform.openai.com/api-keys";
                return $"Error {response.StatusCode}: {errorContent}";
            }

            using var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
            return doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString() ?? "(No response)";
        }
    }
}
