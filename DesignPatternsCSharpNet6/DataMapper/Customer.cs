namespace DesignPatternsCSharpNet6.DataMapper;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsPremiumMember { get; set; }

    public Customer(int id, string name, bool isPremiumMember)
    {
        Id = id;
        Name = name;
        IsPremiumMember = isPremiumMember;
    }
}