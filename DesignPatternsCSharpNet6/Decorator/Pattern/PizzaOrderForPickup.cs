namespace DesignPatternsCSharpNet6.Decorator.Pattern;

public class PizzaOrderForPickup
{
    public PizzaOrder Pizza { get; }
    public string CustomerName { get; }
    public DateTime PickupDateTime { get; }

    public PizzaOrderForPickup(PizzaOrder pizza, string customerName, 
        DateTime pickupDateTime)
    {
        Pizza = pizza;
        CustomerName = customerName;
        PickupDateTime = pickupDateTime;
    }
}