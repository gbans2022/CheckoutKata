namespace CheckoutKata;

public class Test
{
    public void TestMethod()
    {
        PricingRule ruleA = new PricingRule("A", 12, 5, 55);
        PricingRule ruleB = new PricingRule("B", 7, 3, 33);
        PricingRule ruleC = new PricingRule("C", 5, 2, 22);
        PricingRule ruleD = new PricingRule("D", 3, 4, 44);

        List<PricingRule> pricingRules = new List<PricingRule> { ruleA, ruleB, ruleC, ruleD };

        Checkout checkout = new Checkout(pricingRules);
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
