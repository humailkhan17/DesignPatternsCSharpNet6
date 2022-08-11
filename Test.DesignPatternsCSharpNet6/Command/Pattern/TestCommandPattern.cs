using DesignPatternsCSharpNet6.Command.Pattern;

namespace Test.DesignPatternsCSharpNet6.Command.Pattern;

public class TestCommandPattern
{
    [Fact]
    public void Test_AllTransactionsSuccessful()
    {
        TransactionManager transactionManager = new TransactionManager();

        Account suesAccount = new Account("Sue Smith", 0);

        Deposit deposit = new Deposit(suesAccount, 100);
        transactionManager.AddTransaction(deposit);

        // Command has been added to the queue, but not executed.
        Assert.True(transactionManager.HasPendingTransactions);
        Assert.Equal(0, suesAccount.Balance);

        // This executes the code in the command objects.
        transactionManager.ProcessPendingTransactions();

        Assert.False(transactionManager.HasPendingTransactions);
        Assert.Equal(100, suesAccount.Balance);

        // Add a withdrawal, apply it, and verify the balance changed.
        Withdraw withdrawal = new Withdraw(suesAccount, 50);
        transactionManager.AddTransaction(withdrawal);

        transactionManager.ProcessPendingTransactions();

        Assert.False(transactionManager.HasPendingTransactions);
        Assert.Equal(50, suesAccount.Balance);
    }

    [Fact]
    public void Test_OverdraftRemainsInPendingTransactions()
    {
        TransactionManager transactionManager = new TransactionManager();

        // Create an account with a balance of 75
        Account bobsAccount = new Account("Bob Jones", 75);

        // The first command is a withdrawal that is larger than the account's balance.
        // It will not be executed, because of the check in Withdraw.Execute.
        // The deposit will be successful.
        transactionManager.AddTransaction(new Withdraw(bobsAccount, 100));
        transactionManager.AddTransaction(new Deposit(bobsAccount, 75));

        transactionManager.ProcessPendingTransactions();

        // The withdrawal of 100 was not completed, 
        // because there was not enough money in the account.
        // So, it is still pending.
        Assert.True(transactionManager.HasPendingTransactions);
        Assert.Equal(150, bobsAccount.Balance);

        // The pending transactions (the withdrawal of 100), should execute now.
        transactionManager.ProcessPendingTransactions();

        Assert.False(transactionManager.HasPendingTransactions);
        Assert.Equal(50, bobsAccount.Balance);
    }

    [Fact]
    public void Test_Transfer()
    {
        TransactionManager transactionManager = new TransactionManager();

        Account checking = new Account("Mike Brown", 1000);
        Account savings = new Account("Mike Brown", 100);

        transactionManager.AddTransaction(new Transfer(checking, savings, 750));

        transactionManager.ProcessPendingTransactions();

        Assert.Equal(250, checking.Balance);
        Assert.Equal(850, savings.Balance);
    }
}