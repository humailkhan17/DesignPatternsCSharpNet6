namespace DesignPatternsCSharpNet6.Factory.Shared;

public class Monster
{
    public string Name { get; }
    public int AirSpeedMultiplier { get; }
    public int LandSpeedMultiplier { get; }
    public int WaterSpeedMultiplier { get; }

    public Monster(string name, int airSpeedMultiplier,
        int landSpeedMultiplier, int waterSpeedMultiplier)
    {
        Name = name;
        AirSpeedMultiplier = airSpeedMultiplier;
        LandSpeedMultiplier = landSpeedMultiplier;
        WaterSpeedMultiplier = waterSpeedMultiplier;
    }
}