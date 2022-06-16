namespace DesignPatternsCSharpNet6.Singleton.Pattern_StaticInitialization;

public sealed class Logger
{
    // Instantiating the s_logger here is thread-safe,
    // and eliminates needing to do manual locking.
    private static readonly Logger s_logger = new Logger();

    // Private constructor stops other classes
    // from instantiating a Logger object.
    private Logger()
    {
    }

    // This static methods returns the single Logger object,
    // which was instantiated on line 7.
    public static Logger GetLogger()
    {
        return s_logger;
    }

    public void WriteMessage(string message)
    {
        // Pretend we're writing the message to a file here.
    }
}