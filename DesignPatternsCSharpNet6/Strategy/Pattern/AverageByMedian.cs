namespace DesignPatternsCSharpNet6.Strategy.Pattern;

public class AverageByMedian : IAveragingStrategy
{
    public double CalculateAverage(List<double> values)
    {
        var sortedValues = values.OrderBy(x => x).ToList();

        if(sortedValues.Count % 2 == 1)
        {
            return sortedValues[(sortedValues.Count - 1) / 2];
        }

        return (sortedValues[(sortedValues.Count / 2) - 1] + 
                sortedValues[sortedValues.Count / 2]) / 2;
    }
}