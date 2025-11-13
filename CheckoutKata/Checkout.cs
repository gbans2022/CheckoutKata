namespace CheckoutKata;

public sealed class Checkout : ICheckout
{
    public Checkout(List<PricingRule> pricingRules)
    {  
        PricingRules.Instance.Add(pricingRules);    
    }
    private readonly PriceCalculator priceCalculator = PriceCalculator.Instance;
    private readonly Dictionary<string, int> totalItems = new();

    public void Scan(string item)
    {
        if (totalItems.ContainsKey(item))
        {
            totalItems[item]++;
        }
        else
        {
            totalItems[item] = 1;
        }
    }

    public int GetTotalPrice()
    {
        var total = 0;

        foreach (var kvp in totalItems)
        {
            var item = kvp.Key;
            var quantity = kvp.Value;

            total += priceCalculator.CalculateTotalItemPrice(item, quantity);
            Console.WriteLine($"Item: {item}, Quantity: {quantity}, Subtotal: {total}");
        }

        return total;
    }
}