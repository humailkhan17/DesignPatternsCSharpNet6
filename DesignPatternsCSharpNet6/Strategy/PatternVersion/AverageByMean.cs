namespace DesignPatternsCSharpNet6.Strategy.PatternVersion;

public class AverageByMean : IAveragingStrategy
{
    public double CalculateAverage(List<double> values)
    {
        return values.Sum() / values.Count;
    }
}