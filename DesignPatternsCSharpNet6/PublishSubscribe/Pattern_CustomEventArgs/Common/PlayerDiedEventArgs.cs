namespace DesignPatternsCSharpNet6.PublishSubscribe.Pattern_CustomEventArgs.Common;

public class PlayerDiedEventArgs : EventArgs
{
    public int NumberOfDeaths { get; }

    public PlayerDiedEventArgs(int numberOfDeaths)
    {
        NumberOfDeaths = numberOfDeaths;
    }
}