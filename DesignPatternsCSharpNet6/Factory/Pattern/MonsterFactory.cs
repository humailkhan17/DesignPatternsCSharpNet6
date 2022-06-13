using DesignPatternsCSharpNet6.Factory.Shared;

namespace DesignPatternsCSharpNet6.Factory.Pattern;

public static class MonsterFactory
{
    public enum MonsterType
    {
        CloudDragon,
        ForestDragon,
        SeaDragon
    }

    public static Monster GetMonster(MonsterType monsterType)
    {
        switch (monsterType)
        {
            case MonsterType.CloudDragon:
                return new Monster("Cloud Dragon", 2, 1, 1);
            case MonsterType.ForestDragon:
                return new Monster("Forest Dragon", 1, 2, 1);
            case MonsterType.SeaDragon:
                return new Monster("Sea Dragon", 1, 1, 2);
            default:
                throw new ArgumentOutOfRangeException(nameof(monsterType));
        }
    }
}