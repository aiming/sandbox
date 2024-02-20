namespace ExampleLauncher;

public class ApplicationContext
{
    private static ApplicationContext? _instance;
    public static ApplicationContext Instance => _instance ??= new ApplicationContext();

    public JobRunner JobRunner { get; } = new();
    public DownloaderViewModel DownloaderViewModel { get; } = new();

    private ApplicationContext()
    {
        StartJobRunner(default);
    }

    private async void StartJobRunner(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            await JobRunner.NextAsync(ct);
            await Task.Delay(100, ct);
        }
    }
}
