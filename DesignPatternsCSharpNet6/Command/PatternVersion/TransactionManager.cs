namespace DesignPatternsCSharpNet6.Command.PatternVersion;

public class TransactionManager
{
    private readonly List<ITransaction> _transactions = 
        new List<ITransaction>();

    public bool HasPendingTransactions =>
        _transactions.Any(x =>
            x.Status == ExecutionStatus.Unprocessed ||
            x.Status == ExecutionStatus.InsufficientFunds ||
            x.Status == ExecutionStatus.ExecuteFailed);

    public void AddTransaction(ITransaction transaction)
    {
        _transactions.Add(transaction);
    }

    public void ProcessPendingTransactions()
    {
        // Execute transactions that are unprocessed,
        // or couldn't be precessed successfully before.
        foreach(ITransaction transaction in _transactions.Where(x =>
                    x.Status == ExecutionStatus.Unprocessed ||
                    x.Status == ExecutionStatus.InsufficientFunds ||
                    x.Status == ExecutionStatus.ExecuteFailed))
        {
            try
            {
                transaction.Execute();
            }
            catch (Exception e)
            {
                transaction.Status = ExecutionStatus.ExecuteFailed;
            }
        }
    }
}