namespace DesignPatternsCSharpNet6.Adapter.Pattern;

public class InventoryItem
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal Weight { get; set; }
    public bool IsFragile { get; set; }
}