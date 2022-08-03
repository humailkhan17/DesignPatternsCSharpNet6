namespace DesignPatternsCSharpNet6.PublishSubscribe.NonPattern.Models;

public class Player
{
    public string Name { get; }
    public int HitPoints { get; set; }

    public Player(string name, int hitPoints)
    {
        Name = name;
        HitPoints = hitPoints;
    }
}