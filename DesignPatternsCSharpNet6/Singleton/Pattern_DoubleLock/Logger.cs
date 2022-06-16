namespace DesignPatternsCSharpNet6.Singleton.Pattern_DoubleLock;

public sealed class Logger
{
    private static Logger s_logger;
    private static readonly object s_syncLock = new object();

    // Private constructor stops other classes
    // from instantiating a Logger object.
    private Logger()
    {
    }

    // This static methods returns the single Logger object,
    // which it instantiates, using a lock, to prevent threading issues.
    public static Logger GetLogger()
    {
        if (s_logger == null)
        {
            lock (s_syncLock)
            {
                if (s_logger == null)
                {
                    s_logger = new Logger();
                }
            }
        }

        return s_logger;
    }

    public void WriteMessage(string message)
    {
        // Pretend we're writing the message to a file here.
    }
}