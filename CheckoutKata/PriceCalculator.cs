namespace CheckoutKata;

public class PriceCalculator : IPriceCalculator
{
    private readonly Dictionary<string, PricingRule> _pricingRules;

    public PriceCalculator(IEnumerable<PricingRule> rules)
    {
        _pricingRules = new Dictionary<string, PricingRule>();
        foreach (var rule in rules)
        {
            _pricingRules[rule.Item] = rule;
        }
    }

    public int CalculateTotalItemPrice(string item, int quantity)
    {
        if (!_pricingRules.ContainsKey(item))
            throw new InvalidOperationException($"No pricing rule found for item '{item}'.");

        var rule = _pricingRules[item];
        int totalPrice = 0;

        // Apply bundle pricing
        while (quantity >= rule.BundleQuantity && rule.BundleQuantity > 0)
        {
            totalPrice += rule.BundlePrice;
            quantity -= rule.BundleQuantity;
        }

        // Apply unit pricing
        totalPrice += quantity * rule.UnitPrice;

        return totalPrice;
    }
}
