namespace DesignPatternsCSharpNet6.Decorator.NonPattern;

public class PizzaOrder
{
    public decimal Price { get; private set; }
    public List<string> Ingredients { get; } =
        new List<string> { "Dough", "Tomato sauce", "Cheese" };

    // Properties for delivery orders
    public decimal DeliveryFee { get; set; }
    public decimal TotalCharge => Price + DeliveryFee;
    public DateTime DeliveryDateTime { get; set; }
    public string? DeliveryDriverName { get; set; }
    
    // Properties for pick up orders
    public string? CustomerName { get; set; }
    public DateTime PickupDateTime { get; set; }
    
    // Properties for dining room orders
    public string? WaitStaffName { get; set; }
    public int TableNumber { get; set; }

    public PizzaOrder()
    {
        Price = 10.00M;
    }

    public void AddIngredient(string ingredientName, decimal price)
    {
        Ingredients.Add(ingredientName);

        Price += price;
    }
}