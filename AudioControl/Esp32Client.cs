using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace AudioControl;

// https://chatgpt.com/c/6825dd54-0abc-8006-a55c-96e78d5fce76

public class Esp32Client
{
    private readonly HttpClient _http;
    private readonly string _baseUrl;

    public Esp32Client(string baseUrl)
    {
        _http = new HttpClient();
        _baseUrl = baseUrl.TrimEnd('/');
    }

    private async Task<ApiResponse?> SendCommandAsync<T>(T command)
    {
        var json = JsonSerializer.Serialize(command);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _http.PostAsync($"{_baseUrl}/api", content);
        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<ApiResponse>(body);
    }

    public Task<ApiResponse?> MuteAsync() => SendCommandAsync(new MuteCommand());
    public Task<ApiResponse?> UnmuteAsync() => SendCommandAsync(new UnmuteCommand());
    public Task<ApiResponse?> SetVolumeAsync(int level) =>
        SendCommandAsync(new SetVolumeCommand { Level = level });
}
