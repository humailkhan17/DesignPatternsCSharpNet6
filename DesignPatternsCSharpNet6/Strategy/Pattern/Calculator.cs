﻿namespace DesignPatternsCSharpNet6.Strategy.Pattern;

public class Calculator
{
    private readonly IAveragingStrategy _averagingStrategy;

    public Calculator(IAveragingStrategy averagingStrategy)
    {
        _averagingStrategy = averagingStrategy;
    }

    public double CalculateAverage(List<double> values)
    {
        return _averagingStrategy.CalculateAverage(values);
    }
}