namespace ExampleLauncher;

public class AsyncJob : ILauncherJob
{
    private Func<CancellationToken, Task> AsyncAction { get; }
    public AsyncJob(Func<CancellationToken, Task> asyncAction)
    {
        AsyncAction = asyncAction;
    }

    public string RelatedViewUri { get; } = string.Empty;

    public async Task Run(CancellationToken ct)
    {
        await AsyncAction.Invoke(ct);
    }
}
