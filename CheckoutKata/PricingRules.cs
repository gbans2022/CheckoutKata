namespace CheckoutKata;
public sealed class PricingRules
{
    private static readonly PricingRules instance = new();
    public readonly Dictionary<string, int> UnitPrice = new();
    public readonly Dictionary<string, int> BundleQuantity = new();
    public readonly Dictionary<string, int> BundlePrice = new();

    public void Add(List<PricingRule> rules)
    {
        foreach (var rule in rules)
        {
            UnitPrice[rule.Item] = rule.UnitPrice;
            BundleQuantity[rule.Item] = rule.Bundle_Quantity;
            BundlePrice[rule.Item] = rule.Bundle_Price;
        }
    }
    
    private PricingRules() { }

    public static PricingRules Instance
    {
        get { return instance; }
    }
}