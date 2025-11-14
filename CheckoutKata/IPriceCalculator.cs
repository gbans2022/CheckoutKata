namespace CheckoutKata;

public interface IPriceCalculator
{
    int CalculateTotalItemPrice(string item, int quantity);
}