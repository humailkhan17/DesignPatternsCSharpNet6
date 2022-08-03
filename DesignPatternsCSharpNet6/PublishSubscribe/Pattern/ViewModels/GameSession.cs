using System.Collections.ObjectModel;
using DesignPatternsCSharpNet6.PublishSubscribe.Pattern.Models;

namespace DesignPatternsCSharpNet6.PublishSubscribe.Pattern.ViewModels;

public class GameSession
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
        // When the GameSession object receives this notification,
        // it will run the HandlePlayerDied function.
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

    private void HandlePlayerDied(object? sender, EventArgs eventArgs)
    {
        UiMessages.Add("You died");
    }
}