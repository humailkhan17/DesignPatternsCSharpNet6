namespace DesignPatternsCSharpNet6.Singleton.NonPattern;

public class Logger
{
    // Public constructor allows other classes
    // to instantiate a Logger object,
    // which allows multiple instances of Logger objects
    public Logger()
    {
    }

    public void WriteMessage(string message)
    {
        // Pretend we're writing the message to a file here.
    }
}