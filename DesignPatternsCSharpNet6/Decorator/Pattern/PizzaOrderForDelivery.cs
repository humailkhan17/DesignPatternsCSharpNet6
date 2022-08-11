namespace DesignPatternsCSharpNet6.Decorator.Pattern;

public class PizzaOrderForDelivery
{
    public PizzaOrder Pizza { get; }
    public DateTime DeliveryDateTime { get; }
    public decimal DeliveryFee { get; }
    public decimal TotalCharge => Pizza.Price + DeliveryFee;
    public string DeliveryDriverName { get; }

    public PizzaOrderForDelivery(PizzaOrder pizza, DateTime orderDateTime, 
        decimal deliveryFee, string deliveryDriverName)
    {
        Pizza = pizza;
        DeliveryDateTime = orderDateTime.AddMinutes(30);
        DeliveryFee = deliveryFee;
        DeliveryDriverName = deliveryDriverName;
    }
}