namespace DesignPatternsCSharpNet6.Adapter.Pattern;

public class Order
{
    public int Id { get; set; }
    public Customer Customer { get; set; }
    public List<OrderItem> OrderItems { get; } = new();
}