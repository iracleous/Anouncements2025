namespace Anouncements.Factory;

public interface INotifier
{
    void Send(string message);
}

public class EmailNotifier : INotifier
{
    public void Send(string message) => Console.WriteLine($"Email: {message}");
}

public class SmsNotifier : INotifier
{
    public void Send(string message) => Console.WriteLine($"SMS: {message}");
}

public class PushNotifier : INotifier
{
    public void Send(string message) => Console.WriteLine($"Push: {message}");
}

public interface INotifierFactory
{
    INotifier CreateNotifier(string type);
}

public class NotifierFactory : INotifierFactory
{
    public INotifier CreateNotifier(string type) =>
        type.ToLower() switch
    {
        "email" => new EmailNotifier(),
        "sms" => new SmsNotifier(),
        "push" => new PushNotifier(),
        _ => throw new ArgumentException("Invalid notifier type")
    };
}
