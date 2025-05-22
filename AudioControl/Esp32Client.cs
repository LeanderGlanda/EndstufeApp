using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AudioControl;
public class Esp32Client
{
    private readonly HttpClient _http;

    public string BaseUrl => AppSettings.Esp32Ip;
    private string ApiUrl => $"{BaseUrl.TrimEnd('/')}/api";

    public Esp32Client()
    {
        _http = new HttpClient();
    }

    public Task<CommandResult> MuteAsync() =>
        SendCommandAsync(new { cmd = "mute" });

    public Task<CommandResult> UnmuteAsync() =>
        SendCommandAsync(new { cmd = "unmute" });

    public Task<CommandResult> SetVolumeAsync(byte level) =>
        SendCommandAsync(new { cmd = "set_volume", level });

    private async Task<CommandResult> SendCommandAsync(object command)
    {
        try
        {
            var json = JsonSerializer.Serialize(command);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync(ApiUrl, content);

            if (!response.IsSuccessStatusCode)
                return CommandResult.Failure($"HTTP {response.StatusCode}");

            var responseText = await response.Content.ReadAsStringAsync();
            var commandResponse = JsonSerializer.Deserialize<CommandResponse>(responseText);

            return CommandResult.Success(commandResponse);
        }
        catch (Exception ex)
        {
            return CommandResult.Failure(ex.Message);
        }
    }
}
