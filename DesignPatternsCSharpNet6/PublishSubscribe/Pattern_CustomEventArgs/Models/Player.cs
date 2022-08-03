using DesignPatternsCSharpNet6.PublishSubscribe.Pattern_CustomEventArgs.Common;

namespace DesignPatternsCSharpNet6.PublishSubscribe.Pattern_CustomEventArgs.Models;

public class Player
{
    private int _hitPoints;
    private int _numberOfDeaths;

    public string Name { get; }

    public int HitPoints
    {
        get => _hitPoints;
        set
        {
            _hitPoints = value;

            if(_hitPoints <= 0)
            {
                _numberOfDeaths++;

                // When the player's HitPoint property is zero or lower,
                // raise a PlayerDied notification to all subscribed objects.
                PlayerDied?.Invoke(this, new PlayerDiedEventArgs(_numberOfDeaths));
            }
        }
    }

    public event EventHandler<PlayerDiedEventArgs>? PlayerDied;

    public Player(string name, int hitPoints)
    {
        Name = name;
        HitPoints = hitPoints;
    }
}