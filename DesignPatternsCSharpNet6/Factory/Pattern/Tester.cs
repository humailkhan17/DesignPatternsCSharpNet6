using DesignPatternsCSharpNet6.Factory.Shared;

namespace DesignPatternsCSharpNet6.Factory.Pattern;

public class Tester
{
    public void Test()
    {
        Monster cloudDragon =
            MonsterFactory.GetMonster(MonsterFactory.MonsterType.CloudDragon);
        Monster forestDragon =
            MonsterFactory.GetMonster(MonsterFactory.MonsterType.ForestDragon);
        Monster seaDragon =
            MonsterFactory.GetMonster(MonsterFactory.MonsterType.SeaDragon);
    }
}