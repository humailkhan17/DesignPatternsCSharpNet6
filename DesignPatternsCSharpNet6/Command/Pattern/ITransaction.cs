namespace DesignPatternsCSharpNet6.Command.Pattern;

public interface ITransaction
{
    ExecutionStatus Status { get; set; }
    void Execute();
}