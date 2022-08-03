namespace DesignPatternsCSharpNet6.PublishSubscribe.NonPattern.Models;

public class Location
{
    public string Name { get; }
    public bool IsPoisonous { get; }

    public Location(string name, bool isPoisonous)
    {
        Name = name;
        IsPoisonous = isPoisonous;
    }
}