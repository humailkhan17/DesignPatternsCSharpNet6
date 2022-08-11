namespace DesignPatternsCSharpNet6.Adapter.Pattern;

public static class ShippingRequestAdapter
{
    public static ShippingRequest CreateShippingRequestFromOrder(Order order)
    {
        ShippingRequest.Address fromAddress =
            new ShippingRequest.Address
            {
                StreetAddress = "1234 Main Street",
                City = "Houston",
                StateProvince = "TX",
                PostalCode = "77777"
            };

        ShippingRequest.Address toAddress =
            new ShippingRequest.Address
            {
                StreetAddress = order.Customer.StreetAddress,
                City = order.Customer.City,
                StateProvince = order.Customer.StateProvince,
                PostalCode = order.Customer.PostalCode
            };

        return new ShippingRequest
        {
            Id = Guid.NewGuid(),
            ShipFromAddress = fromAddress,
            ShipToAddress = toAddress,
            NumberOfItems = order.OrderItems.Sum(i => i.Quantity),
            TotalWeight = order.OrderItems.Sum(i => i.Quantity * i.Item.Weight),
            ContainsFragileItem = order.OrderItems.Any(i => i.Item.IsFragile)
        };
    }
}