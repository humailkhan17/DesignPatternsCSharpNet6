namespace DesignPatternsCSharpNet6.Adapter.Pattern;

public class ShippingRequest
{
    public Guid Id { get; set; }
    public Address ShipFromAddress { get; set; }
    public Address ShipToAddress { get; set; }
    public int NumberOfItems { get; set; }
    public decimal TotalWeight { get; set; }
    public bool ContainsFragileItem { get; set; }

    public class Address
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string PostalCode { get; set; }
    }
}