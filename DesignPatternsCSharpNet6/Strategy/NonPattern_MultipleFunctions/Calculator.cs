namespace DesignPatternsCSharpNet6.Strategy.NonPattern_MultipleFunctions;

public class Calculator
{
    public double CalculateAverageByMean(List<double> values)
    {
        return values.Sum() / values.Count;
    }

    public double CalculateAverageByMedian(List<double> values)
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