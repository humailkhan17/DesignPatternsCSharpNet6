namespace DesignPatternsCSharpNet6.Decorator.Pattern;

public class PizzaOrder
{
    public decimal Price { get; private set; }
    public List<string> Ingredients { get; } = 
        new List<string> { "Dough", "Tomato sauce", "Cheese" };

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