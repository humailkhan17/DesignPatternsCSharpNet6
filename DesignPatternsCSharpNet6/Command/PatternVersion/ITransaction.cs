namespace DesignPatternsCSharpNet6.Command.PatternVersion;

public interface ITransaction
{
    ExecutionStatus Status { get; set; }
    void Execute();
}