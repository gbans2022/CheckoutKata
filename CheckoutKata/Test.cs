namespace CheckoutKata;

public class Test
{
    public void TestMethod()
    {
        var rules = new List<PricingRule>
        {
            new PricingRule("A", 12, 5, 55),
            new PricingRule("B", 7, 3, 33),
            new PricingRule("C", 5, 2, 22),
            new PricingRule("D", 3, 4, 44)
        };

        IPriceCalculator calculator = new PriceCalculator(rules);
        ICheckout checkout = new Checkout(calculator);

        checkout.Scan("A");
        checkout.Scan("B");
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("C");
        checkout.Scan("A");
        checkout.Scan("A");

        int totalPrice = checkout.GetTotalPrice();
        Console.WriteLine($"Total Price: {totalPrice}");
    }
}
