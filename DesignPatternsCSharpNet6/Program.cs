Console.WriteLine("Design Patterns - C# .NET 6");

string input = "";

do
{
    input = Console.ReadLine() ?? "";

} while (!input.Equals("exit", StringComparison.InvariantCultureIgnoreCase));
