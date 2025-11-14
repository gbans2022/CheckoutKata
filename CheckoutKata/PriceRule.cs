namespace CheckoutKata;

public class PricingRule
{
    public string Item { get; }
    public int UnitPrice { get; }
    public int BundleQuantity { get; }
    public int BundlePrice { get; }

    public PricingRule(string item, int unitPrice, int bundleQuantity, int bundlePrice)
    {
        Item = item;
        UnitPrice = unitPrice;
        BundleQuantity = bundleQuantity;
        BundlePrice = bundlePrice;
    }
}