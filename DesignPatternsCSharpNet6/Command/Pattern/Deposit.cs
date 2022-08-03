namespace DesignPatternsCSharpNet6.Command.Pattern;

public class Deposit : ITransaction
{
    private readonly Account _account;
    private readonly decimal _amount;

    public ExecutionStatus Status { get; set; }

    public Deposit(Account account, decimal amount)
    {
        _account = account;
        _amount = amount;

        Status = ExecutionStatus.Unprocessed;
    }

    public void Execute()
    {
        _account.Balance += _amount;

        Status = ExecutionStatus.ExecuteSucceeded;
    }
}