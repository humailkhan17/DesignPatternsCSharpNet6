namespace DesignPatternsCSharpNet6.PublishSubscribe.Pattern.Models;

public class Player
{
    private int _hitPoints;

    public string Name { get; }

    public int HitPoints
    {
        get => _hitPoints;
        set
        {
            _hitPoints = value;

            if(_hitPoints <= 0)
            {
                // When the player's HitPoint property is zero or lower,
                // raise a PlayerDied notification to all subscribed objects.
                PlayerDied?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public event EventHandler? PlayerDied;

    public Player(string name, int hitPoints)
    {
        Name = name;
        HitPoints = hitPoints;
    }
}