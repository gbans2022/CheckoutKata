namespace CheckoutKata.Tests;

public class CheckoutTests
{
    private ICheckout CreateCheckout()
    {
    var rules = new List<PricingRule>
    {
        new PricingRule("A", 12, 5, 55),
        new PricingRule("B", 7, 3, 33),
        new PricingRule("C", 5, 2, 22),
        new PricingRule("D", 3, 4, 44)
    };

    IPriceCalculator calculator = new PriceCalculator(rules);
    return new Checkout(calculator);
    }

        [Fact]
    public void SingleItem_ShouldReturnUnitPrice()
    {
        var checkout = CreateCheckout();
        checkout.Scan("A");
        Assert.Equal(12, checkout.GetTotalPrice());
    }

    [Fact]
    public void BundleApplied_ShouldReturnBundlePrice()
    {
        var checkout = CreateCheckout();
        for (int i = 0; i < 5; i++) checkout.Scan("A");
        Assert.Equal(55, checkout.GetTotalPrice());
    }


    [Fact]
    public void MixedItems_ShouldReturnCorrectTotal()
    {
        var checkout = CreateCheckout();
        checkout.Scan("A");
        checkout.Scan("B");
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("C");
        checkout.Scan("A");
        checkout.Scan("A");

        Assert.Equal(67, checkout.GetTotalPrice());
    }

    [Fact]
    public void NoItems_ShouldReturnZero()
    {
        var checkout = CreateCheckout();
        Assert.Equal(0, checkout.GetTotalPrice());
    }

    [Fact]
    public void ItemWithoutRule_ShouldThrowException()
    {
        var checkout = CreateCheckout();
        checkout.Scan("Z");
        Assert.Throws<InvalidOperationException>(() => checkout.GetTotalPrice());
    }

    [Fact]
    public void PartialBundle_ShouldApplyBundleAndUnitPrice()
    {
        var checkout = CreateCheckout();
        for (int i = 0; i < 7; i++) checkout.Scan("B"); 
        Assert.Equal(73, checkout.GetTotalPrice());
    }
}