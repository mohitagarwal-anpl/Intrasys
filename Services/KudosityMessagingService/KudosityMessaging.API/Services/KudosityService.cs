using Microsoft.Extensions.Options;

namespace KudosityMessaging.API.Services;

public class KudosityService
{
    private readonly HttpClient _httpClient;
    private readonly KudosityConfigurationOption _kudosityConfigurationOption;


    public KudosityService(HttpClient httpClient, IOptions<KudosityConfigurationOption> kudosityConfigurationOption)
    {
        _httpClient = httpClient;
        _kudosityConfigurationOption = kudosityConfigurationOption.Value;
    }

    // Method to send a message
    public async Task<bool> SendMessageAsync(string to, string message)
    {
        var requestBody = new
        {
            to,
            message
        };

        var json = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(json, Encoding.UTF8, "application/x-www-form-urlencoded");


        // Add API key to headers
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {GenerateBase64StringFromApiKey(_kudosityConfigurationOption.ApiKey, _kudosityConfigurationOption.ApiSecret)}");

        var response = await _httpClient.PostAsync($"{_kudosityConfigurationOption.ApiBaseUrl}/send-sms.json", content).ConfigureAwait(false);

        return response.IsSuccessStatusCode;
    }

    // Method to receive messages (webhook)
    public async Task<string> ReceiveMessageAsync(string webhookPayload)
    {
        // Process the webhook payload (e.g., parse JSON)
        var payload = JsonSerializer.Deserialize<WebhookPayload>(webhookPayload);

        // Handle the received message (e.g., save to database, log, etc.)
        return $"Received message from {payload.From}: {payload.Message}";
    }


    private static string GenerateBase64StringFromApiKey(string apiKey, string apiSecret)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes($"{apiKey}:{apiSecret}"));
    }
}
