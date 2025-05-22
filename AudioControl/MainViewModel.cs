using AudioControl;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace AudioControl;

public partial class MainViewModel : ObservableObject
{
    private readonly Esp32Client _client = new();

    [ObservableProperty] private bool isBusy;
    [ObservableProperty] private string statusMessage = "Bereit";
    [ObservableProperty] private double volumeLevel = 50;

    public MainViewModel()
    {
        MuteCommand = new AsyncRelayCommand(MuteAsync);
        UnmuteCommand = new AsyncRelayCommand(UnmuteAsync);
        SetVolumeCommand = new AsyncRelayCommand(SetVolumeAsync);
    }

    public IAsyncRelayCommand MuteCommand { get; }
    public IAsyncRelayCommand UnmuteCommand { get; }
    public IAsyncRelayCommand SetVolumeCommand { get; }

    private async Task MuteAsync()
    {
        await SendCommand(() => _client.MuteAsync(), "Stummgeschaltet!");
    }

    private async Task UnmuteAsync()
    {
        await SendCommand(() => _client.UnmuteAsync(), "Stummschaltung aufgehoben.");
    }

    private async Task SetVolumeAsync()
    {
        var level = (byte)VolumeLevel;
        await SendCommand(() => _client.SetVolumeAsync(level), $"Lautstärke auf {level} gesetzt.");
    }

    private async Task SendCommand(Func<Task<CommandResult>> commandFunc, string successMessage)
    {
        IsBusy = true;
        StatusMessage = "Sende Befehl...";

        var result = await commandFunc();

        if (!result.IsSuccess)
            StatusMessage = $"Fehler: {result.ErrorMessage}";
        else if (result.Response?.Resp != "ok")
            StatusMessage = "Fehler: Kommando fehlgeschlagen.";
        else
            StatusMessage = successMessage;

        IsBusy = false;
    }
}
