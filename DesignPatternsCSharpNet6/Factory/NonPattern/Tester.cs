using DesignPatternsCSharpNet6.Factory.Shared;

namespace DesignPatternsCSharpNet6.Factory.NonPattern;

public class Tester
{
    public void Test()
    {
        Monster cloudDragon =
            new Monster("Cloud Dragon", 2, 1, 1);
        Monster forestMonster =
            new Monster("Forest Dragon", 1, 2, 1);
        Monster seaDragon =
            new Monster("Sea Dragon", 1, 1, 2);
    }
}