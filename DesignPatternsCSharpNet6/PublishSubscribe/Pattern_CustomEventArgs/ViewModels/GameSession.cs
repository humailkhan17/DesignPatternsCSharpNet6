using System.Collections.ObjectModel;
using DesignPatternsCSharpNet6.PublishSubscribe.Pattern_CustomEventArgs.Common;
using DesignPatternsCSharpNet6.PublishSubscribe.Pattern_CustomEventArgs.Models;

namespace DesignPatternsCSharpNet6.PublishSubscribe.Pattern_CustomEventArgs.ViewModels;

public class GameSession : IDisposable
{
    public ObservableCollection<string> UiMessages { get; } =
        new ObservableCollection<string>();
    public Player CurrentPlayer { get; }
    public Location CurrentLocation { get; set; }

    public GameSession()
    {
        CurrentPlayer = new Player("Scott", 10);
        CurrentLocation = new Location("Home", false);

        // Subscribe to the PlayerDied event.
        CurrentPlayer.PlayerDied += HandlePlayerDied;
    }

    public void MoveToLocation(Location location)
    {
        CurrentLocation = location;

        if(CurrentLocation.IsPoisonous)
        {
            // Player takes one point damage in poisonous locations
            CurrentPlayer.HitPoints--;
        }
    }

    private void HandlePlayerDied(object? sender, PlayerDiedEventArgs eventArgs)
    {
        UiMessages.Add("You died");
        UiMessages.Add($"This was death number: { eventArgs.NumberOfDeaths }");
    }

    public void Dispose()
    {
        CurrentPlayer.PlayerDied -= HandlePlayerDied;
    }
}