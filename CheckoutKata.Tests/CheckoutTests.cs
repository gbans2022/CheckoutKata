namespace CheckoutKata.Tests;

public class CheckoutTests
{
    [Fact]
    public void SingleItem_ShouldReturnUnitPrice()
    {
        var rules = new List<PricingRule>
            {
                new PricingRule("A", 12, 5, 55),
                new PricingRule("B", 7, 3, 33)
            };
    
        var checkout = new Checkout(rules);
        checkout.Scan("A");
        Assert.Equal(12, checkout.GetTotalPrice());
    }

    [Fact]
    public void BundleApplied_ShouldReturnBundlePrice()
    {
        var rules = new List<PricingRule>
        {
            new PricingRule("A", 12, 5, 55),
            new PricingRule("B", 7, 3, 33)
        };

        var checkout = new Checkout(rules);
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A");
        Assert.Equal(55, checkout.GetTotalPrice());
    }
}