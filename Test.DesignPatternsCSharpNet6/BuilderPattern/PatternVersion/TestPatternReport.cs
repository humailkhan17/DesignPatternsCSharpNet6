using DesignPatternsCSharpNet6.Builder.PatternVersion;

namespace Test.DesignPatternsCSharpNet6.BuilderPattern.PatternVersion;

public class TestPatternReport
{
    [Fact]
    public void Test_BuildReports()
    {
        Report currentMonthTaxReport =
            ReportBuilder.CreateMonthTaxReport(7, 2022);

        Report currentYearTaxReport =
            ReportBuilder.CreateYearTaxReport(2022);

        Report currentMonthCommissionReport =
            ReportBuilder.CreateMonthCommissionReport(7, 2022);

        Report currentYearCommissionReport =
            ReportBuilder.CreateYearCommissionReport(2022);
    }
}