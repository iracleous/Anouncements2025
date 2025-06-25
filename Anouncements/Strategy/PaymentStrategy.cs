namespace Anouncements.Strategy;

public interface IPaymentStrategy
{
    void ProcessPayment();
}

public class CreditCardPayment : IPaymentStrategy
{
    public void ProcessPayment() => Console.WriteLine("Paid by credit card");
}

public class PayPalPayment : IPaymentStrategy
{
    public void ProcessPayment() => Console.WriteLine("Paid by PayPal");
}
