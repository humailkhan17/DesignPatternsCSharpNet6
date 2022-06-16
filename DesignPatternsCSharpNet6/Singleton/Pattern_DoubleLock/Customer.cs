namespace DesignPatternsCSharpNet6.Singleton.Pattern_DoubleLock;

public class Customer
{
    private readonly Logger _logger;

    public string Name { get; }

    public Customer(string name)
    {
        _logger = Logger.GetLogger();

        Name = name;
    }

    public void UpdateAddress(string streetAddress, string city)
    {
        // Pretend we update the database, and/or do other things here.

        // Now, write a log message, so we have a record of the update.
        _logger.WriteMessage($"Updated the address for: {Name} at: {DateTime.Now}");
    }
}