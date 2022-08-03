namespace DesignPatternsCSharpNet6.Strategy.Pattern;

public interface IAveragingStrategy
{
    double CalculateAverage(List<double> values);
}