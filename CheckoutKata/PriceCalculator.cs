namespace CheckoutKata;

public sealed class PriceCalculator
{
    private static readonly PriceCalculator instance = new();
    private readonly PricingRules pricingRules = PricingRules.Instance;

    public int CalculateTotalItemPrice(string item, int quantity)
    {
        int totalPrice = 0;
        if (quantity <= 0) return 0;
        while (quantity >= pricingRules.BundleQuantity[item])
        {
            totalPrice += pricingRules.BundlePrice[item];
            quantity -= pricingRules.BundleQuantity[item];
        }
        while(quantity > 0)
        {
            totalPrice += pricingRules.UnitPrice[item];
            quantity--;
        }
        return totalPrice;
    }

    private PriceCalculator() { }

    public static PriceCalculator Instance
    {
        get { return instance; }
    }
}