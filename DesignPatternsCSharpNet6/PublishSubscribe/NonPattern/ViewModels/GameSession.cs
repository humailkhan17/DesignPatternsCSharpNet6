using System.Collections.ObjectModel;
using DesignPatternsCSharpNet6.PublishSubscribe.NonPattern.Models;

namespace DesignPatternsCSharpNet6.PublishSubscribe.NonPattern.ViewModels;

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
    }

    public void MoveToLocation(Location location)
    {
        CurrentLocation = location;

        if(CurrentLocation.IsPoisonous)
        {
            // Player takes one point damage in poisonous locations
            CurrentPlayer.HitPoints--;

            CheckIfPlayerDied();
        }
    }

    private void CheckIfPlayerDied()
    {
        if(CurrentPlayer.HitPoints <= 0)
        {
            UiMessages.Add("You died");
        }
    }
}