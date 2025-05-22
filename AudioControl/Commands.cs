namespace AudioControl;

public class SetVolumeCommand
{
    public string Cmd => "set_volume";
    public int Level { get; set; }
}

public class MuteCommand
{
    public string Cmd => "mute";
}

public class UnmuteCommand
{
    public string Cmd => "unmute";
}