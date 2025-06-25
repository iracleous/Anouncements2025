namespace Anouncements.Singleton;

public interface IAppConfigService
{
    string GetAppName();
}

public class AppConfigService : IAppConfigService
{
    private static readonly Lazy<string> _lazyAppName = new(() => {
        Console.WriteLine("AppConfigService initialized!");
        return "MyLazyLoadedAPI"; // Could read from file, remote config, etc.
    });

    public string GetAppName() => _lazyAppName.Value;
}
