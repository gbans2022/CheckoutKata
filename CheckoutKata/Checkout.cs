namespace CheckoutKata;

public class Checkout : ICheckout
{
    private readonly IPriceCalculator _priceCalculator;
    private readonly Dictionary<string, int> _scannedItems = new();

    public Checkout(IPriceCalculator priceCalculator)
    {
        _priceCalculator = priceCalculator;
    }

    public void Scan(string item)
    {
        if (_scannedItems.ContainsKey(item))
            _scannedItems[item]++;
        else
            _scannedItems[item] = 1;
    }

    public int GetTotalPrice()
    {
        int total = 0;
        foreach (var kvp in _scannedItems)
        {
            var itemTotal = _priceCalculator.CalculateTotalItemPrice(kvp.Key, kvp.Value);
            total += itemTotal;
            Console.WriteLine($"Item: {kvp.Key}, Quantity: {kvp.Value}, Subtotal: {itemTotal}");
        }
        return total;
    }
}
