namespace CheckoutKata;

public class PricingRule
{
    public string Item { get; set; }
    public int UnitPrice { get; set; }
    public int Bundle_Quantity { get; set; }
    public int Bundle_Price { get; set; }
    

    public PricingRule(string item, int unitprice, int quantity, int price)
    {
        Item = item;
        UnitPrice = unitprice;
        Bundle_Quantity = quantity;
        Bundle_Price = price;
    }
}