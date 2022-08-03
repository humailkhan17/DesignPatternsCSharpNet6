namespace DesignPatternsCSharpNet6.Strategy.NonPattern_SingleFunction;

public class Calculator
{
    public enum AveragingStrategy
    {
        Mean,
        Median
    }

    public double CalculateAverage(AveragingStrategy averagingStrategy, 
        List<double> values)
    {
        switch(averagingStrategy)
        {
            case AveragingStrategy.Mean:
                return values.Sum() / values.Count;

            case AveragingStrategy.Median:
                var sortedValues = values.OrderBy(x => x).ToList();

                if(sortedValues.Count % 2 == 1)
                {
                    return sortedValues[(sortedValues.Count - 1) / 2];
                }

                return (sortedValues[(sortedValues.Count / 2) - 1] + 
                        sortedValues[sortedValues.Count / 2]) / 2;

            default:
                throw new ArgumentException("Invalid averagingStrategy value");
        }
    }
}