using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace AIChatbot
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private const string API_KEY = "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"; // Paste your Groq key here
        private const string API_URL = "https://api.groq.com/openai/v1/chat/completions";

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", API_KEY);
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> SendMessageAsync(string userMessage)
        {
            var requestBody = new
            {
                model = "llama-3.3-70b-versatile",
                max_tokens = 1024,
                messages = new[]
                {
                    new { role = "user", content = userMessage }
                }
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(API_URL, content);
            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception($"API Error: {responseString}");

            using var doc = JsonDocument.Parse(responseString);
            var text = doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            return text ?? "No response received.";
        }
    }
}
