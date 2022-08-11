namespace DesignPatternsCSharpNet6.Decorator.Pattern;

public class PizzaOrderForTable
{
    public PizzaOrder Pizza { get; }
    public string WaitStaffName { get; set; }
    public int TableNumber { get; }

    public PizzaOrderForTable(PizzaOrder pizza, string waitStaffName, 
        int tableNumber)
    {
        Pizza = pizza;
        WaitStaffName = waitStaffName;
        TableNumber = tableNumber;
    }
}